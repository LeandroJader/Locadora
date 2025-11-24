namespace LocadoraDeVeiculos.ModuloAutenticacao;

public interface ITokenProvider
{
    IAccessToken GerarTokenDeAcesso(Usuario usuario);
}