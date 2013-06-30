using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcadOracle.Dal;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel.Models;
using AcadOracle.WebMVC.Models;
using Moo;

namespace AcadOracle.WebMVC.Controllers
{   
    public class DisciplinaController : Controller
    {
		private readonly IDisciplinaRepository disciplinaRepository;
        private readonly ICursoRepository cursoRepository;
        
        public DisciplinaController(IDisciplinaRepository disciplinaRepository, ICursoRepository cursoRepository)
        {
			this.disciplinaRepository = disciplinaRepository;
            this.cursoRepository = cursoRepository;
        }

        //
        // GET: /Disciplina/

        public ViewResult Index()
        {
            return View(disciplinaRepository.AllIncluding(disciplina => disciplina.Turmas, disciplina => disciplina.Cursoes, disciplina => disciplina.PreRequisitos, disciplina => disciplina.RequisitoPara));
        }

        //
        // GET: /Disciplina/Details/5

        public ViewResult Details(int id)
        {
            return View(disciplinaRepository.Find(id));
        }

        //
        // GET: /Disciplina/Create

        //public ActionResult Create()
        //{
        //    ViewBag.CursoList = new SelectList(cursoRepository.All.ToArray(), "Id", "Nome");
            
        //    return View();
        //}

        private bool SaveDisciplina(DisciplinaCreationModel disciplinaModel)
        {
            using (AcadOracleDBContext context = new AcadOracleDBContext())
            {
                disciplinaRepository.SetContext(context);
                cursoRepository.SetContext(context);

                Disciplina disciplina = new Disciplina();
                if (disciplinaModel.Id.HasValue && disciplinaModel.Id > 0)
                    disciplina = disciplinaRepository.Find(disciplinaModel.Id.Value);
                disciplina = disciplinaModel.MapTo<Disciplina>(disciplina);

                if (!disciplina.Cursoes.Any(c => c.Id == disciplinaModel.CursoId))
                {
                    disciplina.Cursoes.Clear();
                    disciplina.Cursoes.Add(cursoRepository.Find(disciplinaModel.CursoId));
                }

                var prToRemove = disciplina.PreRequisitos.Where(pr => !disciplinaModel.PreRequisitosId.Any(dpr => dpr == pr.Id)).ToArray();
                var prToInclude =
                    disciplinaModel.PreRequisitosId.Where(dpr => !disciplina.PreRequisitos.Any(d => d.Id == dpr));

                foreach (var toRemove in prToRemove)
                {
                    disciplina.PreRequisitos.Remove(toRemove);
                }
                foreach (var i in prToInclude)
                {
                    var d = disciplinaRepository.Find(i);
                    disciplina.PreRequisitos.Add(d);
                }

                if (!ModelState.IsValid)
                    return false;

                disciplinaRepository.InsertOrUpdate(disciplina);
                disciplinaRepository.Save();

                return true;
            }
        }

        public ActionResult Create(int? cursoId)
        {
            DisciplinaCreationModel model = new DisciplinaCreationModel();

            model.CursosList = cursoRepository.All.ToArray().Select(c => new KeyValuePair<int, string>(c.Id, c.Nome)).ToArray();
            if (cursoId != null)
            {
                IEnumerable<Disciplina> disciplinas =
                    disciplinaRepository.All.Where(d => d.Cursoes.Any(c => c.Id == cursoId.Value));

                model.DisciplinasList = disciplinas.Select(d => new KeyValuePair<int, string>(d.Id, d.Nome)).ToArray();
            }

            return View(model);
        }

        //
        // POST: /Disciplina/Create

        [HttpPost]
        public ActionResult Create(DisciplinaCreationModel disciplinaModel)
        {
            if (SaveDisciplina(disciplinaModel))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Disciplina/Edit/5
 
        public ActionResult Edit(int id)
        {
            Disciplina disciplina = disciplinaRepository.Find(id);
            DisciplinaCreationModel dcm = disciplina.MapTo<DisciplinaCreationModel>();

            //Preenche os cursos da disciplina
            List<Curso> cursos = cursoRepository.All.ToList();
            IEnumerable<int> selectedCursos = disciplina.Cursoes.Select(c => c.Id).ToArray();
            dcm.Cursos = disciplina.Cursoes;
            dcm.CursoId = selectedCursos.FirstOrDefault();
            dcm.CursosList = cursos.Select(c => new KeyValuePair<int, string>(c.Id, c.Nome));
            
            IEnumerable<Disciplina> disciplinas =
                disciplinaRepository.All.Where(d =>d.Id != id && d.Cursoes.Any(c => c.Id == selectedCursos.FirstOrDefault ())).ToArray();
            dcm.PreRequisitos = disciplina.PreRequisitos;
            dcm.PreRequisitosId = disciplina.PreRequisitos.Select(pr => pr.Id).ToArray();

            dcm.DisciplinasList = disciplina.PreRequisitos.Select(pr => new KeyValuePair<int, string>(pr.Id, pr.Nome));
            
            return View(dcm);
        }

        //
        // POST: /Disciplina/Edit/5

        [HttpPost]
        public ActionResult Edit(DisciplinaCreationModel disciplinaModel)
        {
            if (SaveDisciplina(disciplinaModel)) {
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Disciplina/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(disciplinaRepository.Find(id));
        }

        //
        // POST: /Disciplina/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            disciplinaRepository.Delete(id);
            disciplinaRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetDisciplinas(PreRequisitosRequestModel preRequisitos)
        {
            PreRequisitosResponseView result = new PreRequisitosResponseView();

            if (preRequisitos.CursoId > 0)
            {

                var disciplinas = disciplinaRepository.All.Where(d => d.Cursoes.Any(c => c.Id == preRequisitos.CursoId))
                                                      .ToArray()
                                                      .Select(x => new KeyValuePair<string, int>(x.Nome, x.Id))
                                                      .ToArray();
                result.Disciplinas = disciplinas;

                if (preRequisitos.DisciplinaId > 0)
                {
                    var disciplina = disciplinaRepository.Find(preRequisitos.DisciplinaId);
                    result.PreRequisitosId = disciplina.PreRequisitos.Select(pr => pr.Id).ToArray();
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                disciplinaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

