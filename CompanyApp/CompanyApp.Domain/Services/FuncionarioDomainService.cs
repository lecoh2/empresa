using CompanyApp.Domain.Entities;
using CompanyApp.Domain.Interfaces.Repositories;
using CompanyApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Services
{
    public class FuncionarioDomainService : IFuncionarioDomainService
    {

        //atributos
        public readonly IFuncionarioRepository _funcionarioRepository;

        //construtor para injeção de dependência
        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }
        private string mensagemErroFuncionario => "Funcionario não encontrada";

        public void AtualizarFuncionario(Funcionario funcionario)
        {
            //verificar se a empresa informada esta cadastrada;
            if (_funcionarioRepository.GetById(funcionario.IdFuncionario.Value) == null)
                throw new ApplicationException(mensagemErroFuncionario);
            //atualizando o produto
            _funcionarioRepository.Update(funcionario);
        }

        public void CadastrarFuncioario(Funcionario funcionario)
        {

            //cadastrar empresa
            _funcionarioRepository.Add(funcionario);
        }

        public List<Funcionario> ConsultarFuncionario()
        {
            //retorna tods as categorais do banco de dados
            return _funcionarioRepository.GetAll();
        }

        public void ExcluirFuncionario(Funcionario funcionario)
        {
            //buscando a empresa
            var e = _funcionarioRepository.GetById(funcionario.IdFuncionario.Value);

            //verificar se o produto informado existe no banco de dados
            if (e == null)
                throw new ApplicationException(mensagemErroFuncionario);
            //excluido a empresa
            _funcionarioRepository.Delete(e);
        }

        public Funcionario ObterPorId(Guid id)
        {
            return _funcionarioRepository.GetById(id);
        }
    }
}
