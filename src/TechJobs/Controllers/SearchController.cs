using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            if(searchType == "all" || searchType=="All")
            {
                List<Dictionary<string, string>> searchResults = JobData.FindByValue(searchTerm);
                ViewBag.jobs = searchResults;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search";
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = searchResults;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search";
                return View("Index");

            }
            
        }

    }
}
