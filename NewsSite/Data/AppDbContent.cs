using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsSite.Data.Models;

namespace NewsSite.Data
{
    public class AppDbContent : DbContext
    {

        public AppDbContent(DbContextOptions<AppDbContent> options): base(options)
        {
        }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Category { get; set; }


    }
}
