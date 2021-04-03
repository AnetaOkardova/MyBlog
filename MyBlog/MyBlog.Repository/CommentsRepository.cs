using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repository
{
    public class CommentsRepository : BaseRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(MyBlogsDbContext context) : base(context)
        {
        }
    }
}
