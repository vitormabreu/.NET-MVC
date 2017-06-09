using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VMA.CadeMeuMedico.Controllers
{
    public class MensagensController : Controller
    {
        // GET: Mensagens
        public ActionResult BomDia()
        {
            return Content("Bom dia, hoje você acordou cedo.");
        }

        public ActionResult BoaTarde()
        {
            return Content("Não durma na hora do trabalho!");
        }

        public ActionResult BoaNoite()
        {
            return Content("Já está na hora de dormir.");
        }
    }
}