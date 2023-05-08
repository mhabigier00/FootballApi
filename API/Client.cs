using Microsoft.Rest;

namespace FootballApi.API
{
    public class Client
    {
        public Uri _uri;
        private readonly string _apiKey;

        public Client(string uri, string apiKey) 
        { 
            _uri = new Uri(uri);
            _apiKey = apiKey;
        }

        public async Task<HttpOperationResponse> GetData(Dictionary<string,string> queryParameters,string endpoint)
        {
            var baseUrl = _uri.AbsoluteUri +endpoint;

            if (queryParameters.Count>0)
            {
                baseUrl += "?" + string.Join("&", queryParameters.Select(x => $"{x.Key}={Uri.EscapeDataString(x.Value)}"));
            }
            var client = new HttpClient();
            var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(baseUrl),
                Headers =
                {
                    { "X-Auth-Token", _apiKey }
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
