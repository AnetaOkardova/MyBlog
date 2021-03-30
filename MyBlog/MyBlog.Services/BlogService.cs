using MyBlog.Common.Exceptions;
using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Repository.Interfaces;
using MyBlog.Services.DtoModels;
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
            var blog = _blogsRepository.GetById(id);
            if (blog == null)
            {
                throw new NotFoundException($"There is no blog with id {id}");
            }

            return blog;
        }
        public List<Blog> GetBlogsByTitle(string title)
        {
            if (title == null)
            {
                return GetAllBlogs();
            }
            else
            {
                var blogs = _blogsRepository.GetByTitle(title);

                if (blogs.Count == 0)
                {
                    throw new NotFoundException($"There is no blog containing {title} in it's title");
                }
                return blogs;
            }
        }

        public void CreateBlog(Blog blog)
        {
            _blogsRepository.Add(blog);
        }
        public StatusModel Delete(int id)
        {
            var response = new StatusModel();

            var blog = _blogsRepository.GetById(id);
            if (blog == null)
            {
                response.Success = false;
                response.Message = $"The blog with ID {id} is not found.";
            }
            else
            {
                response.Success = true;
                response.Message = $"The blog with ID {id} has been successfully deleted.";

                _blogsRepository.Delete(blog);
            }
            return response;
        }
        public StatusModel Update(Blog blog)
        {
            var response = new StatusModel();
            var blogToUpdate = _blogsRepository.GetById(blog.Id);

            if (blogToUpdate == null)
            {
                response.Success = false;
                response.Message = $"The blog with ID {blog.Id} is not found.";
            }
            else
            {
                blogToUpdate.Title = blog.Title;
                blogToUpdate.ImageURL = blog.ImageURL;
                blogToUpdate.ShortDescription = blog.ShortDescription;
                blogToUpdate.Text = blog.Text;
                blogToUpdate.TravelDate = blog.TravelDate;
                blogToUpdate.Author = blog.Author;

                _blogsRepository.Update(blogToUpdate);

                response.Success = true;
                response.Message = $"The blog with ID {blog.Id} has been successfully updated.";
            }
            return response;
        }
    }
}
