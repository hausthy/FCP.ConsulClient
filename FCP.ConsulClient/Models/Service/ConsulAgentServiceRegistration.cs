namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul Agent服务注册信息
    /// </summary>
    public class ConsulAgentServiceRegistration
    {
        public string ID { get; set; }
        
        public string Name { get; set; }
       
        public string[] Tags { get; set; }
        
        public int Port { get; set; }
        
        public string Address { get; set; }
        
        public ConsulAgentServiceCheck Check { get; set; }
    }
}
