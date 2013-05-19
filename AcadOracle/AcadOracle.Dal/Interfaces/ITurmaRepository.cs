using System.Collections.Generic;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.Dal.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        IEnumerable<Turma> GetByDisciplina(IEnumerable<Disciplina> disciplinas);
    }
}
