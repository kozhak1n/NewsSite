using Microsoft.EntityFrameworkCore;
using NewsSite.Data.interfaces;
using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data.Repository
{
    public class NewsRepository : IAllNews
    {
        private readonly AppDbContent appDbContent;
        public NewsRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<News> News => appDbContent.News.Include(c => c.Category);

        public IEnumerable<News> GetSomeNews => appDbContent.News.Where(p => p.isFavourite).Include(c => c.Category);

        public News getObjNews(Guid newsID) => appDbContent.News.FirstOrDefault(p => p.id == newsID);
        
    }
}
