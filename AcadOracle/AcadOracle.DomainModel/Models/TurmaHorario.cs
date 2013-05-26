using System;
using System.Collections.Generic;
using System.Linq;

namespace AcadOracle.DomainModel.Models
{
    public partial class TurmaHorario
    {
        private string horario;
        private IEnumerable<HoraAula> horarios; 

        public TurmaHorario()
        {
            horarios = new HoraAula[0];
        }

        public int Id { get; set; }
        public int TurmaId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public string Horario {
            get { return string.Concat(horarios.Select(h => h.ToString())); }
            set
            {
                horario = value;
                Horarios = horario.ToHoraAula();
            }
        }
        public virtual Turma Turma { get; set; }

        public IEnumerable<HoraAula> Horarios
        {
            get { return horarios; }
            set { horarios = value; }
        } 

        public bool SobrepoeTurmaHorario(TurmaHorario obj)
        {
            if (DiaSemana != obj.DiaSemana)
                return false;

            foreach (HoraAula hora in Horarios)
            {
                if (obj.Horarios.Contains(hora))
                    return true;
            }

            return false;
        }
    }
}
