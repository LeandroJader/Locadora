using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos
{
    public class GrupoDeVeiculos : EntidadeBase
    {
        public string Nome { get; set; }
        public List<Automovel> Veiculos { get; set; }

        public GrupoDeVeiculos()
        {
            Veiculos = []; 
        }
        public GrupoDeVeiculos(string nome) :this()
        {
            Nome = nome;
           
        }

        public void AdicionarVeiculo(Automovel automovel)
        {if(!Veiculos.Contains(automovel))

                Veiculos.Add(automovel);
        }
        public void RemoverVeiculo(Automovel automovel)
        {
            if(Veiculos.Contains(automovel))
                Veiculos.Remove(automovel);
        }
    }
   
}
