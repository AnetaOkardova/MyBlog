using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repository.Interfaces
{
    public interface IBlogsRepository
    {
        List<Blog> GetAll();

        Blog GetById(int id);
        void Add(Blog blog);
    }
}
