using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarTodos;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Mappers
{
    public static class CondutorMapper
    {
        public static SelecionarCondutorDto ToDto(this Condutor condutor)
        {
            return new SelecionarCondutorDto(
                condutor.Id,
                condutor.Nome,
                condutor.Cpf,
                condutor.Email
            );
        }

        public static IEnumerable<SelecionarCondutorDto> ToDto(this IEnumerable<Condutor> condutores)
        {
            return condutores.Select(c => c.ToDto()).ToList();
        }
    }
}
