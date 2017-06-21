using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMA.CadeMeuMedico.Repositorios;

namespace VMA.CadeMeuMedico.Controllers
{
    public class UsuariosController : BaseController
    {
        // GET: Usuarios
        [HttpGet]
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (RepositorioUsuarios.AutenticarUsuario(Login, Senha))
            {
                return Json(new
                    {
                        OK = true,
                        Mensagem = "Usuário autenticado com sucesso. Redirecionando..."
                    },
                    JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                    {
                        OK = false,
                        Mensagem = "Usuário ou Senha incorretos."
                    },
                    JsonRequestBehavior.AllowGet);
            }
        }
    }
}