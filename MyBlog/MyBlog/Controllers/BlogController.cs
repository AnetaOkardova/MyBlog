using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Common.Exceptions;
using MyBlog.Mappings;
using MyBlog.Models;
using MyBlog.Services;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;
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
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            try
            {
                var blogs = _service.GetBlogsByTitle(title);
                return View(blogs);
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        public IActionResult ManageOverview(string successMessage, string errorMessage)
        {
            try
            {
                var blogs = _service.GetAllBlogs();
                if (blogs.Count == 0)
                {
                    ViewBag.Message = $"There are no blogs to show at this time.";
                }
                ViewBag.SuccessMessage = successMessage;
                ViewBag.ErrorMessage = errorMessage;
                return View(blogs);
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateBlogModel blogModel)
        {
            var domainModel = blogModel.ToModel();

            if (ModelState.IsValid)
            {
                _service.CreateBlog(domainModel);
                return RedirectToAction("Overview");
            }
            return View(blogModel);
        }
        public IActionResult Delete(int id)
        {
            var response = _service.Delete(id);
            if (response.Success)
            {
                return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
            }
            else
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
            }

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var blog = _service.GetBlogById(id);
                return View(blog.ToUpdateBlogModel());
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [HttpPost]
        public IActionResult Update(UpdateBlogModel blogModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = _service.Update(blogModel.ToModel());
                    if (response.Success)
                    {
                        return RedirectToAction("ManageOverview", new { SuccessMessage = response.Message });
                    }
                    else
                    {
                        return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                    }
                }

                return View(blogModel);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var blog = _service.GetBlogById(id);
                if (blog == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(blog.ToBlogDetailsModel());
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ActionNotSuccessful", "Info", new { Message = ex.Message });
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorNotFound", "Info");
            }
        }
    }
}


