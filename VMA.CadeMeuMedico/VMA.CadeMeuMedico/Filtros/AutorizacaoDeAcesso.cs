using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VMA.CadeMeuMedico.Repositorios;

namespace VMA.CadeMeuMedico.Filtros
{
    [HandleError]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AutorizacaoDeAcesso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = filterContext.ActionDescriptor.ActionName;

            if (Controller != "Home" || Action != "Login")
            {
                if (RepositorioUsuarios.VerificaSeUsuarioLogado() == null)
                {
                    filterContext.RequestContext.HttpContext.Response.Redirect
                        ("/Home/Login?Url=" + filterContext.HttpContext.Request.Url.LocalPath);
                }
            }
        }
    }
}