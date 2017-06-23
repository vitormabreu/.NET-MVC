using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMA.CadeMeuMedico.Models;

namespace VMA.CadeMeuMedico.Controllers
{
    public class HomeController : Controller
    {
        private CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities();

        // GET: Home
        public ActionResult Index(int? idCidade, int? idEspecialidade)
        {
            IEnumerable<Medicos> listMedicos = db.Medicos.ToList();
            IEnumerable<Cidades> listCidades = db.Cidades.ToList();
            IEnumerable<Especialidades> listEspecialidades = db.Especialidades.ToList();

            //ViewBag.Cidades = listCidades;
            //ViewBag.Especialidades = listEspecialidades;

            ViewBag.Cidades = listCidades.Select(c => new SelectListItem
            {
                Value = c.IDCidade.ToString(),
                Text = c.Nome,
                Selected = (c.IDCidade == idCidade)
            });

            ViewBag.Especialidades = listEspecialidades.Select(e => new SelectListItem
            {
                Value = e.IDEspecialidade.ToString(),
                Text = e.Nome,
                Selected = (e.IDEspecialidade == idEspecialidade)
            });


            return View(listMedicos);
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Seja bem vindo(a)";
            return View();
        }
    }
}