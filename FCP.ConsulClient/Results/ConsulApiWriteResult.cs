namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul Api写入结果
    /// </summary>
    public class ConsulApiWriteResult : ConsulRsetApiResult
    {
        
    }

    /// <summary>
    /// Consul Api写入结果
    /// </summary>
    public class ConsulApiWriteResult<T> : ConsulApiWriteResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T ResponseData { get; set; }
    }
}
