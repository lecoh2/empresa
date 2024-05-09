﻿using CompanyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository
    {
        void Add(Empresa empresa);
        void Update(Empresa empresa);
        void Delete(Empresa empresa);
        List<Empresa> GetAll();
        Empresa GetById(Guid id);
    }
}
