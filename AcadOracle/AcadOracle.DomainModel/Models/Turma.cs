using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class Turma
    {
        public Turma()
        {
        }

        public int Id { get; set; }
        public int DisciplinaId { get; set; }
        public int Numero { get; set; }
        public string TurmaHorario { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        public ICollection<TurmaHorario> TurmaHorarios
        {
            get { return TurmaHorario.ToTurmaHorarios(); }
            set { TurmaHorario = value.ToTurmaHorarioString(); }
        }

        public override string ToString()
        {
            if(Disciplina != null && TurmaHorario != null)
                return string.Format("{0} - {1} - {2}", Numero, Disciplina.Nome, TurmaHorario);

            return base.ToString();
        }
    }
}
