namespace CompanyApp.Api.Models.Funcionario
{
    public class CriarFuncionarioRequestModel
    {

     
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public string? Cpf { get; set; }

        public DateTime? DataAdmissao{ get; set; }       
        public Guid? IdEmpresa { get; set; }
    }
}
