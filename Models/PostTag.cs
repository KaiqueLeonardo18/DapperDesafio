using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace BlogDesafio.Models
{
    [Table("PostTag")]
    public class PostTag
    {
        [Key]
        public int PostId { get; set; }
        [Key]
        public int TagId { get; set; }
    }
}