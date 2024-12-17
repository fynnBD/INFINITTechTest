using System.Configuration;
using System.Net.Http;
using INFINITTechTest.Factories.Interfaces;

namespace INFINITTechTest.Factories
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["baseURL"]);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + ConfigurationManager.AppSettings["gitHubKey"]);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("Mozilla", "5.0"));
            return client;
        }
    }
}
