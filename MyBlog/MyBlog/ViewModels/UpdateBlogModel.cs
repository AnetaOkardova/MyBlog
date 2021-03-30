using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.ViewModels
{
    public class UpdateBlogModel
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
    }
}
