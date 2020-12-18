using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class NewsListViewModel
    {
        internal string currCategory;

        public IEnumerable<News> AllNews { get; set; }

        public string CurrCategory { get; set; }
    }
}
