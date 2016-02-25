namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul Agent服务check信息
    /// </summary>
    public class ConsulAgentServiceCheck
    {
        public string Script { get; set; }
        
        public string Interval { get; set; }
        
        public string Timeout { get; set; }
        
        public string TTL { get; set; }
        
        public string HTTP { get; set; }
        
        public string TCP { get; set; }
    }
}
