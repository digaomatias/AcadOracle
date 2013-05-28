﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.Dal.Interfaces
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        IEnumerable<Disciplina> GetPendentes(Curso curso, IEnumerable<Disciplina> cursadas);
    }
}
