﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Entities
{
    public class Empresa
    {
        public Guid? IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RasaoSocial { get; set; }
        public string? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

        #region relacionamentos
        public List<Funcionario>? Funcionario { get; set; }
        #endregion
    }
}
