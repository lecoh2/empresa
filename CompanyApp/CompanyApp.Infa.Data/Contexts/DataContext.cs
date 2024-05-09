using CompanyApp.Infa.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Infa.Data.Contexts
{
    public class DataContext : DbContext
    {
        ///<summary>
        /// Método para configurar a string de conexao do bando de dados
        /// </summary>

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-J5N1M35;Initial Catalog=COMPANY;Integrated Security=SSPI;TrustServerCertificate=True;");
        }

    
    /// <summary>
    /// Método para adicionar as classes de mapeamento do projeto
    /// </summary>


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
        }

    }
}

