using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consul.RsetApi.Client
{
    internal static class HttpResponseConsulResultExtension
    {
        /// <summary>
        /// 格式化Consul Api查询结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static async Task<ConsulApiQueryResult<string>> formatConsulApiQueryResultAsync(this HttpResponseMessage response)
        {
            var queryResult = new ConsulApiQueryResult<string>();
            queryResult.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                queryResult.ResponseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);                
            }

            return queryResult;
        }

        /// <summary>
        /// 格式化Consul Api查询结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static async Task<ConsulApiQueryResult<T>> formatConsulApiQueryResultAsync<T>(this HttpResponseMessage response)
        {
            var queryResult = new ConsulApiQueryResult<T>();
            queryResult.StatusCode = response.StatusCode;            

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                queryResult.ResponseData = deserializeJson<T>(responseJson);
            }            

            return queryResult;
        }

        /// <summary>
        /// 格式化Consul Api写入结果
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static ConsulApiWriteResult formatConsulApiWriteResult(this HttpResponseMessage response)
        {
            var writeResult = new ConsulApiWriteResult();
            writeResult.StatusCode = response.StatusCode;

            return writeResult;
        }

        /// <summary>
        /// 格式化Consul Api写入结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static async Task<ConsulApiWriteResult<string>> formatConsulApiWriteResultAsync(this HttpResponseMessage response)
        {
            var writeResult = new ConsulApiWriteResult<string>();
            writeResult.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                writeResult.ResponseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);                
            }

            return writeResult;
        }

        /// <summary>
        /// 格式化Consul Api写入结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        internal static async Task<ConsulApiWriteResult<T>> formatConsulApiWriteResultAsync<T>(this HttpResponseMessage response)
        {
            var writeResult = new ConsulApiWriteResult<T>();
            writeResult.StatusCode = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                writeResult.ResponseData = deserializeJson<T>(responseJson);
            }           

            return writeResult;
        }

        /// <summary>
        /// 反序列化Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseJson"></param>
        /// <returns></returns>
        private static T deserializeJson<T>(string responseJson)
        {
            if (string.IsNullOrEmpty(responseJson))
                return default(T);                        

            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}
