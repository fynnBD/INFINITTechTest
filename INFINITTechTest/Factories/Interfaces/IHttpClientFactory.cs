using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace INFINITTechTest.Factories.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}
