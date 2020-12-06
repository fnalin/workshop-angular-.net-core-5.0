using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FN.WorkShopNetCoreAngular.Domain.Contracts.Repositories;
using FN.WorkShopNetCoreAngular.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FN.WorkShopNetCoreAngular.Tests.Domain.Repositories
{
    [TestClass]
    public class ClienteRepoTest
    {
        [TestMethod]
        public async Task DadoUmRepositorioClienteOMetodoGetDeveraRetornarTodos()
        {
            IClienteRepository cliRepo = new ClienteFakeRepository();

            var data = await cliRepo.GetAsync();

            Assert.AreEqual(3, data.Count());
        }
    }

    class ClienteFakeRepository : IClienteRepository
    {

        private IEnumerable<Cliente> _clientes = new List<Cliente>{
                new Cliente (1, "Nome Cli 1", "SobreNome Cli 1", 42, WorkShopNetCoreAngular.Domain.Enums.Sexo.Feminino ) {},
                new Cliente (2, "Nome Cli 2", "SobreNome Cli 2", 41, WorkShopNetCoreAngular.Domain.Enums.Sexo.Masculino ) {},
                new Cliente (3, "Nome Cli 3", "SobreNome Cli 3", 19, WorkShopNetCoreAngular.Domain.Enums.Sexo.Masculino ) {},
            };

        public void Add(Cliente entity)
        {
            throw new System.NotImplementedException();
        }

        public void Del(Cliente entity)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Cliente entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Cliente>> GetAsync()
        {

            return await Task.Run(() => _clientes.ToList());

        }
    }
}