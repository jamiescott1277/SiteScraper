using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SiteScraper.Http
{
    /// <summary>
    /// Summary description for IClient
    /// </summary>
    public interface IClient
    {
        string GetContent(Uri uri);
    }
}