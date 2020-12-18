using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data.interfaces
{
    interface IAddNews
    {
        IEnumerable<News> News { get; }
    }
}
