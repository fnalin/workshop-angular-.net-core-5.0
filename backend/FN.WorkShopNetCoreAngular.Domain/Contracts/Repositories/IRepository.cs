using System.Collections.Generic;
using System.Threading.Tasks;
using FN.WorkShopNetCoreAngular.Domain.Entities;

namespace FN.WorkShopNetCoreAngular.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {

        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();

        void Add(TEntity entity);
        void Edit(TEntity entity);
        void Del(TEntity entity);

    }
}