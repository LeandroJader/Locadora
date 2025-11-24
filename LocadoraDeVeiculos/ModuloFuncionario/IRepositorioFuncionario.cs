using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.ModuloFuncionario
{
    public interface IRepositorioFuncionario
    {
        Task<Guid> InserirAsync(Funcionario novaEntidade);
        Task<bool> EditarAsync(Funcionario entidadeAtualizada);
        Task<bool> excluirAsync(Funcionario EntidadeParaRemover);
        Task<List< Funcionario >> selecionarTodosAsync();
        Task<Funcionario> selecionarTodosPorIdAsync(Guid id);
    }
}
