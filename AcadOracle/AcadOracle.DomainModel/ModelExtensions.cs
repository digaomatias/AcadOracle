using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;

namespace AcadOracle.DomainModel
{
    public static class ModelExtensions
    {
        internal static bool TurmaHorariosSobrepostos(this IEnumerable<TurmaHorario> self, IEnumerable<TurmaHorario> TurmaHorarios)
        {
            var result = self.FirstOrDefault(h => TurmaHorarios.Any(h1 => h1.SobrepoeTurmaHorario(h)));
            return result != null;
        }

        internal static IEnumerable<Turma> RemoverTurmasEmTurmaHorariosRestritos(this IEnumerable<Turma> self, IEnumerable<TurmaHorario> restricoes)
        {
            if (restricoes == null)
                return self;

            return self.Where(t => !t.TurmaHorarios.TurmaHorariosSobrepostos(restricoes)).ToArray();
        }

        public static IEnumerable<Turma> AplicarRestricoes(this IEnumerable<Turma> self,
                                                           IEnumerable<Restricao.Restricao> restricoes)
        {
            IEnumerable<Turma> turmas = self;

            foreach (var restricao in restricoes)
            {
                turmas = restricao.AplicarRestricao(turmas);
            }

            return turmas;
        }
    }
}
