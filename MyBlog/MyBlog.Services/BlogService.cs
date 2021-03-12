using MyBlog.Models;
using MyBlog.Repository;
using System.Collections.Generic;

namespace MyBlog.Services
{
    public class BlogService
    {
        public BlogsRepository _blogsRepository { get; set; }
        public BlogService()
        {
            _blogsRepository = new BlogsRepository();
        }
        public List<Blog> GetAllBlogs()
        {
            return _blogsRepository.GetAll();
        }
        public Blog GetBlogById(int id)
        {
            return _blogsRepository.GetById(id);
        }
    }
}
