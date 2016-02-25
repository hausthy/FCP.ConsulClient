using System.Threading.Tasks;

namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul key/value Api客户端 接口
    /// </summary>
    public interface IConsulKVApiClient
    {
        #region 获取键值
        /// <summary>
        /// 获取key/value信息
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<ConsulKVPair>> kvGetAsync(string key);

        /// <summary>
        /// 获取raw value信息
        /// </summary>
        /// <param name="key">键</param>        
        /// <returns></returns>
        Task<ConsulApiQueryResult<string>> kvGetRawAsync(string key);

        /// <summary>
        /// 获取key/value集合
        /// </summary>
        /// <param name="prefix">键前缀</param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<ConsulKVPair[]>> kvGetListAsync(string prefix);
        #endregion

        #region 获取键
        /// <summary>
        /// 获取key集合
        /// </summary>
        /// <param name="prefix">键前缀</param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<string[]>> kvGetKeysAsync(string prefix);

        /// <summary>
        /// 获取key集合
        /// </summary>
        /// <param name="prefix">键前缀</param>
        /// <param name="separator"></param>
        /// <returns></returns>
        Task<ConsulApiQueryResult<string[]>> kvGetKeysAsync(string prefix, string separator);
        #endregion

        #region 上传键值
        /// <summary>
        /// 上传key/value信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        Task<ConsulApiWriteResult<bool>> kvPutAsync(string key, string value);

        /// <summary>
        /// 上传key/value信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="addOnly">是否只添加</param>
        /// <returns></returns>
        Task<ConsulApiWriteResult<bool>> kvPutAsync(string key, string value, bool addOnly);

        /// <summary>
        /// 上传key/value信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="addOnly">是否只添加</param>
        /// <param name="flags">自定义标识</param>
        /// <returns></returns>
        Task<ConsulApiWriteResult<bool>> kvPutAsync(string key, string value, bool addOnly, ulong flags);        
        #endregion

        #region 删除键值
        /// <summary>
        /// 删除key/value信息
        /// </summary>
        /// <param name="key">键</param>        
        /// <returns></returns>
        Task<ConsulApiWriteResult<bool>> kvDeleteAsync(string key);

        /// <summary>
        /// 删除key/value集合
        /// </summary>
        /// <param name="prefix">键前缀</param>        
        /// <returns></returns>
        Task<ConsulApiWriteResult<bool>> kvDeleteListAsync(string prefix);
        #endregion
    }
}
