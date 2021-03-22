using MyBlog.Models;
using MyBlog.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyBlog.Repository
{
    public class BlogSqlRepository : IBlogsRepository
    {
        public void Add(Blog blog)
        {
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyBlogsSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = @"insert into blogs (Title, Author, EntryDate, TravelDate, ImageURL, ShortDescription, Text) 
                            values (@Title, @Author, @EntryDate, @TravelDate, @ImageURL, @ShortDescription, @Text)";
                var cmd = new SqlCommand(query, cnn);
                //var time = DateTime.Now;
                cmd.Parameters.AddWithValue("@Title", blog.Title);
                cmd.Parameters.AddWithValue("@Author", blog.Author);
                cmd.Parameters.AddWithValue("@EntryDate", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@TravelDate", blog.TravelDate);
                cmd.Parameters.AddWithValue("@ImageURL", blog.ImageURL);
                cmd.Parameters.AddWithValue("@ShortDescription", blog.ShortDescription);
                cmd.Parameters.AddWithValue("@Text", blog.Text);

                var reader = cmd.ExecuteNonQuery();

            };
        }

        public void Delete(Blog movie)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            var blogs = new List<Blog>();
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyBlogsSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = "select * from blogs";
                var cmd = new SqlCommand(query, cnn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var blog = new Blog();

                    blog.Id = reader.GetInt32(0);
                    blog.Title = reader.GetString(1);
                    blog.Author = reader.GetString(2);
                    blog.EntryDate = reader.GetDateTime(3);
                    blog.TravelDate = reader.GetDateTime(4);
                    blog.ImageURL = reader.GetString(5);
                    blog.ShortDescription = reader.GetString(5);
                    blog.Text = reader.GetString(5);

                    blogs.Add(blog);
                }

                return blogs;
            }
        }
        public Blog GetById(int id)
        {
            Blog blog = null;
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyMoviesSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = $"select * from blogs where id = @Id";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    blog = new Blog();
                    blog.Id = reader.GetInt32(0);
                    blog.Title = reader.GetString(1);
                    blog.Author = reader.GetString(2);
                    blog.EntryDate = reader.GetDateTime(3);
                    blog.TravelDate = reader.GetDateTime(4);
                    blog.ImageURL = reader.GetString(5);
                    blog.ShortDescription = reader.GetString(5);
                    blog.Text = reader.GetString(5);
                }

                return blog;
            }
        }

        public List<Blog> GetByTitle(string title)
        {
            var blogs = new List<Blog>();
            using (var cnn = new SqlConnection("Server=(localDb)\\MSSQLLocalDB;Database= MyBlogsSql; Trusted_Connection=True;"))
            {
                cnn.Open();

                var query = "select * from blogs where title like @Title";
                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", $"%{title}%");
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var blog = new Blog();

                    blog.Id = reader.GetInt32(0);
                    blog.Title = reader.GetString(1);
                    blog.Author = reader.GetString(2);
                    blog.EntryDate = reader.GetDateTime(3);
                    blog.TravelDate = reader.GetDateTime(4);
                    blog.ImageURL = reader.GetString(5);
                    blog.ShortDescription = reader.GetString(5);
                    blog.Text = reader.GetString(5);

                    blogs.Add(blog);
                }

                return blogs;
            }
        }

        public void Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
