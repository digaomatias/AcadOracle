using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel
{
    public class Turma
    {
        public Turma()
        {
            this.Horarios = new HashSet<Horario>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }

        public Disciplina Disciplina { get; set; }
        public ICollection<Horario> Horarios { get; set; }
    }
}
