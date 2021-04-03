using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using MyBlog.Services.DtoModels;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetById(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = $"There is no user with Id {id}";
            }
            else
            {
                response.Success = true;
                _usersRepository.Delete(user);
            }

            return response;
        }

        public List<User> GetAllUsers()
        {
            var users = _usersRepository.GetAll();
            return users;
        }

        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(Convert.ToInt32(userId));
        }

        public StatusModel ToggleAdminRole(int id)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetById(id);
            if (user == null)
            {
                response.Success = false;
                response.Message = $"There is no user with Id {id}";
            }
            else
            {
                response.Success = true;
                user.IsAdmin = !user.IsAdmin;
                _usersRepository.Update(user);
            }

            return response;
        }
       
    }
}
