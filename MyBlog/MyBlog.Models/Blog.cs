using System;

namespace MyBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime TravelDate { get; set; }
        public string ImageURL { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
    }
}
