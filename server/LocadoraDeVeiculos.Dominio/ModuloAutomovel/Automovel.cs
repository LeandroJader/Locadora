using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class Automovel : EntidadeBase
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string TipoCombustivel { get; set; }

        public decimal CapacidadeTanque { get; set; }
        public DateOnly Ano { get; set; }
        public byte[] Foto { get; set; }

        public Guid GrupoVeiculosId { get; set; }
        public GrupoDeVeiculos GrupoVeiculos { get; set; }

        public Automovel() { }
       
        public Automovel(string placa, string marca, string cor, string modelo, string tipoCombustivel, decimal capacidadeTanque, DateOnly ano, byte [] foto, Guid grupoVeiculoId)
        {
            Placa = placa;
            Marca = marca;
            Cor = cor;  
            Modelo = modelo;    
            TipoCombustivel = tipoCombustivel;
            CapacidadeTanque = capacidadeTanque;
            Ano = ano;
            Foto = foto;
            GrupoVeiculosId = grupoVeiculoId;
        }

    }
}
