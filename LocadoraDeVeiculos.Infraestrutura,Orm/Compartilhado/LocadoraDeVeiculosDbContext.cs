using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.ModuloAutenticacao;
using LocadoraDeVeiculos.ModuloFuncionario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infraestrutura_Orm.Compartilhado
{
    public class OrganizaMedDbContext(DbContextOptions options, ITenantProvider? tenantProvider = null)
        : IdentityDbContext<Usuario, Cargo, Guid>(options), IContextoPersistencia
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (tenantProvider is not null)
            {
                modelBuilder.Entity<Funcionario>().HasQueryFilter(f => f.UsuarioId == tenantProvider.UsuarioId);

            }



            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> GravarAsync()
        {
            return await SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }

            await Task.CompletedTask;
        }
    }
}
