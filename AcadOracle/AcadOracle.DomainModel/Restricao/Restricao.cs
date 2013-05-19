using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.DomainModel.Restricao
{
    public abstract class Restricao
    {
        public abstract IEnumerable<Turma> AplicarRestricao(IEnumerable<Turma> turmas );
    }
}
