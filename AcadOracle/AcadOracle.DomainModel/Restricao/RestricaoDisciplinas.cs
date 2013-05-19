using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.DomainModel.Restricao
{
    public class RestricaoDisciplinas : Restricao
    {
        private IEnumerable<Disciplina> restricao;

        public RestricaoDisciplinas(IEnumerable<Disciplina> restricao)
        {
            if(restricao == null)
                throw new ArgumentNullException("restricao");

            this.restricao = restricao;
        }

        public override IEnumerable<Turma> AplicarRestricao(IEnumerable<Turma> turmas)
        {
            IEnumerable<Turma> turmasParaRemover = turmas.Where(t => restricao.Contains(t.Disciplina)).ToArray();
            var result = turmas.ToList();
            result.RemoveAll(turmasParaRemover.Contains);
            return result;
        }
    }
}
