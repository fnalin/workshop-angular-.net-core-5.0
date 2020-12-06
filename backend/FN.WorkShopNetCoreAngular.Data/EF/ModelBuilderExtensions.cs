using Microsoft.EntityFrameworkCore;

namespace FN.WorkShopNetCoreAngular.Data.EF
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Cliente>().HasData(
                new Domain.Entities.Cliente(1, "Raphael Akyu", "Nalin", 21, Domain.Enums.Sexo.Masculino),
                new Domain.Entities.Cliente(2, "Fabiano Alberto", "Nalin", 41, Domain.Enums.Sexo.Masculino),
                new Domain.Entities.Cliente(3, "Priscila", "Mitui", 42, Domain.Enums.Sexo.Feminino)
            );
        }

    }
}