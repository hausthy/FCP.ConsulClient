using System;
using System.Collections.Generic;
using System.Linq;

namespace Consul.RsetApi.Client
{
    public class ConsulApiUriBuilder
    {
        private string _apiUrl;
        private IDictionary<string, string> _paramDic;

        public ConsulApiUriBuilder()
        {
            _apiUrl = string.Empty;            
            _paramDic = new Dictionary<string, string>();
        }

        public ConsulApiUriBuilder Path(string apiUrl)
        {
            if (!string.IsNullOrEmpty(apiUrl))
            {
                _apiUrl = apiUrl;
            }
            return this;
        }

        public ConsulApiUriBuilder Param(string paramKey, string paramValue)
        {
            if (!string.IsNullOrEmpty(paramKey))
            {
                _paramDic.Add(paramKey, paramValue);
            }
            return this;
        }

        public Uri buildApiUri()
        {
            var uriBuilder = new UriBuilder { Path = _apiUrl };            
            uriBuilder.Query = string.Join("&", _paramDic.Select(m => formatApiQueryParam(m.Key, m.Value)));
            
            return new Uri(uriBuilder.Uri.PathAndQuery, UriKind.Relative);
        }

        private string formatApiQueryParam(string paramKey, string paramValue)
        {
            if (string.IsNullOrEmpty(paramKey))
                return string.Empty;

            if (string.IsNullOrEmpty(paramValue))
                return Uri.EscapeDataString(paramKey);

            return string.Format("{0}={1}", Uri.EscapeDataString(paramKey), Uri.EscapeDataString(paramValue));
        }
    }
}
