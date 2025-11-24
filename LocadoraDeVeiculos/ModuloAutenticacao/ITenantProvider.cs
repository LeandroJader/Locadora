namespace LocadoraDeVeiculos.ModuloAutenticacao;
public interface ITenantProvider
{
    Guid? UsuarioId { get; }
}

