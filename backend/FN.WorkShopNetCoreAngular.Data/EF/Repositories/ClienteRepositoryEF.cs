using FN.WorkShopNetCoreAngular.Domain.Contracts.Repositories;
using FN.WorkShopNetCoreAngular.Domain.Entities;

namespace FN.WorkShopNetCoreAngular.Data.EF.Repositories
{
    public class CLienteRepositoryEF : RepositoryEF<Cliente>, IClienteRepository
    {
        public CLienteRepositoryEF(WorkShopAngularNetCoreDataContext ctx) : base(ctx)
        { }
    }
}