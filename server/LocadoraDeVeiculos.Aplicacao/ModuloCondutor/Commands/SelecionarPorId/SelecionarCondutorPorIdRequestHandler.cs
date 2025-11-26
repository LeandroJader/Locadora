using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarPorId;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.SelecionarPorId
{
    public class SelecionarCondutorPorIdHandler
        : IRequestHandler<SelecionarCondutorPorIdRequest, Result<SelecionarCondutorPorIdResponse>>
    {
        private readonly IRepositorioCondutor _repositorio;

        public SelecionarCondutorPorIdHandler(IRepositorioCondutor repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Result<SelecionarCondutorPorIdResponse>> Handle(
            SelecionarCondutorPorIdRequest request,
            CancellationToken cancellationToken)
        {
            var condutor = await _repositorio.SelecionarPorIdAsync(request.Id);

            if (condutor is null)
                return Result.Fail(ErrorResults.NotFoundError(request.Id));

            var response = new SelecionarCondutorPorIdResponse(
                condutor.Id,
              condutor.Nome,
              condutor.Cpf,
              condutor.Cnh,
                condutor.ValidadeCnh,
                condutor.Email,
                condutor.Telefone,
                condutor.UsuarioId


            );

            return Result.Ok(response);
        }
    }
}
