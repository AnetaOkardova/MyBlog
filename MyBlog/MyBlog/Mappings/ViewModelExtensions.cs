using MyBlog.Models;
using MyBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Mappings
{
    public static class ViewModelExtensions
    {
        public static Blog ToModel(this UpdateBlogModel blog)
        {
            return new Blog()
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
        public static Blog ToModel(this CreateBlogModel blog)
        {
            return new Blog()
            {
                Title = blog.Title,
                Author = blog.Author,
                TravelDate = blog.TravelDate,
                ImageURL = blog.ImageURL,
                ShortDescription = blog.ShortDescription,
                Text = blog.Text
            };
        }

        public static Blog ToModel(this BlogDetailsModel blog)
        {
            return new Blog()
            {
                Title = blog.Title,
                Author = blog.Author,
                TravelDate = blog.TravelDate,
                ImageURL = blog.ImageURL,
                EntryDate = blog.EntryDate,
                Text = blog.Text
            };
        }

        public static User ToModel(this SignInModel signInModel)
        {
            return new User()
            {
                Username = signInModel.Username,
                Password = signInModel.Password,
            };
        }
        public static User ToModel(this SignUpModel signUpModel)
        {
            return new User()
            {
                Username = signUpModel.Username,
                Password = signUpModel.Password,
                Name = signUpModel.Name,
                Lastname = signUpModel.Lastname,
                Email = signUpModel.Email,
                Address = signUpModel.Address,
            };
        }
        public static User ToModel(this ManageOverviewUsersModel users)
        {
            return new User()
            {
                Id = users.Id,
                Username = users.Username,
                IsAdmin = users.IsAdmin
            };
        }
    }
}
