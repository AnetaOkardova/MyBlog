using Microsoft.AspNetCore.Http;
using MyBlog.Models;
using MyBlog.Services.DtoModels;

using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IAuthService
    {
        StatusModel SignIn(string username, string password, bool IsPersistent, HttpContext httpContext);
        void SignOut(HttpContext httpContext);
        StatusModel SignUp(User domainModel);
    }
}
