using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Repository.Interfaces;
using MyBlog.Services.Interfaces;
using System.Collections.Generic;

namespace MyBlog.Services
{
    public class BlogService : IBlogService
    {
        public IBlogsRepository _blogsRepository { get; set; }
        public BlogService(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }
        public List<Blog> GetAllBlogs()
        {
            return _blogsRepository.GetAll();
        }
        public Blog GetBlogById(int id)
        {
            return _blogsRepository.GetById(id);
        }
        public void CreateBlog(Blog blog)
        {
            _blogsRepository.Add(blog);
        }

        public List<Blog> GetBlogsByTitle(string title)
        {
            if (title == null)
            {
                return _blogsRepository.GetAll();
            }
            else
            {
                return _blogsRepository.GetByTitle(title);
            }
        }
    }
}
