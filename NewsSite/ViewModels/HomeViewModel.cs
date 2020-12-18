using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<News> someNews
        {
            set; get;
        }

    }
}
