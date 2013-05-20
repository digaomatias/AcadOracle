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
    public class DisciplinaController : Controller
    {
		private readonly IDisciplinaRepository disciplinaRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        private DisciplinaController() : this(new DisciplinaRepository())
        {
        }

        public DisciplinaController(IDisciplinaRepository disciplinaRepository)
        {
			this.disciplinaRepository = disciplinaRepository;
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

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Disciplina/Create

        [HttpPost]
        public ActionResult Create(Disciplina disciplina)
        {
            if (ModelState.IsValid) {
                disciplinaRepository.InsertOrUpdate(disciplina);
                disciplinaRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Disciplina/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(disciplinaRepository.Find(id));
        }

        //
        // POST: /Disciplina/Edit/5

        [HttpPost]
        public ActionResult Edit(Disciplina disciplina)
        {
            if (ModelState.IsValid) {
                disciplinaRepository.InsertOrUpdate(disciplina);
                disciplinaRepository.Save();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                disciplinaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

