using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteScraper.Models
{
    /// <summary>
    /// Summary description for ScrapedModel
    /// </summary>
    public class ScrapedModel
    {
        public ScrapedModel()
        {
            Top10Words = new List<string>();
            ImageUrls = new List<string>();
        }

        [Required]
        [RegularExpression(@"^(http|https):\/\/([\w\d + (\-)+?]+\.)+[\w]+(\/.*)?$", ErrorMessage = "You must input a valid URL.")]
        public string Url { get; set; }
        public List<string> Top10Words { get; set; }
        public List<string> ImageUrls { get; set; }
        public int WordCount { get; set; }
    }
}