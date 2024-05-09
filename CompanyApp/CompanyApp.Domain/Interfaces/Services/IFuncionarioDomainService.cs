using CompanyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Interfaces.Services
{
    public interface IFuncionarioDomainService
    {
        void CadastrarFuncioario(Funcionario funcionario);
        void AtualizarFuncionario(Funcionario funcionario);
        void ExcluirFuncionario(Funcionario funcionario);
        List<Funcionario> ConsultarFuncionario();
        Funcionario ObterPorId(Guid id);
    }
}
