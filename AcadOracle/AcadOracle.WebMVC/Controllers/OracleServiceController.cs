using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcadOracle.Core.Interfaces;
using AcadOracle.Dal.Interfaces;
using AcadOracle.DomainModel.Models;
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

            return View();
        }

    }
}
