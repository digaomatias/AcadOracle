using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOracle.DomainModel.Restricao
{
    public class RestricaoCreditos : Restricao
    {
        private int restricao;

        public RestricaoCreditos(int creditos)
        {
            this.restricao = creditos;
        }

        public override IEnumerable<Turma> AplicarRestricao(IEnumerable<Turma> turmas)
        {
            var turmasPorPeso = turmas.OrderBy(t => t.Disciplina.Peso).ToList();
            
            while (turmasPorPeso.Sum(t => t.Disciplina.Creditos) > restricao)
            {
                turmasPorPeso.RemoveAt(0);
            }

            return turmasPorPeso;
        }
    }
}
