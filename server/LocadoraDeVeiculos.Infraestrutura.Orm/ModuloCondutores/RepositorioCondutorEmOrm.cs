using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infraestrutura.Orm.ModuloCondutor
{
    public class RepositorioCondutorEmOrm : RepositorioBase<Condutor>, IRepositorioCondutor
    {
        public RepositorioCondutorEmOrm(IContextoPersistencia contexto) : base(contexto)
        {
        }

        public override async Task<Condutor?> SelecionarPorIdAsync(Guid id)
        {
            return await registros
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public override async Task<List<Condutor>> SelecionarTodosAsync()
        {
            return await registros
                .ToListAsync();
        }

        public async Task<bool> ExisteCpfAsync(string cpf)
        {
            return await registros.AnyAsync(c => c.Cpf == cpf);
        }

        public async Task<bool> ExisteCnhAsync(string cnh)
        {
            return await registros.AnyAsync(c => c.Cnh == cnh);
        }
    }
}
