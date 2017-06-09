using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        // GET: Adicionar
        public ActionResult Adicionar()
        {
            ViewBag.Cidades = new SelectList(db.Cidades, "Cidade", "Nome");
            ViewBag.Especialidades = new SelectList(db.Especialidades, "Especialidade", "Nome");
            return View();
        }

        //POST: Adicionar
        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.AddOrUpdate(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cidades = new SelectList(db.Cidades, "Cidade", "Nome", medico.Cidades);
            ViewBag.Especialidades = new SelectList(db.Especialidades, "Especialidade", "Nome", medico.Especialidades);

            return View(medico);
        }
    }
}