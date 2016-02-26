using System;

namespace Consul.RsetApi.Client
{
    public static class ConsulConstants
    {
        /// <summary>
        /// 默认Api基地址
        /// </summary>
        public static Uri DefaultApiBaseUri = new UriBuilder("http://127.0.0.1:8500").Uri;
    }
}
