using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcadOracle.Dal;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel.Models;
using AcadOracle.WebMVC.Models;

namespace AcadOracle.WebMVC.Controllers
{   
    public class TurmaHorarioController : Controller
    {
		private readonly ITurmaRepository turmaRepository;
		private readonly ITurmaHorarioRepository turmahorarioRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        private TurmaHorarioController() : this(new TurmaRepository(), new TurmaHorarioRepository())
        {
        }

        public TurmaHorarioController(ITurmaRepository turmaRepository, ITurmaHorarioRepository turmahorarioRepository)
        {
			this.turmaRepository = turmaRepository;
			this.turmahorarioRepository = turmahorarioRepository;
        }

        //
        // GET: /TurmaHorario/

        public ViewResult Index()
        {
            return View(turmahorarioRepository.AllIncluding(turmahorario => turmahorario.Turma, turmahorario => turmahorario.Horarios));
        }

        //
        // GET: /TurmaHorario/Details/5

        public ViewResult Details(int id)
        {
            return View(turmahorarioRepository.Find(id));
        }

        //
        // GET: /TurmaHorario/Create

        public ActionResult Create()
        {
			ViewBag.PossibleTurmas = turmaRepository.All;
            return View();
        } 

        //
        // POST: /TurmaHorario/Create

        [HttpPost]
        public ActionResult Create(TurmaHorario turmahorario)
        {
            if (ModelState.IsValid) {
                turmahorarioRepository.InsertOrUpdate(turmahorario);
                turmahorarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTurmas = turmaRepository.All;
				return View();
			}
        }
        
        //
        // GET: /TurmaHorario/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleTurmas = turmaRepository.All;
             return View(turmahorarioRepository.Find(id));
        }

        //
        // POST: /TurmaHorario/Edit/5

        [HttpPost]
        public ActionResult Edit(TurmaHorario turmahorario)
        {
            if (ModelState.IsValid) {
                turmahorarioRepository.InsertOrUpdate(turmahorario);
                turmahorarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleTurmas = turmaRepository.All;
				return View();
			}
        }

        //
        // GET: /TurmaHorario/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(turmahorarioRepository.Find(id));
        }

        //
        // POST: /TurmaHorario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            turmahorarioRepository.Delete(id);
            turmahorarioRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                turmaRepository.Dispose();
                turmahorarioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

