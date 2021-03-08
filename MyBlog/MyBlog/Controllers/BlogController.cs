using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var romeImg1 = "C:\\Users\\Aneta\\Desktop\\PhotosMyBlog\\Rome1.jpg";
            var romeImg2 = "C:\\Users\\Aneta\\Desktop\\PhotosMyBlog\\Rome2.jpg";

            var blog1 = new Blog()
            {
                Id = 1,
                Title = "Exploring Rome",
                TravelDate = new DateTime(2019, 05, 24),
                EntryDate = DateTime.Now,
                ImageURLs = new List<string> { romeImg1, romeImg2},
                Description = "When in Rome..."
            };

            return View(blog1);
        }
    }
}
