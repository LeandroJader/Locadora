using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraDeVeiculos.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infraestrutura.Orm.ModuloGrupoVeiculo
{
    public class RepositorioGrupoVeiculoEmOrm : RepositorioBase<GrupoDeVeiculos>, IRepositorioGrupoDeVeiculos
    {
        public RepositorioGrupoVeiculoEmOrm(IContextoPersistencia context) : base(context)
        {
        }

        public override async Task<GrupoDeVeiculos?> SelecionarPorIdAsync(Guid id)
        {
            return await registros.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
