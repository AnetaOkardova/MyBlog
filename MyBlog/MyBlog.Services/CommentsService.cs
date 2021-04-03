using MyBlog.Repository.Interfaces;
using MyBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
    }
}
