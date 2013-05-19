using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class TurmaHorario
    {
        public TurmaHorario()
        {
            this.Horarios = new List<Horario>();
        }

        public int Id { get; set; }
        public int TurmaId { get; set; }
        public DayOfWeek DiaSemana { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }

        public bool SobrepoeTurmaHorario(TurmaHorario obj)
        {
            if (DiaSemana != obj.DiaSemana)
                return false;

            foreach (Horario hora in Horarios)
            {
                if (obj.Horarios.Contains(hora))
                    return true;
            }

            return false;
        }
    }
}
