using System.Net;

namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul RsetApi结果
    /// </summary>
    public abstract class ConsulRsetApiResult
    {        
        public HttpStatusCode StatusCode { get; set; }
    }
}
