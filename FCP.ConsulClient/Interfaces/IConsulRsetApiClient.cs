using System;

namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul RsetApi客户端 接口
    /// </summary>
    public interface IConsulRsetApiClient : IConsulAgentApiClient, IConsulHealthApiClient, IConsulKVApiClient, IDisposable
    {

    }
}
