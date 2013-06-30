using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.Dal.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        void SetContext(AcadOracleDBContext context);
        T Find(int id);
        void InsertOrUpdate(T disciplina);
        void Delete(int id);
        void Save();
    }
}
