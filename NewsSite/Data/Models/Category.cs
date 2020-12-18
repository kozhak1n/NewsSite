using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        public string CategoryName { set; get; }
        public string desc { set; get; }

        public List<News> News { set; get; }

    }
}
