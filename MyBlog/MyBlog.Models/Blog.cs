using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime TravelDate { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        public DateTime DateModified { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
