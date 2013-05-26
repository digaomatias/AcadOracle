using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using Moo;

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
        public Disciplina Disciplina { get; set; }
        [Required]
        [RegularExpression("^(?<TurmaHorario>(?<DiaSemana>[2-6])(?<Horario>[a-pA-P]+)){1,6}$", ErrorMessage = "Formato inválido! Formato é [numero_dia_semana][horario]. Exemplos: 2jk, 5j, 2lm4lm, 5np.")]
        public string TurmaHorario { get; set; }
    }
}