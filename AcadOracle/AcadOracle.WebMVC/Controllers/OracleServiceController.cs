using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AcadOracle.Core.Interfaces;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel;
using AcadOracle.DomainModel.Models;
using AcadOracle.DomainModel.Restricao;
using AcadOracle.WebMVC.Infrastructure.ActionFilters;
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

        public ActionResult Create()
        {
            IEnumerable<Curso> cursos = cursoRepository.All.ToArray();
            ViewBag.CursoList = new SelectList(cursos, "Id", "Nome");

            IEnumerable<Disciplina> cursadas = new Disciplina[0];
            IEnumerable<Disciplina> pendentes =  disciplinaRepository.GetPendentesECursadas(cursos.First(), cursadas);

            RequisicaoSugestaoModel model = new RequisicaoSugestaoModel();
            model.Disponiveis = new MultiSelectList(pendentes, "Id", "Nome");


            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RequisicaoSugestaoModel result)
        {
            var restricoes = GetRestricoes(result);
            var cursadas = result.CursadasId != null ? disciplinaRepository.All.Where(d => result.CursadasId.Any(c => c == d.Id)).ToArray() : new Disciplina[0];
            var candidatas = disciplinaRepository.GetPendentes(new Curso() { Id = result.CursoId }, cursadas);

            var turmas = oracleService.SugerirDisciplinas(candidatas, cursadas, restricoes);

            if (turmas.Any())
            {
                var data = new RouteValueDictionary();
                var counter = 0;

                foreach (var turma in turmas)
                {
                    data.Add("id"+counter, turma.ToString());
                    counter++;
                }

                return RedirectToAction("Show", data);
            }
            result.NoResultsFound = true;

            IEnumerable<Curso> cursos = cursoRepository.All.ToArray();
            ViewBag.CursoList = new SelectList(cursos, "Id", "Nome");
            IEnumerable<Disciplina> pendentes = disciplinaRepository.GetPendentesECursadas(new Curso() { Id = result.CursoId } , cursadas);
            result.Disponiveis = new MultiSelectList(pendentes, "Id", "Nome");

            
            return View(result);
        }

        private IEnumerable<Restricao> GetRestricoes(RequisicaoSugestaoModel from)
        {
            List<Restricao> restricoes = new List<Restricao>();

            if (from.RestricaoDisciplinasId != null && from.RestricaoDisciplinasId.Any())
            {
                IEnumerable<Disciplina> disciplinas =
                    disciplinaRepository.All.Where(d => from.RestricaoDisciplinasId.Contains(d.Id)).ToArray();
                RestricaoDisciplinas restricaoDisciplina = new RestricaoDisciplinas(disciplinas);

                restricoes.Add(restricaoDisciplina);
            }

            if (from.RestricaoCreditos > 0)
            {
                RestricaoCreditos creditos = new RestricaoCreditos(from.RestricaoCreditos);
                restricoes.Add(creditos);
            }

            if (from.RestricaoHorarios != null)
            {
                var turmaHorarios = from.RestricaoHorarios.ToTurmaHorarios();
                if (turmaHorarios != null && turmaHorarios.Any())
                {
                    RestricaoHorarios horarios = new RestricaoHorarios(turmaHorarios);
                    restricoes.Add(horarios);
                }
            }

            return restricoes;
        }

        [BindArray]
        public ActionResult Show(string[] turmas)
        {
            return View(turmas);
        }

        [HttpPost]
        public JsonResult GetDisciplinasPendentes(DisciplinasRequestModel disciplinas)
        {
            IEnumerable<Disciplina> cursadas = disciplinas.CursadasId != null ? disciplinas.CursadasId.Select(x => new Disciplina() {Id = x }).ToArray() : new Disciplina[0];
            IEnumerable<Disciplina> pendentes = disciplinaRepository.GetPendentesECursadas(new Curso() { Id = disciplinas.CursoId}, cursadas);

            CursadasResponseView result = new CursadasResponseView();
            result.CursadasId = disciplinas.CursadasId;
            result.Disciplinas = pendentes.Select(x => new KeyValuePair<string, int>(x.Nome, x.Id));

            return Json(result);
        }

    }
}
