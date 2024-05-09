using CompanyApp.Domain.Entities;
using CompanyApp.Domain.Interfaces.Repositories;
using CompanyApp.Infa.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Infa.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        public List<Funcionario> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Funcionario>()
                    .Include(f=>f.Empresa)
                    .OrderBy(f => f.Nome)
                    .ToList();
            }
        }
        public void Add(Funcionario funcionario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(funcionario);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Funcionario funcionario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(funcionario);
                dataContext.SaveChanges();
            }
        }


        public Funcionario GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Funcionario>()
                    
                    .Include(f=>f.Empresa)
                    .Where(f => f.IdFuncionario == id)
                    .FirstOrDefault();
            }
        }

        public void Update(Funcionario funcionario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(funcionario);
                dataContext.Entry(funcionario).Property(e => e.IdEmpresa).IsModified = false;
                if (dataContext.Entry(funcionario).Property(f => f.DataAdmissao) == null)
                {
                    dataContext.Entry(funcionario).Property(f => f.DataAdmissao).IsModified = false;
                }
                dataContext.SaveChanges();
            }
        }
    }
}
