﻿using System.Linq.Expressions;

namespace DentaPix_Clinic.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);




    }
}
