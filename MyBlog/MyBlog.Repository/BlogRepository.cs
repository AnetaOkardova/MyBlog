using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogsRepository
    {
        public BlogRepository(MyBlogsDbContext context) : base (context)
        {
            _context = context;
        }
       

        public List<Blog> GetByTitle(string title)
        {
            return _context.Blogs.Where(x => x.Title.Contains(title)).ToList();
        }
    }
}
