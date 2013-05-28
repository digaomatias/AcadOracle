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

        public IEnumerable<Disciplina> GetPendentesECursadas(Curso curso, IEnumerable<Disciplina> cursadas)
        {
            int creditos = cursadas.Any() ? cursadas.Sum(c => c.Creditos) : 0;
            IEnumerable<int> disciplinaIds = cursadas.Select(c => c.Id).ToArray();

            var r = (from disciplina in this.All
                    where
                        (
                        (!disciplina.PreRequisitos.Any() || disciplina.PreRequisitos.All(pr => disciplinaIds.Any(id => id == pr.Id))) 
                        && (disciplina.PreCreditos <= creditos && disciplina.Cursoes.Any(c => c.Id == curso.Id))
                        )
                    select disciplina).Distinct();

            return r.ToArray();
        }

        public IEnumerable<Disciplina> GetPendentes(Curso curso, IEnumerable<Disciplina> cursadas)
        {
            int creditos = cursadas.Any() ? cursadas.Sum(c => c.Creditos) : 0;
            IEnumerable<int> disciplinaIds = cursadas.Select(c => c.Id).ToArray();

            var r = (from disciplina in this.All
                     where
                         (
                         (!disciplina.PreRequisitos.Any() || disciplina.PreRequisitos.All(pr => disciplinaIds.Any(id => id == pr.Id)))
                         && (disciplina.PreCreditos <= creditos && disciplina.Cursoes.Any(c => c.Id == curso.Id))
                         && disciplinaIds.All(d => d != disciplina.Id)
                         )
                     select disciplina).Distinct();

            return r.ToArray();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    
}