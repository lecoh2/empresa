using CompanyApp.Domain.Entities;
using CompanyApp.Domain.Interfaces.Services;
using CompanyApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Services
{
    public class EmpresaDomainService : IEmpresaDomainService
    {

        //atributos
        public readonly IEmpresaRepository _empresaRepository;

        //construtor para injeção de dependência
        public EmpresaDomainService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
        private string mensagemErroEmpresa => "Empresa não encontrada";

     

        public void AtualizarEmpresa(Empresa empresa)
        {
            //verificar se a empresa informada esta cadastrada;
            if (_empresaRepository.GetById(empresa.IdEmpresa.Value) == null)
                throw new ApplicationException(mensagemErroEmpresa);
            //atualizando o produto
            _empresaRepository.Update(empresa);
        }

        public void CadastrarEmpresa(Empresa empresa)
        {
            //cadastrar empresa
            _empresaRepository.Add(empresa);
        }

        public List<Empresa> ConsultarEmpresas()
        {
            //retorna tods as categorais do banco de dados
            return _empresaRepository.GetAll();
        }

        public void ExcluirEmpresa(Empresa empresa)
        {
            //buscando a empresa
            var e = _empresaRepository.GetById(empresa.IdEmpresa.Value);

            //verificar se o produto informado existe no banco de dados
            if (e == null)
                throw new ApplicationException(mensagemErroEmpresa);
            //excluido a empresa
            _empresaRepository.Delete(e);
        }


        public Empresa ObterPorId(Guid id)
        {
            return _empresaRepository.GetById(id);
        }

    }
}
