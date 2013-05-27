using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;

namespace AcadOracle.WebMVC.Models
{
    public class RequisicaoSugestaoModel
    {
        public IEnumerable<int> RestricaoDisciplinasId { get; set; }
        public string RestricaoHorarios { get; set; }
        public int RestricaoCreditos { get; set; }
        public IEnumerable<int> DisciplinasIdCursadas { get; set; }
        public IEnumerable<int> DisciplinasIdCandidatas { get; set; } 
    }
}