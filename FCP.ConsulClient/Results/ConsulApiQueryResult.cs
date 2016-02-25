namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul Api查询结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConsulApiQueryResult<T> : ConsulRsetApiResult
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T ResponseData { get; set; }
    }
}
