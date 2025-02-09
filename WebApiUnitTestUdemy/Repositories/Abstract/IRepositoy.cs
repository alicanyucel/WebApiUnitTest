﻿

namespace WebApiUnitTestUdemy.Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
