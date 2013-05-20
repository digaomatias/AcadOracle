using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.Dal.Interfaces
{ 
    public interface ICursoRepository : IRepository<Curso>
    {
    }
}