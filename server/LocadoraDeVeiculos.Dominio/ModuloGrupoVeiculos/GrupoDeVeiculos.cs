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
        public List<Automovel>? Veiculos { get; private set; } = new List<Automovel>();


        public GrupoDeVeiculos(string nome)
        {
            Nome = nome;
            Veiculos = new List<Automovel>();
        }

        public GrupoDeVeiculos(string nome, List<Automovel> veiculos)
        {
            Nome = nome;
            Veiculos = veiculos;
        }
        public void AdicionarVeiculo(Automovel automovel)
        {
            Veiculos.Add(automovel);
        }
        public void RemoverVeiculo(Automovel automovel)
        {
            Veiculos.Remove(automovel);
        }
    }
   
}
