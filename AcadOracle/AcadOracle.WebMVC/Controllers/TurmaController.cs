using System;
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
    public class TurmaController : Controller
    {
		private readonly IDisciplinaRepository disciplinaRepository;
		private readonly ITurmaRepository turmaRepository;

	
        public TurmaController(IDisciplinaRepository disciplinaRepository, ITurmaRepository turmaRepository)
        {
			this.disciplinaRepository = disciplinaRepository;
			this.turmaRepository = turmaRepository;
        }

        //
        // GET: /Turma/

        public ViewResult Index()
        {
            return View(turmaRepository.AllIncluding(turma => turma.Disciplina, turma => turma.TurmaHorarios));
        }

        //
        // GET: /Turma/Details/5

        public ViewResult Details(int id)
        {
            return View(turmaRepository.Find(id));
        }

        //
        // GET: /Turma/Create

        public ActionResult Create()
        {
			ViewBag.PossibleDisciplinas = disciplinaRepository.All;
            return View();
        } 

        //
        // POST: /Turma/Create

        [HttpPost]
        public ActionResult Create(TurmaEditModel turma)
        {
            if (ModelState.IsValid)
            {
                var result = turma.MapTo<Turma>();

                turmaRepository.InsertOrUpdate(result);
                turmaRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleDisciplinas = disciplinaRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Turma/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleDisciplinas = disciplinaRepository.All;
             return View(turmaRepository.Find(id));
        }

        //
        // POST: /Turma/Edit/5

        [HttpPost]
        public ActionResult Edit(Turma turma)
        {
            if (ModelState.IsValid) {
                turmaRepository.InsertOrUpdate(turma);
                turmaRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleDisciplinas = disciplinaRepository.All;
				return View();
			}
        }

        //
        // GET: /Turma/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(turmaRepository.Find(id));
        }

        //
        // POST: /Turma/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            turmaRepository.Delete(id);
            turmaRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                disciplinaRepository.Dispose();
                turmaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

