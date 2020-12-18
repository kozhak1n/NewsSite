using Microsoft.AspNetCore.Mvc;
using NewsSite.Data.interfaces;
using NewsSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    public class HomeController : Controller
    {
        private IAllNews _newsRep;
        public HomeController(IAllNews newsRep)
        {
            _newsRep = newsRep;
        }
        public ViewResult Index()
        {
            var homeNews = new HomeViewModel
            {
                someNews = _newsRep.GetSomeNews
            };
            return View(homeNews);
        }
        //Web API
        [HttpPost]
        public ActionResult NewsSearch(string name)
        {
            var allnews = _newsRep.GetSomeNews.Where(a => a.AuthorName.Contains(name)).ToList();
            if (allnews.Count <= 0)
            {
                return NotFound();
            }
            return PartialView(allnews);
        }

    }

    

}
