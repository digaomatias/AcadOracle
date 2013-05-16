using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOracle.Core.Models
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
