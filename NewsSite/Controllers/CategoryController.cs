using Microsoft.AspNetCore.Mvc;
using NewsSite.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    public class CategoryController: Controller
    {
        private readonly INewsCategory allCategory;

        public CategoryController(INewsCategory icategory)
        {
            allCategory = icategory;
        }

        public ViewResult Cat()
        {
            return View(allCategory.AllCategories);
        }
    }
}
