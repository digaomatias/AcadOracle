using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.Core.Interfaces;
using AcadOracle.DomainModel;

namespace AcadOracle.Core
{
    public class OracleService : IOracleService
    {
        public IEnumerable<Turma> SugerirDisciplinas(int semestreAtual, IEnumerable<Disciplina> pendentes, IEnumerable<Disciplina> cursadas)
        {
            throw new NotImplementedException();
        }
    }
}
