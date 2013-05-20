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
    public class TurmaRepository : ITurmaRepository
    {
        AcadOracleDBContext context = new AcadOracleDBContext();

        public IQueryable<Turma> All
        {
            get { return context.Turmas; }
        }

        public IQueryable<Turma> AllIncluding(params Expression<Func<Turma, object>>[] includeProperties)
        {
            IQueryable<Turma> query = context.Turmas;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Turma Find(int id)
        {
            return context.Turmas.Find(id);
        }

        public void InsertOrUpdate(Turma turma)
        {
            if (turma.Id == default(int)) {
                // New entity
                context.Turmas.Add(turma);
            } else {
                // Existing entity
                context.Entry(turma).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var turma = context.Turmas.Find(id);
            context.Turmas.Remove(turma);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Turma> GetByDisciplina(IEnumerable<Disciplina> disciplinas)
        {
            throw new NotImplementedException();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }
}