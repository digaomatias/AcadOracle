using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOracle.DomainModel.Restricao
{
    public class RestricaoHorarios : Restricao
    {
        private IEnumerable<Horario> restricao; 

        public RestricaoHorarios(IEnumerable<Horario> restricoes)
        {
            if(restricoes == null)
                throw new ArgumentNullException("restricoes");

            this.restricao = restricoes;
        }

        public override IEnumerable<Turma> AplicarRestricao(IEnumerable<Turma> turmas)
        {
            return turmas.RemoverTurmasEmHorariosRestritos(restricao);
        }
    }
}
