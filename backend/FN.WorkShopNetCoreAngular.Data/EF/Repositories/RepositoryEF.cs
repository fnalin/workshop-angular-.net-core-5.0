using System.Collections.Generic;
using System.Threading.Tasks;
using FN.WorkShopNetCoreAngular.Domain.Contracts.Repositories;
using FN.WorkShopNetCoreAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FN.WorkShopNetCoreAngular.Data.EF.Repositories
{
    public class RepositoryEF<TEntity> : IRepository<TEntity> where TEntity : Entity
    {

        protected readonly WorkShopAngularNetCoreDataContext _ctx;
        private readonly DbSet<TEntity> _db;

        public RepositoryEF(WorkShopAngularNetCoreDataContext ctx)
        {
            _ctx = ctx;
            _db = ctx.Set<TEntity>();
        }
        
        public async Task<TEntity> GetAsync(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
        }

        public void Edit(TEntity entity)
        {
            _db.Update(entity);
        }

        public void Del(TEntity entity)
        {
            _db.Remove(entity);
        }
        
    }
}