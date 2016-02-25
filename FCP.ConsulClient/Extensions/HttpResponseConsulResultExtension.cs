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
        internal static async Task<ConsulApiQueryResult<T>> formatConsulApiQueryResult<T>(this HttpResponseMessage response)
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
        internal static async Task<ConsulApiWriteResult<T>> formatConsulApiWriteResult<T>(this HttpResponseMessage response)
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
            responseJson = responseJson ?? string.Empty;
            if (typeof(T) == typeof(string) && responseJson.Length > 0)
            { 
                //对于反序列化为String时，确保首尾存在双引号
                if (!responseJson.StartsWith("\""))
                {
                    responseJson = "\"" + responseJson;
                }
                if (!responseJson.EndsWith("\""))
                {
                    responseJson += "\"";
                }
            }

            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}
