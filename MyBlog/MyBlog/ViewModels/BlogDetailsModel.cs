using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class BlogDetailsModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string ImageURL { get; set; }
        public string Text { get; set; }
    }
}
