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
    public class EmpresaRepository : IEmpresaRepository
    {

        public List<Empresa> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Empresa>()
                    .OrderBy(e => e.NomeFantasia).ToList();
            }
        }
        public void Add(Empresa empresa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(empresa);
                dataContext.SaveChanges();

            }
        }

        public void Delete(Empresa empresa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(empresa);
                dataContext.SaveChanges();

            }
        }


        public Empresa GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Empresa>()
                    .Where(e => e.IdEmpresa == id).FirstOrDefault();
            }
        }

        public void Update(Empresa empresa)
        {
            using (var dataContext = new DataContext())
            {
              
                dataContext.Update(empresa);
                dataContext.Entry(empresa).Property(e => e.DataHoraCadastro).IsModified = false;
                dataContext.SaveChanges();

            }
        }

    }
}
