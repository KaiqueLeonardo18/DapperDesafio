using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaDataAccess.Models
{
    public class Courses
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Url { get; set; }
        public int Level { get; set; }
        public int DurationMinute { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int Active { get; set; }
        public int Free { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public string Tags { get; set; }
    }
}