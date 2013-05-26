using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.WebMVC.Models
{
    public class TurmaEditModel
    {
        public string NomeTurma
        {
            get { return string.Format("{0} - {1}", Numero, Disciplina.Nome); }
        }

        public int Id { get; set; }
        [Required]
        public int DisciplinaId { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public Disciplina Disciplina { get; set; }

        public string TurmaHorarios { get; set; }
    }
}