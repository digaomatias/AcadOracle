using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcadOracle.DomainModel.Models;

namespace AcadOracle.WebMVC.Models
{
    public class TurmaHorarioEditModel
    {
        public DayOfWeek DiaDaSemana { get; set; }
        public int[] HorariosIds { get; set; }
        public ICollection<HoraAula> Horarios { get; set; }
    }
}