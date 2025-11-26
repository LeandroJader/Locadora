using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cnh { get; set; }
        public DateOnly ValidadeCnh { get; set; }
        public string Telefone { get; set; }
        public Guid UsuarioId { get; set; }

        private Condutor() { }

        public Condutor(
            string nome,
            string email,
            string cpf,
            string cnh,
            DateOnly validadeCnh,
            string telefone,
            Guid usuarioId)
   
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Cnh = cnh;
            ValidadeCnh = validadeCnh;
            Telefone = telefone;
            UsuarioId = usuarioId;
        }
    }
}
