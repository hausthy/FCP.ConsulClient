namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul Agent服务信息
    /// </summary>
    public class ConsulAgentService
    {
        public string ID { get; set; }
        public string Service { get; set; }
        public string[] Tags { get; set; }
        public int Port { get; set; }
        public string Address { get; set; }
    }
}
