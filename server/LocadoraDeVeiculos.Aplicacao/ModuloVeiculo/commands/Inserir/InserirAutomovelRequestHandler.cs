using FluentResults;
using FluentValidation;
using LocadoraDeVeiculos.Aplicacao.Compartilhado;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.commands.inserir;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutenticacao;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloVeiculo.Commands.Inserir
{
    internal class InserirAutomovelHandler : IRequestHandler<InserirAutomovelRequest, Result<InseririAutomovelResponse>>
    {
        private readonly IContextoPersistencia _contexto;
        private readonly IRepositorioAutomovel _repositorio;
        private readonly ITenantProvider _tenantProvider;
        private readonly IValidator<Automovel> _validador;

        public InserirAutomovelHandler(
            IContextoPersistencia contexto,
            IRepositorioAutomovel repositorio,
            ITenantProvider tenantProvider,
            IValidator<Automovel> validador)
        {
            _contexto = contexto;
            _repositorio = repositorio;
            _tenantProvider = tenantProvider;
            _validador = validador;
        }

        public async Task<Result<InseririAutomovelResponse>> Handle(
            InserirAutomovelRequest request,
            CancellationToken cancellationToken)
        {
            var veiculo = new Automovel(
                request.placa,
                request.marca,
                request.cor,
                request.modelo,
                request.tipoCombustivel,
                request.capacidadeTanque,
                request.ano,
                request.foto,
                request.GrupoVeiculosId)
            {
                UsuarioId = _tenantProvider.UsuarioId.GetValueOrDefault()
            };

            // Validação FluentValidation
            var resultadoValidacao = await _validador.ValidateAsync(veiculo, cancellationToken);
            if (!resultadoValidacao.IsValid)
            {
                var erros = resultadoValidacao.Errors.Select(e => e.ErrorMessage).ToList();
                return Result.Fail(erros.Select(msg => new Error(msg)));
            }

            // Verificar duplicidade de placa
            var veiculosRegistrados = await _repositorio.SelecionarTodosAsync();
            if (veiculosRegistrados.Any(v => v.Placa.Equals(veiculo.Placa, System.StringComparison.OrdinalIgnoreCase)))
            {
                return Result.Fail(AutomovelErrorResults.PlacaDuplicada(veiculo.Placa));
            }

            try
            {
                await _repositorio.InserirAsync(veiculo);
                await _contexto.GravarAsync();

                return Result.Ok(new InseririAutomovelResponse(veiculo.Id));
            }
            catch (System.Exception ex)
            {
                await _contexto.RollbackAsync();
                return Result.Fail(ErrorResults.InternalServerError(ex));
            }
        }
    }
}
