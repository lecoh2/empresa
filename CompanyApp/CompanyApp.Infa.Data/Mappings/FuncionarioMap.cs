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
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("FUNCIONARIO");
            builder.HasKey(f => f.IdFuncionario);
            builder.Property(f => f.IdFuncionario).HasColumnName("ID");

            builder.Property(f => f.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(f => f.Matricula).HasColumnName("MATRICULA").HasMaxLength(100).IsRequired();
            builder.Property(f => f.Cpf).HasColumnName("CPF").HasMaxLength(20).IsRequired();
            builder.Property(f => f.DataAdmissao).HasColumnName("DATAADMISSAO").HasMaxLength(100).IsRequired();
            builder.Property(f => f.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").HasMaxLength(100).IsRequired();
            builder.Property(f => f.IdEmpresa).HasColumnName("IDEMPRESA").IsRequired();

            #region Mapeamento dos relacionamentos
            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Funcionario)
                .HasForeignKey(f => f.IdEmpresa)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

        }
    }
}
