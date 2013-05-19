using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AcadOracle.DomainModel
{
    public class Disciplina
    {
        //ToDo: Move this to a settings file or the database.
        private const int MaxSemestres = 11;
        //ToDo: Move this to a settings file or the database.
        private const int PesoSemestre = 15;
        //ToDo: Move this to a settings file or the database.
        private const int PesoDependencia = 10;

        public Disciplina()
        {
            PreRequisitos = new Disciplina[0];
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Creditos { get; set; }
        public int PreReqCreditos { get; set; }
        public short Semestre { get; set; }
        public bool Eletiva { get; set; }
            
        public IEnumerable<Disciplina> PreRequisitos { get; set; }
        public IEnumerable<Disciplina> RequisitoPara { get; set; }

        public int Peso
        {
            get
            {
                int points = (MaxSemestres - Semestre) * PesoSemestre;
                points += PreRequisitos.Count() * PesoDependencia;

                return points;
            }
        }


    }
}
