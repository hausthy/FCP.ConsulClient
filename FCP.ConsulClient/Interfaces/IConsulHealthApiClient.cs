using System.Threading.Tasks;

namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul Health Api客户端 接口
    /// </summary>
    public interface IConsulHealthApiClient
    {
        #region 查询服务
        /// <summary>
        /// 查询服务
        /// </summary>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<ConsulServiceEntry[]>> healthServiceAsync(string name);

        /// <summary>
        /// 查询服务
        /// </summary>
        /// <param name="name">服务名称</param>
        /// <param name="tag">服务标签</param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<ConsulServiceEntry[]>> healthServiceAsync(string name, string tag);

        /// <summary>
        /// 查询服务
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="tag">服务标签</param>
        /// <param name="passingOnly">只返回健康的服务</param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<ConsulServiceEntry[]>> healthServiceAsync(string name, string tag, bool passingOnly);
        #endregion

        /// <summary>
        /// 查询对应状态的Check
        /// </summary>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<ConsulHealthCheck[]>> healthStateAsync(string state);
    }
}
