﻿namespace CompanyApp.Api.Models
{
    public class ConsultarEmpresaResponseModel
    {
        public Guid? IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RasaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

    }
}
