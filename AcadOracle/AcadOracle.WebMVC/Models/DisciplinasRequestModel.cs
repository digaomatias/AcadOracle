using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadOracle.WebMVC.Models
{
    public class DisciplinasRequestModel
    {
        public int CursoId { get; set; }
        public int[] CursadasId { get; set; }
    }

    public class CursadasResponseView
    {
        public int[] CursadasId { get; set; }
        public IEnumerable<KeyValuePair<string, int>> Disciplinas { get; set; }
    }

    public class PreRequisitosRequestModel
    {
        public int CursoId { get; set; }
        public int DisciplinaId { get; set; }
    }

    public class PreRequisitosResponseView
    {
        public int[] PreRequisitosId { get; set; }
        public IEnumerable<KeyValuePair<string, int>> Disciplinas { get; set; }
    }
}