using CompanyApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Infa.Data.Mappings
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("EMPRESA");
            builder.HasKey(e => e.IdEmpresa);
            builder.Property(e => e.IdEmpresa).HasColumnName("IDEMPRESA");

            builder.Property(e => e.NomeFantasia).HasColumnName("NOMEFANTASIA").IsRequired();
            builder.Property(e => e.RasaoSocial).HasColumnName("RAZAOSOCIAL").IsRequired();
            builder.Property(e => e.Cnpj).HasColumnName("CNPJ").IsRequired();
            builder.Property(e => e.DataHoraCadastro).HasColumnName("DATAHORACADASTRO");
        }
    }
}
