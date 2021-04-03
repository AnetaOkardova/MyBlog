using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        List<T> GetAll();
        T GetById(int entityId);
    }
}
