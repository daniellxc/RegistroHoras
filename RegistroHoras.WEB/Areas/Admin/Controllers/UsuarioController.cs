using RegistroHoras.DATA;
using RegistroHoras.DATA.classes.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroHoras.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles="Administradores")]
    public class UsuarioController : Controller
    {
        // GET: Usuario

        UsuarioBO DAO = new UsuarioBO();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        public ActionResult SalvarUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid) return View("CadastrarUsuario", usuario);
            try
            {
                DAO.SalvarUsuario(usuario);
                return View("Index");
            }catch(Exception ex)
            {
                return View("CadastrarUsuario", usuario);
            }
        }

        public ActionResult ExcluirUsuario(int colaborador)
        {
            try
            {
                DAO.ExcluirUsuario(DAO.Get(colaborador));
                return View("Index");
            }
            catch(Exception ex) 
            {

                return View("Index");
            }
        }

        public ActionResult ConfigurarUsuario(int colaborador)
        {
            return View(DAO.Get(colaborador));
        }

        public ActionResult AlterarSenha(int colaborador, string Senha)
        {
            try
            {
                DAO.AlterarSenha(colaborador, Senha);
                return View("ConfigurarUsuario", DAO.Get(colaborador)).ComMensagem("Senha alterada com sucesso","alert-success");
            }
            catch (Exception ex)
            {
                return View("ConfigurarUsuario", DAO.Get(colaborador)).ComMensagem(ex.Message,"alert-danger");
            }
            
        }

        public ActionResult AdicionarGrupoAoUsuario(int registroGrupo, int colaborador)
        {
            try
            {
                new GrupoBO().AddUsuarioAoGrupo(colaborador, registroGrupo);
                return View("ConfigurarUsuario", DAO.Get(colaborador));
            }catch(Exception ex)
            {
                return View("ConfigurarUsuario", DAO.Get(colaborador)).ComMensagem("Erro ao adicionar usuário ao grupo." + ex.Message, "alert-danger");
            }
        }

        public ActionResult RemoverGrupoDoUsuario(int registroGrupo, int colaborador)
        {
            try
            {
                new GrupoBO().RemoverUsuarioDoGrupo(colaborador, registroGrupo);
                return View("ConfigurarUsuario", DAO.Get(colaborador));
            }
            catch (Exception ex)
            {
                return View("ConfigurarUsuario", DAO.Get(colaborador)).ComMensagem("Erro ao adicionar usuário ao grupo." + ex.Message, "alert-danger");
            }
        }


    }
}