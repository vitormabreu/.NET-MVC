using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMA.CadeMeuMedico.Models;

namespace VMA.CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades");
            return View(medicos);
        }
    }
}