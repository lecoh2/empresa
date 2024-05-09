using CompanyApp.Domain.Entities;

namespace CompanyApp.Api.Models.Funcionario
{
    public class ConsultarFuncionarioResponseModel
    {
        public Guid? IdFuncionario { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public string? DTAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public Guid? IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RasaoSocial { get; set; }
        public string? Cnpj { get; set; }

       
        // public ConsultarEmpresaResponseModel Empresa { get; set; }
    }
}
