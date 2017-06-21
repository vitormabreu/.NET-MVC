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
                    var QueryAutenticaUsuarios = db.Usuarios.SingleOrDefault
                        (x => x.Login == Login && x.Senha == SenhaCriptografada);

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

        public static Usuarios RecuperaUsuariosPorID(long IDUsuario)
        {
            try
            {
                using (CadeMeuMedicoBDEntities db = new CadeMeuMedicoBDEntities())
                {
                    var Usuario = db.Usuarios.SingleOrDefault(u => u.IDUsuario == IDUsuario);
                    return Usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Usuarios VerificaSeUsuarioLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies["UserCookieAutentication"];
            if (Usuario == null)
            {
                return null;
            }
            else
            {
                long IDUsuario = Convert.ToInt64
                    (RepositorioCriptografia.Descriptografar(Usuario.Values["IDUsuario"]));

                var UsuarioRetornado = RecuperaUsuariosPorID(IDUsuario);
                return UsuarioRetornado;
            }
        }
    }
}