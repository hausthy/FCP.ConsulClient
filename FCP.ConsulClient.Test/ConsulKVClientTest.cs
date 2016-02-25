using System.Threading.Tasks;
using Xunit;
using Consul.RsetApi.Client;
using System;
using System.Text;

namespace FCP.ConsulClient.Test
{
    public class ConsulKVClientTest
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        internal static string GenerateTestKeyName()
        {
            var keyChars = new char[16];
            for (var i = 0; i < keyChars.Length; i++)
            {
                keyChars[i] = Convert.ToChar(Random.Next(65, 91));
            }
            return new string(keyChars);
        }

        [Fact]
        public async Task kv_Put_Get_Delete()
        {
            using (var client = new ConsulRsetApiClient())
            {
                var key = GenerateTestKeyName();

                var getResponse = await client.kvGetAsync(key).ConfigureAwait(false);
                Assert.Null(getResponse.ResponseData);

                var putResponse = await client.kvPutAsync(key, "test", true).ConfigureAwait(false);
                Assert.True(putResponse.ResponseData);

                getResponse = await client.kvGetAsync(key).ConfigureAwait(false);
                Assert.NotNull(getResponse.ResponseData);                

                var getRawResponse = await client.kvGetRawAsync(key).ConfigureAwait(false);                
                Assert.True(string.Compare("test", getRawResponse.ResponseData, true) == 0);

                var deleteResponse = await client.kvDeleteAsync(key).ConfigureAwait(false);
                Assert.True(deleteResponse.ResponseData);

                getResponse = await client.kvGetAsync(key).ConfigureAwait(false);
                Assert.Null(getResponse.ResponseData);
            }
        }

        [Fact]
        public async Task kv_List_Get_Delete()
        {
            using (var client = new ConsulRsetApiClient())
            {
                var prefix = GenerateTestKeyName();

                for (var i = 0; i < 100; i++)
                {
                    var key = string.Join("/", prefix, GenerateTestKeyName());
                    
                    Assert.True((await client.kvPutAsync(key, "test").ConfigureAwait(false)).ResponseData);
                }                

                var listResponse = await client.kvGetListAsync(prefix).ConfigureAwait(false);
                Assert.NotNull(listResponse.ResponseData);
                Assert.Equal(listResponse.ResponseData.Length, 100);

                var encodeValue = Convert.ToBase64String(Encoding.UTF8.GetBytes("test"));
                foreach (var pair in listResponse.ResponseData)
                {
                    Assert.True(string.Compare(encodeValue, pair.Value, true) == 0);
                }

                var deleteResponse = await client.kvDeleteListAsync(prefix).ConfigureAwait(false);
                Assert.True(deleteResponse.ResponseData);

                listResponse = await client.kvGetListAsync(prefix).ConfigureAwait(false);
                Assert.Null(listResponse.ResponseData);
            }
        }

        [Fact]
        public async Task kv_Keys_Get_Delete()
        {
            using (var client = new ConsulRsetApiClient())
            {
                var prefix = GenerateTestKeyName();

                for (var i = 0; i < 100; i++)
                {
                    var key = string.Join("/", prefix, GenerateTestKeyName());

                    Assert.True((await client.kvPutAsync(key, "test").ConfigureAwait(false)).ResponseData);
                }

                var keysResponse = await client.kvGetKeysAsync(prefix).ConfigureAwait(false);
                Assert.NotNull(keysResponse.ResponseData);
                Assert.Equal(keysResponse.ResponseData.Length, 100);

                var deleteResponse = await client.kvDeleteListAsync(prefix).ConfigureAwait(false);
                Assert.True(deleteResponse.ResponseData);

                keysResponse = await client.kvGetKeysAsync(prefix).ConfigureAwait(false);
                Assert.Null(keysResponse.ResponseData);
            }
        }
    }
}
