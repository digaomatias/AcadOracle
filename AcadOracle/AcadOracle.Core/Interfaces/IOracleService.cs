using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel;

namespace AcadOracle.Core.Interfaces
{
    public interface IOracleService
    {
        IEnumerable<Turma> SugerirDisciplinas(int semestreAtual, IEnumerable<Disciplina> pendentes,
                                              IEnumerable<Disciplina> cursadas);
    }
}
