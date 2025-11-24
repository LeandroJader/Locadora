using Microsoft.AspNetCore.Identity;

namespace LocadoraDeVeiculos.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid>
    {
        public Usuario()
        {
            Id = Guid.NewGuid();
            EmailConfirmed = true;
        }
    }
}