using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoDeVeiculos
{
    public abstract class GrupoVeiculoErrorResults

    {
        public static Error NomeDuplicadoError(string nome)
        {
            return new Error("Nome duplicado")
                .CausedBy($"Um Veiculo com o Nome '{nome}' já foi cadastrado")
                .WithMetadata("ErrorType", "BadRequest");
        }

    }

}
