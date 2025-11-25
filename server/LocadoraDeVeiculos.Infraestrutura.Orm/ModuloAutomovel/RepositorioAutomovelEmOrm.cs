using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infraestrutura.Orm.ModuloAutomovel
{
    public class RepositorioAutomovelEmOrm : RepositorioBase<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(IContextoPersistencia contexto) : base(contexto)
        {
        }

        public override async Task<Automovel?> SelecionarPorIdAsync(Guid id)
        {
            return await registros
                .Include(a => a.GrupoVeiculos) 
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<List<Automovel>> SelecionarTodosAsync()
        {
            return await registros
                .Include(a => a.GrupoVeiculos)
                .ToListAsync();
        }

        public async Task<bool> ExistePlacaAsync(string placa)
        {
            return await registros.AnyAsync(a => a.Placa == placa);
        }
    }
}
