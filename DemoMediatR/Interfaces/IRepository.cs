﻿namespace DemoMediatR.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
