using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            var blog1 = new Blog()
            {
                Id = 1,
                Title = "Exploring Rome",
                Author = "Aneta",
                TravelDate = new DateTime(2019, 05, 24),
                EntryDate = DateTime.Now,
                ImageURL = "https://lp-cms-production.imgix.net/2019-06/GettyImages-543346435_super.jpg?auto=format&fit=crop&ixlib=react-8.6.4&h=520&w=1312",
                ShortDescription = "When in Rome...",
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus ac neque felis. Nam hendrerit nulla eget molestie ullamcorper. " +
                "Quisque commodo tortor quis volutpat efficitur. Praesent tincidunt gravida felis euismod euismod. Donec non elit vel augue molestie semper. " +
                "Aliquam auctor mauris neque, in sodales leo convallis vitae. Nunc semper sem enim, ac eleifend enim accumsan eget. Nulla pharetra libero vitae hendrerit hendrerit. " +
                "Nunc lobortis laoreet diam, quis facilisis enim cursus quis. Pellentesque ut iaculis leo, in condimentum nibh. Nullam in nunc vel tortor efficitur lacinia a et eros. " +
                "Aenean nec massa consectetur, facilisis arcu in, sagittis arcu. Phasellus pellentesque feugiat est, quis lacinia dolor maximus vel."+
                "Donec quis tortor orci.Fusce pretium luctus lacus.Curabitur posuere tempus dui, "+
                "vel dignissim odio sagittis ac.Aenean molestie tellus vitae ullamcorper malesuada.Curabitur bibendum volutpat est quis faucibus.Maecenas ultrices viverra tincidunt.Sed pulvinar ipsum et tellus imperdiet vulputate.Nullam sit amet ornare justo, " +
                "eu pretium erat.Fusce consectetur dui vitae sem aliquet," +
                "eu posuere nunc auctor.Cras luctus nulla justo," +
                "sit amet laoreet mi interdum eu.Curabitur lorem massa," +
                "congue eget dolor sed," +
                "condimentum volutpat enim.Duis ut enim vitae leo sagittis ultrices vitae et sapien.Quisque commodo consequat ipsum ut consequat." 
            };
            var blog2 = new Blog()
            {
                Id = 2,
                Title = "Exploring Florence",
                Author = "Aneta",
                TravelDate = new DateTime(2019, 05, 30),
                EntryDate = DateTime.Now,
                ImageURL = "https://dreamofitaly.com/wp-content/uploads/2015/05/Florence-use-church-dome-in-square.jpg",
                ShortDescription = "When in Florence..",
                Text = "STh, Sth, Sth"
            };
            var blogs = new List<Blog> { blog1, blog2 };
            return View(blogs);
        }
    }
}
