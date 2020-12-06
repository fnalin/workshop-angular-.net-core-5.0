using System;
using System.Threading.Tasks;
using FN.WorkShopNetCoreAngular.Domain.Contracts.Infra;

namespace FN.WorkShopNetCoreAngular.Data.EF
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkShopAngularNetCoreDataContext _ctx;
        public UnitOfWork(WorkShopAngularNetCoreDataContext ctx) => _ctx = ctx;

        public async Task CommitAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public Task RollBackAsync()
        {
            throw new NotImplementedException();
        }
    }
}