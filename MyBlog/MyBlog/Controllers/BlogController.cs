using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private BlogService _service { get; set; }
        public BlogController()
        {
            _service = new BlogService();
        }
        public IActionResult Details(int id)
        {
            var selectedBlog = _service.GetBlogById(id);
            if (selectedBlog == null)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
            return View(selectedBlog);
        }
        public IActionResult Overview()
        {
            var blogs = _service.GetAllBlogs();
            return View(blogs);
        }
    }
}


