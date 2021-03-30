using MyBlog.Models;
using MyBlog.Services.DtoModels;
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
        StatusModel Delete(int id);
        StatusModel Update(Blog blog);
    }
}
