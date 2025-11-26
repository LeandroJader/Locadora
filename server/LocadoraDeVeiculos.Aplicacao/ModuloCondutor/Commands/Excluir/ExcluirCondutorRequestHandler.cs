using FluentResults;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Excluir;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCondutor.Commands.Excluir
{
    public class ExcluirCondutorHandler : IRequestHandler<ExcluirCondutorRequest, Result<ExcluirCondutorResponse>>
    {
        private readonly IContextoPersistencia _contexto;
        private readonly IRepositorioCondutor _repositorio;

        public ExcluirCondutorHandler(IContextoPersistencia contexto, IRepositorioCondutor repositorio)
        {
            _contexto = contexto;
            _repositorio = repositorio;
        }

        public async Task<Result<ExcluirCondutorResponse>> Handle(ExcluirCondutorRequest request, CancellationToken cancellationToken)
        {
            var condutor = await _repositorio.SelecionarPorIdAsync(request.Id);

            if (condutor is null)
                return Result.Fail(CondutorErrorResults.CondutorInexistente(request.Id));

            try
            {
                await _repositorio.ExcluirAsync(condutor);
                await _contexto.GravarAsync();

                return Result.Ok(new ExcluirCondutorResponse(condutor.Id));
            }
            catch (System.Exception ex)
            {
                await _contexto.RollbackAsync();
                return Result.Fail(ErrorResults.InternalServerError(ex));
            }
        }
    }
}
