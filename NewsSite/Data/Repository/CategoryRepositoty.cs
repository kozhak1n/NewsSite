using NewsSite.Data.interfaces;
using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data.Repository
{
    public class CategoryRepositoty : INewsCategory
    {
        private readonly AppDbContent appDbContent;
        public CategoryRepositoty(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories =>appDbContent.Category;
    }
}
