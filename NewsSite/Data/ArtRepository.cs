using Microsoft.EntityFrameworkCore;
using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data
{
    public class ArtRepository
    {
        private readonly AppDbContent context;
        public ArtRepository(AppDbContent context)
        {
            this.context = context;
        }

        public IQueryable<News> GetArt()
        {
            return context.News.OrderBy(x => x.id);
        }
        public News GetNewsById(Guid id)
        {
            return context.News.Single(x => x.id == id);

        }

        public Guid SaveNews(News entity)
        {
            if (entity.id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity.id;

        }

        public void DeleteArticle(News entity)
        {
            context.News.Remove(entity);
            context.SaveChanges();
        }
    }
}
