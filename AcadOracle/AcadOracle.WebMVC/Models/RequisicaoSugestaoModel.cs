using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;

namespace AcadOracle.WebMVC.Models
{
    public class RequisicaoSugestaoModel
    {
        public bool NoResultsFound { get; set; }
        public IEnumerable<int> RestricaoDisciplinasId { get; set; }
        public string RestricaoHorarios { get; set; }
        public int RestricaoCreditos { get; set; }
        public int CursoId { get; set; }
        public IEnumerable<int> CursadasId { get; set; }
        public MultiSelectList Disponiveis { get; set; } 
    }
}