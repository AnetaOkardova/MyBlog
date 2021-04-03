using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repository
{
    public class MyBlogsDbContext : DbContext
    {
        public MyBlogsDbContext(DbContextOptions<MyBlogsDbContext> options) : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
