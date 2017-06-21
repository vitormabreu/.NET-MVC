using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using VMA.CadeMeuMedico.Models;

namespace VMA.CadeMeuMedico.Repositorios
{
    public class RepositorioUsuarios
    {
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");

            try
            {
                using (CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities())
                {
                    var QueryAutenticaUsuarios = db.Usuarios
                        .SingleOrDefault(x => x.Login == Login && x.Senha == Senha);

                    if (QueryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(QueryAutenticaUsuarios.IDUsuario);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}