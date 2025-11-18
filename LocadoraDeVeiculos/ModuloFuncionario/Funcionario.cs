using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloFuncionario
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public DateOnly DataAdmissao { get; set; }
        public decimal salario { get; set; }

        public Funcionario(string nome, DateOnly dataAdmissao, decimal salario)
        {
            Nome = nome;  
            DataAdmissao = dataAdmissao;  
            this.salario = salario;
        }
    }
}
