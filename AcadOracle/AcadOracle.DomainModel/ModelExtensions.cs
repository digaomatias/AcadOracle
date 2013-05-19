using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Restricao;

namespace AcadOracle.DomainModel
{
    public static class ModelExtensions
    {
        internal static bool HorariosSobrepostos(this IEnumerable<Horario> self, IEnumerable<Horario> horarios)
        {
            var result = self.FirstOrDefault(h => horarios.Any(h1 => h1.SobrepoeHorario(h)));
            return result != null;
        }

        internal static IEnumerable<Turma> RemoverTurmasEmHorariosRestritos(this IEnumerable<Turma> self, IEnumerable<Horario> restricoes)
        {
            if (restricoes == null)
                return self;

            return self.Where(t => !t.Horarios.HorariosSobrepostos(restricoes)).ToArray();
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
