using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBlog.Repository
{
    public class BlogRepository : IBlogsRepository
    {
        private MyBlogsDbContext _context { get; set; }
        public BlogRepository(MyBlogsDbContext context)
        {
            _context = context;
        }
        public void Add(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }
        public void Delete(Blog blog)
        {
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }
        public void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }
        public List<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }

        public Blog GetById(int id)
        {
            return _context.Blogs.FirstOrDefault(x => x.Id == id);
        }

        public List<Blog> GetByTitle(string title)
        {
            return _context.Blogs.Where(x => x.Title.Contains(title)).ToList();
        }
    }
}
