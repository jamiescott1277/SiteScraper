﻿using SiteScraper.Http;
using SiteScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SiteScraper.Repositories
{
    public class SiteScraperRepository : ISiteScraperRepository
    {
        private readonly IClient _client;
        public SiteScraperRepository(IClient client)
        {
            _client = client;
        }

        public ScrapedModel ScrapeSite(string url)
        {
            var ret = new ScrapedModel();
            try
            {
                var uri = new Uri(url);
                var content = _client.GetContent(uri);

                //Set image urls
                var imageUrlMatches = Regex.Matches(content, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                foreach (Match imageUrlMatch in imageUrlMatches)
                {
                    var imageUrl = imageUrlMatch.Groups[1].Value;
                    //Account for urls w/o a scheme set
                    if (!imageUrl.StartsWith("http") && imageUrl.StartsWith("//"))
                    {
                        imageUrl = $"{uri.Scheme}:{imageUrl}";
                    }

                    //Account for relative urls
                    if (imageUrl.StartsWith("/"))
                    {
                        imageUrl = $"{uri.Scheme}://{uri.Host}{imageUrl}";
                    }

                    ret.ImageUrls.Add(imageUrl);                
                }

                var words = GetWordsFromHtml(content);
                ret.WordCount = words.Count();
                ret.Top10Words.AddRange(words.GroupBy(g => g).OrderByDescending(w => w.Count()).ThenBy(w => w.Key).Take(10).Select(s => s.Key.Trim() + $" ({s.Count()})"));
            }
            catch (Exception ex)
            {
                string logMessage = ex.Message;
                //Normally would Log error to appropriate logger
            }

            return ret;
        }

        private List<string> GetWordsFromHtml(string htmlString)
        {
            var words = new List<string>();
            var wordMatches = Regex.Matches(htmlString, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            
            foreach (Match wordMatch in wordMatches)
            {
                words.Add(wordMatch.Value);
            }

            return words;
        }
    }
}