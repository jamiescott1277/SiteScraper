using SiteScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteScraper.Repositories
{
    /// <summary>
    /// Summary description for ISiteScraperRepository
    /// </summary>
    public interface ISiteScraperRepository
    {
        ScrapedModel ScrapeSite(string url);
    }
}