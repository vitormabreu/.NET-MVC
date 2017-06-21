using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VMA.CadeMeuMedico.Models;

namespace VMA.CadeMeuMedico.Controllers
{
    public class MedicosController : BaseController
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include("Cidades").Include("Especialidades");
            return View(medicos);
        }

        // GET: Medicos/Adicionar
        public ActionResult Adicionar()
        {
            ViewBag.Cidades = new SelectList(db.Cidades, "Cidade", "Nome");
            ViewBag.Especialidades = new SelectList(db.Especialidades, "Especialidade", "Nome");
            return View();
        }

        //POST: Medicos/Adicionar
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        //GET: Medicos/Editar
        public ActionResult Editar(long id)
        {

            Medicos medico = db.Medicos.Find(id);

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);

            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);

            return View(medico);

        }

        //POST: Medicos/Editar
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

        //GET: Medicos/Detalhes
        public ActionResult Detalhes(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        //GET Medicos/Excluir
        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicos medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        //POST: Medicos/Excluir
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmaEsclusao(int id)
        {
            Medicos medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}