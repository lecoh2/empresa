using CompanyApp.Domain.Entities;

namespace CompanyApp.Api.Models
{
    /// <summary>
    /// Modelo de dados para consulta de categorias na API
    /// </summary>
    public class CriarEmpresaRequestModel
    {
       
        public string? NomeFantasia { get; set; }
        public string? RasaoSocial { get; set; }
        public string? Cnpj { get; set; }     
    
    }
}
