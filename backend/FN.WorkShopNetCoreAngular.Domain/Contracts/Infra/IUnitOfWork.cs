using System.Threading.Tasks;

namespace FN.WorkShopNetCoreAngular.Domain.Contracts.Infra
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RollBackAsync();

    }
}