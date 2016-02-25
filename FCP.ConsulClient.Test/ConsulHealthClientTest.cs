using System.Threading.Tasks;
using Xunit;
using Consul.RsetApi.Client;

namespace FCP.ConsulClient.Test
{
    public class ConsulHealthClientTest
    {
        [Fact]
        public async Task health_Service()
        {
            using (var client = new ConsulRsetApiClient())
            {
                var checks = await client.healthServiceAsync("consul", "", true).ConfigureAwait(false);
                Assert.NotEqual(0, checks.ResponseData.Length);
            }
        }

        [Fact]
        public async Task health_State()
        {
            using (var client = new ConsulRsetApiClient())
            {
                var checks = await client.healthStateAsync("any").ConfigureAwait(false);
                Assert.NotEqual(0, checks.ResponseData.Length);
            }
        }
    }
}
