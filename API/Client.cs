using Microsoft.Rest;
using Newtonsoft.Json;

namespace FootballApi.API
{
    public class Client
    {
        public System.Uri _uri;
        private readonly string _apiKey;
        private readonly string _apiHost;

        public Client(System.Uri uri, string apiKey, string apiHost) 
        { 
            _uri = uri;
            _apiKey = apiKey;
            _apiHost = apiHost;
        }

        public async Task<HttpOperationResponse> GetData(List<string> queryParameters,string endpoint)
        {
            var baseUrl = _uri.AbsoluteUri+ endpoint;
            if(queryParameters.Count>0)
            {
                baseUrl += "?" + string.Join("&",queryParameters);
            }
            var client = new HttpClient();
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseUrl),
                Headers =
                {
                    { "X-RapidAPI-Key", _apiKey },
                    { "X-RapidAPI-Host",_apiHost }
                }

            };
            var response = await client.SendAsync(httpRequest);
            var result = new HttpOperationResponse
            {
                Response = response,
                Request = httpRequest
            };
            return result;

        }
    }
}
