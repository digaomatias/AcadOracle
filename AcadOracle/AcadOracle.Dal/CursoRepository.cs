using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.Dal
{
    public class CursoRepository : ICursoRepository
    {
        AcadOracleDBContext context = new AcadOracleDBContext();

        public IQueryable<Curso> All
        {
            get { return context.Cursos; }
        }

        public IQueryable<Curso> AllIncluding(params Expression<Func<Curso, object>>[] includeProperties)
        {
            IQueryable<Curso> query = context.Cursos;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Curso Find(int id)
        {
            return context.Cursos.Find(id);
        }

        public void InsertOrUpdate(Curso curso)
        {
            if (curso.Id == default(int))
            {
                // New entity
                context.Cursos.Add(curso);
            }
            else
            {
                // Existing entity
                context.Entry(curso).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var curso = context.Cursos.Find(id);
            context.Cursos.Remove(curso);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
