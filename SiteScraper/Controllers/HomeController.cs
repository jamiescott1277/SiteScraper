using SiteScraper.Models;
using SiteScraper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SiteScraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISiteScraperRepository _siteScraperRepository;
        public HomeController(ISiteScraperRepository siteScraperRepository)
        {
            _siteScraperRepository = siteScraperRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ScrapedModel model)
        {
            if (ModelState.IsValid)
            {
                model = _siteScraperRepository.ScrapeSite(model.Url);
                return View(model);
            }
            else
            {
                ViewBag.Message = "Please enter a valid url!";
                return View();
            }            
        }
    }
}