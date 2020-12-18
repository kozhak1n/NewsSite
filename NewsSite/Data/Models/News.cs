using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Data.Models
{
    public class News
    {
        public Guid id { set; get; }
        public string name { set; get; }
        public string AuthorName { set; get; }
        public string Desc { set; get; }
        public string img { set; get; }
        public bool isFavourite { set; get; }
        public string date { set; get; }
        public int categoryID { set; get; }

        public virtual Category Category { set; get; }


    }
}
