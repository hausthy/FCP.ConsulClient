using System.Threading.Tasks;
using Xunit;
using Consul.RsetApi.Client;

namespace FCP.ConsulClient.Test
{
    public class ConsulAgentClientTest
    {
        [Fact]
        public async Task agent_Service()
        {
            using (var client = new ConsulRsetApiClient())
            {
                var registration = new ConsulAgentServiceRegistration()
                {
                    Name = "foo",
                    Tags = new[] { "bar", "baz" },
                    Port = 8000,
                    Check = new ConsulAgentServiceCheck
                    {
                        TTL = "15s"
                    }
                };

                await client.agentServiceRegisterAsync(registration).ConfigureAwait(false);

                var services = await client.agentServicesAsync().ConfigureAwait(false);
                Assert.True(services.ResponseData.ContainsKey("foo"));

                var checks = await client.agentChecksAsync().ConfigureAwait(false);
                Assert.True(checks.ResponseData.ContainsKey("service:foo"));
                Assert.Equal("critical", checks.ResponseData["service:foo"].Status);

                await client.agentServiceDeregisterAsync("foo").ConfigureAwait(false);

                services = await client.agentServicesAsync().ConfigureAwait(false);
                Assert.False(services.ResponseData.ContainsKey("foo"));
            }
        }
    }
}
