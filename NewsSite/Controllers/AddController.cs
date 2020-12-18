using Microsoft.AspNetCore.Mvc;
using NewsSite.Data;
using NewsSite.Data.interfaces;
using NewsSite.Data.Models;
using NewsSite.ViewModels;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace NewsSite.Controllers
{
    public class AddController : Controller
    {

        private readonly ArtRepository artRepository;

        public AddController(ArtRepository artRepository)
        {
            this.artRepository = artRepository;
        }
        public ViewResult Add()
        {
            var model = artRepository.GetArt();
            return View(model) ;
        }

        public IActionResult EditNews(Guid id)
        {
            News model = id == default ? new News() : artRepository.GetNewsById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditNews(News model)
        {
            if (ModelState.IsValid)
            {
                artRepository.SaveNews(model);
                return RedirectToAction("Add");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteNews(Guid id)
        {
            
            artRepository.DeleteArticle(new News { id = id });
            return RedirectToAction("Add");
        }

        public ViewResult Views()
        {
            return View();
        }

    }
}
