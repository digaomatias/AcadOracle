using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcadOracle.Core.Models
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
            RequisitoPara = new Disciplina[0];
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Creditos { get; set; }
        public int PreReqCreditos { get; set; }
        public short Semestre { get; set; }
        public bool Eletiva { get; set; }

        public IEnumerable<Disciplina> RequisitoPara { get; set; }

        public int Peso
        {
            get
            {
                int points = (MaxSemestres - Semestre) * PesoSemestre;
                points += RequisitoPara.Count() * PesoDependencia;

                return points;
            }
        }


    }
}
