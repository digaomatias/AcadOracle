using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class Turma
    {
        public Turma()
        {
            this.TurmaHorarios = new List<TurmaHorario>();
        }

        public int Id { get; set; }
        public int DisciplinaId { get; set; }
        public int Numero { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public virtual ICollection<TurmaHorario> TurmaHorarios { get; set; }
    }
}
