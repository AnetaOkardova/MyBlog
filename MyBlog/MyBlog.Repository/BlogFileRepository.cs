using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyBlog.Repository
{
    public class BlogFileRepository : IBlogsRepository
    {
         public List<Blog> Blogs { get; set; }
        const string Path = "Blogs.txt";


        public BlogFileRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }
            var result = File.ReadAllText(Path);
            var deserializedList = JsonConvert.DeserializeObject<List<Blog>>(result);
            Blogs = deserializedList;
        }
        public List<Blog> GetAll()
        {
            return Blogs;
        }

        public Blog GetById(int id)
        {
            return Blogs.FirstOrDefault(x=> x.Id == id);
        }
        public void Add(Blog blog)
        {
            blog.Id = GenerateId();
            blog.EntryDate = DateTime.Now;
            Blogs.Add(blog);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;
            if (Blogs.Any())
            {
                maxId = Blogs.Max(x => x.Id);
            }
            return maxId + 1;
        }
        private void SaveChanges()
        {
            var serilized = JsonConvert.SerializeObject(Blogs);
            File.WriteAllText(Path, serilized);
        }
    }
}
