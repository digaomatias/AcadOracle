using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.WebMVC.Models
{
    public class DisciplinaCreationModel
    {
        public DisciplinaCreationModel()
        {
            PreRequisitosId = new List<int>();

            PreRequisitos = new Collection<Disciplina>();
            Cursos = new Collection<Curso>();
            CursosList = new KeyValuePair<int, string>[0];
            DisciplinasList = new KeyValuePair<int, string>[0];
        }

        public int? Id { get; set; }
        public string Nome { get; set; }
        public int Creditos { get; set; }
        [Display(Name = "Pre Requisitos de Crédito")]
        public int PreCreditos { get; set; }
        public short Semestre { get; set; }
        public bool Eletiva { get; set; }
        public int CursoId { get; set; }
        public IEnumerable<int> PreRequisitosId { get; set; }

        //Pre-Load
        public ICollection<Disciplina> PreRequisitos { get; set; }
        public ICollection<Curso> Cursos { get; set; }

        public IEnumerable<KeyValuePair<int, string>> DisciplinasList
        {
            get;
            set;
        }

        public IEnumerable<KeyValuePair<int, string>> CursosList { get; set; }
    }
}