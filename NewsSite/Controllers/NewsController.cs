using Microsoft.AspNetCore.Mvc;
using NewsSite.Data.interfaces;
using NewsSite.Data.Models;
using NewsSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly IAllNews _allNEws;
#pragma warning disable IDE0052 // Удалить непрочитанные закрытые члены
        private readonly INewsCategory _allCategories;
#pragma warning restore IDE0052 // Удалить непрочитанные закрытые члены

        public NewsController(IAllNews iAllNews, INewsCategory iNewsCat)
        {
            _allNEws = iAllNews;
            _allCategories = iNewsCat;
        }

        [Route("News/List")]
        [Route("News/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<News> news = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                news = _allNEws.News.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Dota 2", category, StringComparison.OrdinalIgnoreCase))
                {
                    news = _allNEws.News.Where(i => i.Category.CategoryName.Equals("Dota 2")).OrderBy(i => i.id);
                }
                else if (string.Equals("CS:GO", category, StringComparison.OrdinalIgnoreCase))
                {
                    news = _allNEws.News.Where(i => i.Category.CategoryName.Equals("CS:GO")).OrderBy(i => i.id);
                }
                currCategory = _category;

            }


            var newsObj = new NewsListViewModel
            {
                AllNews = news,
                currCategory = currCategory
            };


        ViewBag.Title = "Новостная страница";
           
            return View(newsObj);
        }
    
        [HttpPost]
        public ActionResult Search(string category)
        {
            string _category = category;
            IEnumerable<News> news = null;
            if (string.IsNullOrEmpty(category))
            {
                news = _allNEws.News.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("Dota 2", category, StringComparison.OrdinalIgnoreCase))
                {
                    news = _allNEws.News.Where(i => i.Category.CategoryName.Equals("Dota 2")).OrderBy(i => i.id);
                }
                else if (string.Equals("CS:GO", category, StringComparison.OrdinalIgnoreCase))
                {
                    news = _allNEws.News.Where(i => i.Category.CategoryName.Equals("CS:GO")).OrderBy(i => i.id);
                }
            }
            return PartialView(news);
        }


    }
}
