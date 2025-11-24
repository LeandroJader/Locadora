using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos.commands.SelecionarTodos
{
    public record SelecionarGrupoVeiculosDto(Guid Id, string Nome);

    public record SelecionarGrupoVeiculosResponse
    {
        public required int QuantidadeRegistros { get; init; }
        public required IEnumerable<SelecionarGrupoVeiculosDto> Registros { get; init; }
    }
}
