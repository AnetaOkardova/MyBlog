using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repository
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(MyBlogsDbContext context) : base(context)
        {
        }
    }
}
