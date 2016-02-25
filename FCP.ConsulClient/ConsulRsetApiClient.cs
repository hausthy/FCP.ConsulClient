using System;
using System.Net.Http;

namespace Consul.RsetApi.Client
{
    /// <summary>
    /// Consul RsetApi客户端
    /// </summary>
    public partial class ConsulRsetApiClient : IConsulRsetApiClient
    {
        private HttpClient _httpClient;

        private Uri _apiBaseUri;

        protected static Uri defaultApiBaseUri = new UriBuilder("http://127.0.0.1:8500").Uri;

        #region 构造函数
        public ConsulRsetApiClient()
            : this(defaultApiBaseUri)
        { }

        public ConsulRsetApiClient(Uri apiBaseUri)
        {
            _apiBaseUri = apiBaseUri ?? defaultApiBaseUri;
            _httpClient = new HttpClient() { BaseAddress = _apiBaseUri };            
        }
        #endregion

        #region 属性
        protected HttpClient httpClient { get { return _httpClient; } }
        #endregion

        #region IDisposable实现
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
