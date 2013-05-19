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
    public interface ICursoRepository : IDisposable
    {
        IQueryable<Curso> All { get; }
        IQueryable<Curso> AllIncluding(params Expression<Func<Curso, object>>[] includeProperties);
        Curso Find(int id);
        void InsertOrUpdate(Curso curso);
        void Delete(int id);
        void Save();
    }
}