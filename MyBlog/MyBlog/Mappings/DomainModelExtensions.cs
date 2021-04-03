using MyBlog.Models;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Mappings
{
    public static class DomainModelExtensions
    {
        public static UpdateBlogModel ToUpdateBlogModel(this Blog blog)
        {
            return new UpdateBlogModel()
            {
                Id = blog.Id,
                Title = blog.Title,
                Author = blog.Author,
                TravelDate = blog.TravelDate,
                ImageURL = blog.ImageURL,
                ShortDescription = blog.ShortDescription,
                Text = blog.Text
            };
        }
        public static CreateBlogModel ToCreateBlogModel(this Blog blog)
        {
            return new CreateBlogModel()
            {
                Title = blog.Title,
                Author = blog.Author,
                TravelDate = blog.TravelDate,
                ImageURL = blog.ImageURL,
                ShortDescription = blog.ShortDescription,
                Text = blog.Text
            };
        }

        public static BlogDetailsModel ToBlogDetailsModel(this Blog blog)
        {
            return new BlogDetailsModel()
            {
                Title = blog.Title,
                Author = blog.Author,
                TravelDate = blog.TravelDate,
                ImageURL = blog.ImageURL,
                EntryDate = blog.EntryDate,
                Text = blog.Text
            };
        }

        public static UserDetailsModel ToUserDetailsModel(this User user)
        {
            return new UserDetailsModel()
            {
                Name = user.Name,
                Lastname = user.Lastname,
                Address = user.Address,
                Email = user.Email,
                Username = user.Username
            };
        }
        public static ManageOverviewUsersModel ToManageOverviewUsersModel(this User user)
        {
            return new ManageOverviewUsersModel()
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
