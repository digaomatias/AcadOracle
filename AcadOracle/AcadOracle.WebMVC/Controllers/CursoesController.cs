using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel.Models;
using AcadOracle.WebMVC.Models;

namespace AcadOracle.WebMVC.Controllers
{   
    public class CursoesController : Controller
    {
		private readonly ICursoRepository cursoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        private CursoesController()
        {
        }

        public CursoesController(ICursoRepository cursoRepository)
        {
			this.cursoRepository = cursoRepository;
        }

        //
        // GET: /Cursoes/

        public ViewResult Index()
        {
            return View(cursoRepository.AllIncluding(curso => curso.Disciplinas));
        }

        //
        // GET: /Cursoes/Details/5

        public ViewResult Details(int id)
        {
            return View(cursoRepository.Find(id));
        }

        //
        // GET: /Cursoes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Cursoes/Create

        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            if (ModelState.IsValid) {
                cursoRepository.InsertOrUpdate(curso);
                cursoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Cursoes/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(cursoRepository.Find(id));
        }

        //
        // POST: /Cursoes/Edit/5

        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid) {
                cursoRepository.InsertOrUpdate(curso);
                cursoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Cursoes/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(cursoRepository.Find(id));
        }

        //
        // POST: /Cursoes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            cursoRepository.Delete(id);
            cursoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                cursoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
