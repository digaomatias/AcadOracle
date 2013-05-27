using System;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class Curso
    {
        public Curso()
        {
            this.Disciplinas = new List<Disciplina>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
