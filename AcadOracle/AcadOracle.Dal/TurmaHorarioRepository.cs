using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.Dal
{ 
    public class TurmaHorarioRepository : ITurmaHorarioRepository
    {
        AcadOracleDBContext context = new AcadOracleDBContext();

        public IQueryable<TurmaHorario> All
        {
            get { return context.TurmaHorarios; }
        }

        public IQueryable<TurmaHorario> AllIncluding(params Expression<Func<TurmaHorario, object>>[] includeProperties)
        {
            IQueryable<TurmaHorario> query = context.TurmaHorarios;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TurmaHorario Find(int id)
        {
            return context.TurmaHorarios.Find(id);
        }

        public void InsertOrUpdate(TurmaHorario turmahorario)
        {
            if (turmahorario.Id == default(int)) {
                // New entity
                context.TurmaHorarios.Add(turmahorario);
            } else {
                // Existing entity
                context.Entry(turmahorario).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var turmahorario = context.TurmaHorarios.Find(id);
            context.TurmaHorarios.Remove(turmahorario);
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

    public interface ITurmaHorarioRepository : IDisposable
    {
        IQueryable<TurmaHorario> All { get; }
        IQueryable<TurmaHorario> AllIncluding(params Expression<Func<TurmaHorario, object>>[] includeProperties);
        TurmaHorario Find(int id);
        void InsertOrUpdate(TurmaHorario turmahorario);
        void Delete(int id);
        void Save();
    }
}