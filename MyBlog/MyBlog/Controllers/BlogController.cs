using Microsoft.AspNetCore.Mvc;
using MyBlog.Common.Exceptions;
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
        public IActionResult Overview(string title)
        {
            var blogs = _service.GetBlogsByTitle(title);
            return View(blogs);
        }
        public IActionResult ManageOverview()
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
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("ManageOverview");
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var blog = _service.GetBlogById(id);
            try
            {
                return View(blog);
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }

        }
        [HttpPost]
        public IActionResult Update(Blog blog)
        {
            try
            {
                _service.Update(blog);
                return RedirectToAction("ManageOverview");
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
        }
    }
}


