using MyBlog.Common.Exceptions;
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

        public void Delete(int id)
        {
            var movie = _blogsRepository.GetById(id);
            if (movie == null)
            {
                throw new NotFoundException($"The blog with ID {id} is not found.");
            }
            else
            {
                _blogsRepository.Delete(movie);
            }
        }

        public void Update(Blog blog)
        {
            if (blog == null)
            {
                throw new NotFoundException($"The blog with ID {blog.Id} is not found.");
            }
            else
            {
                _blogsRepository.Update(blog);
            }
        }
    }
}
