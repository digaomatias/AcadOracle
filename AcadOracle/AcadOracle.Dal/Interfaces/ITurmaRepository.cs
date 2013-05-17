using System.Collections.Generic;

namespace AcadOracle.Dal.Interfaces
{
    public interface ITurmaRepository : IRepository<DomainModel.Turma>
    {
        IEnumerable<DomainModel.Turma> GetByDisciplina(IEnumerable<DomainModel.Disciplina> disciplinas);
    }
}
