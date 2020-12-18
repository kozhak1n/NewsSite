using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NewsSite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data
{
    public class DbObj
    {
        public static void Initial(AppDbContent content)
        {
            
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.News.Any())
            {
                content.AddRange(
                    new News { name = "Na'Vi", AuthorName = "Руслан", Desc = "Na'Vi выиграли турнир по CS:GO", date = "10.12.2020", isFavourite = true, img = "/img/default.jpg", Category = Categories["CS:GO"] },
                    new News { name = "VirtusPro", AuthorName = "Михаил", Desc = "VirtusPro выиграли турнир по Dota 2", date = "10.12.2020", isFavourite = true, img = "/img/default.jpg", Category = Categories["Dota 2"] }
                    );

                    }

            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category
                    {
                        CategoryName = "Dota 2", desc = "Новости из мира Dota 2"
                    },
                        new Category
                    {
                        CategoryName = "CS:GO", desc = "Новости из мира CS:GO"
                    }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }

        }
    }
}
