using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IBlogService
    {
        List<Blog> GetAllBlogs();
        List<Blog> GetBlogsByTitle(string title);

        public Blog GetBlogById(int id);
        void CreateBlog(Blog blog);
    }
}
