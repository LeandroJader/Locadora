using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoDeVeiculos : EntidadeBase
    {
        public string Nome { get; set; }

        public GrupoDeVeiculos(string nome)
        {
            Nome = nome;
        }
    }
   
}
