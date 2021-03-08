using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime TravelDate { get; set; }
        public List<string> ImageURLs { get; set; }
        public string Description { get; set; }
        

    }
}
