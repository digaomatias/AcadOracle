using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;

namespace AcadOracle.DomainModel
{
    public static class ModelExtensions
    {
        private static string turmahorarioRegex = "^(?<TurmaHorario>(?<DiaSemana>[2-6])(?<Horario>[a-pA-P]+)){1,6}$";

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

        public static IEnumerable<TurmaHorario> ToTurmaHorarios(this string th)
        {
            Regex regex = new Regex(turmahorarioRegex);
            Match match = regex.Match(th);
            CaptureCollection captures = match.Groups[1].Captures;

            List<TurmaHorario> turmahorarios = new List<TurmaHorario>();

            foreach (var capture in captures)
            {
                string capt = capture.ToString();

                DayOfWeek diaSemana = (DayOfWeek)int.Parse(capt.Substring(0, 1));
                IEnumerable<HoraAula> horasAula = capt.Substring(1).ToHoraAula();

                turmahorarios.Add(new TurmaHorario(){DiaSemana = diaSemana});
                }

            return null;
        }

        internal static IEnumerable<HoraAula> ToHoraAula(this string hs)
        {
            HashSet<HoraAula> horarios = new HashSet<HoraAula>();
            for (int i = 0; i < hs.Length; ++i)
            {
                HoraAula hora = (HoraAula)Enum.Parse(typeof(HoraAula), hs[i].ToString().ToUpper());
                horarios.Add(hora);
            }

            return horarios;
        }

        public static bool IsValidTurmaHorario(this string th)
        {
            for (int i = 0; i < th.Length-1; ++i)
                if (th[i].Equals(th[i + 1]))
                    return false;

            Regex regex = new Regex(turmahorarioRegex);
            return regex.IsMatch(th);
        }
    }
}
