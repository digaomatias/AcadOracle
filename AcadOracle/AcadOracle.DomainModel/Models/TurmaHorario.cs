using System;
using System.Collections.Generic;
using System.Linq;

namespace AcadOracle.DomainModel.Models
{
    public class TurmaHorario : IEquatable<TurmaHorario>
    {
        private string horario;
        private IEnumerable<HoraAula> horarios; 

        public TurmaHorario()
        {
            horarios = new HoraAula[0];
        }

        public DiaDaSemana DiaSemana { get; set; }
        public string Horario {
            get { return string.Concat(horarios.Select(h => h.ToString())); }
            set
            {
                horario = value;
                Horarios = horario.ToHoraAula();
            }
        }

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

        public bool Equals(TurmaHorario other)
        {
            if (other == null)
                return false;

            return this.DiaSemana == other.DiaSemana && this.Horarios.All(h => other.Horarios.Contains(h));
        }

        public override bool Equals(object obj)
        {
            TurmaHorario turmaHorario = obj as TurmaHorario;
            if (turmaHorario == null)
                return false;

            return this.DiaSemana == turmaHorario.DiaSemana && this.Horarios.All(h => turmaHorario.Horarios.Contains(h));
        }
    }

    public class TurmaHorarioEqualityComparer : IEqualityComparer<TurmaHorario>
    {
        public bool Equals(TurmaHorario x, TurmaHorario y)
        {
            return x != null && y != null &&
                x.DiaSemana == y.DiaSemana && 
                x.Horarios.All(h => y.Horarios.Contains(h));
        }

        public int GetHashCode(TurmaHorario obj)
        {
            return ((int)obj.DiaSemana) ^ obj.Horarios.Sum(h => (int)h);
        }
    }
}
