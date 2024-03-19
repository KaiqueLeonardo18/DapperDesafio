using System;
using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;

namespace BlogDesafio.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Tittle { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; }
    }
}