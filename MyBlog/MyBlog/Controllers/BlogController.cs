using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _service { get; set; }
        public BlogController(IBlogService service)
        {
            _service = service;
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _service.CreateBlog(blog);
                return RedirectToAction("Overview");
            }
            return View(blog);
        }
    }
}


