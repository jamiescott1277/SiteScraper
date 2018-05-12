using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SiteScraper.Http
{
    /// <summary>
    /// Summary description for CLient.  The HtmlAgility Pack can grab content, but wanted to show setting up using HttpClient.
    /// </summary>
    public class Client : IClient
    {
        private static readonly HttpClient _client = new HttpClient();

        public string GetContent(Uri uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = Task.Run(() => SendAsync(request)).Result;
            return Task.Run(() => response.Content.ReadAsStringAsync()).Result;
        }

        private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await _client.SendAsync(request);
        }
    }
}