using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.DomainModel.Restricao
{
    public class RestricaoHorarios : Restricao
    {
        private IEnumerable<TurmaHorario> restricao; 

        public RestricaoHorarios(IEnumerable<TurmaHorario> restricoes)
        {
            if(restricoes == null)
                throw new ArgumentNullException("restricoes");

            this.restricao = restricoes;
        }

        public override IEnumerable<Turma> AplicarRestricao(IEnumerable<Turma> turmas)
        {
            return turmas.RemoverTurmasEmTurmaHorariosRestritos(restricao);
        }
    }
}
