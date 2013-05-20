using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.Dal
{ 
    public class DisciplinaRepository : IDisciplinaRepository
    {
        AcadOracleDBContext context = new AcadOracleDBContext();

        public IQueryable<Disciplina> All
        {
            get { return context.Disciplinas; }
        }

        public IQueryable<Disciplina> AllIncluding(params Expression<Func<Disciplina, object>>[] includeProperties)
        {
            IQueryable<Disciplina> query = context.Disciplinas;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Disciplina Find(int id)
        {
            return context.Disciplinas.Find(id);
        }

        public void InsertOrUpdate(Disciplina disciplina)
        {
            if (disciplina.Id == default(int)) {
                // New entity
                context.Disciplinas.Add(disciplina);
            } else {
                // Existing entity
                context.Entry(disciplina).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var disciplina = context.Disciplinas.Find(id);
            context.Disciplinas.Remove(disciplina);
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