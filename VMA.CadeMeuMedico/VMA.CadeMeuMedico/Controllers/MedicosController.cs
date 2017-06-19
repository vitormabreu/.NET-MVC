using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //GET: Editar
        public ActionResult Editar(long id)
        {

            Medicos medico = db.Medicos.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);

            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);

        }

        //POST: Editar
        [HttpPost]
        public ActionResult Editar(Medicos medico)
        {

            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);

            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);

        }

        //POST Excluir
        public ActionResult Excluir(long id)
        {

            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            db.Medicos.Remove(medico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}