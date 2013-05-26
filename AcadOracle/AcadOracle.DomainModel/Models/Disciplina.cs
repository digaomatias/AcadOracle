using System.Linq;
using System.Collections.Generic;

namespace AcadOracle.DomainModel.Models
{
    public partial class Disciplina
    {
        //ToDo: Move this to a settings file or the database.
        private const int MaxSemestres = 11;
        //ToDo: Move this to a settings file or the database.
        private const int PesoSemestre = 15;
        //ToDo: Move this to a settings file or the database.
        private const int PesoDependencia = 10;

        public Disciplina()
        {
            this.Turmas = new List<Turma>();
            this.Cursoes = new List<Curso>();
            this.PreRequisitos = new List<Disciplina>();
            this.RequisitoPara = new List<Disciplina>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Creditos { get; set; }
        public int PreCreditos { get; set; }
        public short Semestre { get; set; }
        public bool Eletiva { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
        public virtual ICollection<Curso> Cursoes { get; set; }
        public virtual ICollection<Disciplina> PreRequisitos { get; set; }
        public virtual ICollection<Disciplina> RequisitoPara { get; set; }
        public int Peso
        {
            get
            {
                int points = (MaxSemestres - Semestre) * PesoSemestre;
                points += PreRequisitos.Count() * PesoDependencia;

                return points;
            }
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
