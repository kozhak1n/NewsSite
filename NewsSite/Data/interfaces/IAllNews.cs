using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data.interfaces
{
    public interface IAllNews
    {
        IEnumerable<News> News { get; }
        IEnumerable<News> GetSomeNews { get;}
        News getObjNews(Guid newsID);
    }
}
