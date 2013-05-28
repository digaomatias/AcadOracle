using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcadOracle.Core.Interfaces;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel.Models;
using AcadOracle.WebMVC.Models;
using AcadOracle.WebMVC.Models.Extensions;

namespace AcadOracle.WebMVC.Controllers
{
    public class OracleServiceController : Controller
    {
        private readonly IOracleService oracleService;
        private readonly ICursoRepository cursoRepository;
        private readonly IDisciplinaRepository disciplinaRepository;

        public OracleServiceController(IOracleService oracleService, ICursoRepository cursoRepository,
                                       IDisciplinaRepository disciplinaRepository)
        {
            this.oracleService = oracleService;
            this.cursoRepository = cursoRepository;
            this.disciplinaRepository = disciplinaRepository;
        }
        //
        // GET: /SugerirDisciplinas/

        public ActionResult Index()
        {
            IEnumerable<Curso> cursos = cursoRepository.All.ToArray();
            ViewBag.CursoList = new SelectList(cursos, "Id", "Nome");

            IEnumerable<Disciplina> cursadas = new Disciplina[0];
            IEnumerable<Disciplina> pendentes =  disciplinaRepository.GetPendentes(cursos.First(), cursadas);

            RequisicaoSugestaoModel model = new RequisicaoSugestaoModel();
            model.Disponiveis = new MultiSelectList(pendentes, "Id", "Nome");


            return View(model);
        }

        [HttpPost]
        public JsonResult GetDisciplinasPendentes(DisciplinasRequestModel disciplinas)
        {
            IEnumerable<Disciplina> cursadas = disciplinas.CursadasId.Select(x => new Disciplina() {Id = x }).ToArray();
            IEnumerable<Disciplina> pendentes = disciplinaRepository.GetPendentes(new Curso() { Id = disciplinas.CursoId}, cursadas);

            CursadasResponseView result = new CursadasResponseView();
            result.CursadasId = disciplinas.CursadasId;
            result.Disciplinas = pendentes.Select(x => new KeyValuePair<string, int>(x.Nome, x.Id));

            return Json(result);
        }

    }
}
