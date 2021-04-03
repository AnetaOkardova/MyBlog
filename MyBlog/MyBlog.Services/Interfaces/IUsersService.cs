using MyBlog.Models;
using MyBlog.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        List<User> GetAllUsers();
        StatusModel ToggleAdminRole(int id);
        StatusModel Delete(int id);
    }
}
