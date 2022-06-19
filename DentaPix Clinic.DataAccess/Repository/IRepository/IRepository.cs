﻿using System.Linq.Expressions;

namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T - Doctor
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        IEnumerable<T> GetAll(string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);




    }
}
