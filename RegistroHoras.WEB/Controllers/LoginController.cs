using RegistroHoras.DATA;
using RegistroHoras.DATA.classes.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RegistroHoras.WEB.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login_()
        {
            return View("");
        }

        public ActionResult Signin(string login, string senha)
        {
            try
            {
                Usuario usr = VerificarLogin(login,senha);
                if (usr != null)
                {
                    FormsAuthentication.SetAuthCookie(usr.COLABORADOR.ToString(), false);
                    return RedirectToAction("Index", "Home", new {area="" });

                }

            }
            catch (Exception ex)
            {
                ViewBag.LoginErr = ex.Message;
                
            }

            return View("Login_");
        }

        public Usuario VerificarLogin(string login, string senha)
        {
            Usuario usr = new UsuarioBO().GetUsuario(login, senha);

            if (usr != null)
            {
                if (usr.Ativo)
                {
                    return usr;
                }
                else
                    throw new Exception("Usuário inativo");
            }else
                throw new Exception("Usuário inválido.");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return View("Login_");

        }
    }
}