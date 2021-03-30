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
    }
}
