using LocadoraDeVeiculos.ModuloAutenticacao;

namespace LocadoraDeVeiculos.apli.DTOs
{
    public class TokenResponse : IAccessToken
    {
        public required string Chave { get; set; }
        public required DateTime DataExpiracao { get; set; }
        public required UsuarioAutenticadoDto Usuario { get; set; }
    }
}