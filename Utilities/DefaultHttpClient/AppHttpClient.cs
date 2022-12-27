using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace helloralph.Utilities.DefaultHttpClient
{
    public class AppHttpClient : IAppHttpClient
    {
        private HttpClient _httpClient;
        private HttpClient _httpClientDummyApi;
        private JsonSerializerOptions _options;

        public HttpClient Default
        {
            get
            {
                if (_httpClient == null)
                    _httpClient = new HttpClient();
                return _httpClient;
            }
        }

        public JsonSerializerOptions DefaultSerializerOptions
        {
            get
            {
                if (_options == null)
                {
                    _options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                }
                return _options;
            }
        }

        public HttpClient DummyApi 
        {
            get
            {
                if (_httpClientDummyApi == null)
                {
                    _httpClientDummyApi = new HttpClient();
                    _httpClientDummyApi.DefaultRequestHeaders.Add("app-id", DummyAPI.APP_ID);
                }
                return _httpClientDummyApi;
            }
        }
    }
}
