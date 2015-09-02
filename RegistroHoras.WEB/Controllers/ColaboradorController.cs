using RegistroHoras.DATA;
using RegistroHoras.DATA.classes.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroHoras.WEB.Controllers
{
    [Authorize]
    public class ColaboradorController : Controller
    {
        ColaboradorBO DAO = new ColaboradorBO();

        // GET: Colaborador
        public ActionResult Index()
        {
            return View(DAO.TodosColaboradores());
        }

        public ActionResult Cadastro()
        {
            return View();
        }


        [Authorize(Roles="Administradores")]
        public ActionResult Editar(int registro)
        {
            return View("Cadastro", DAO.GetColaborador(registro));
        }

        public ActionResult CadastrarColaborador(Colaborador colaborador)
        {
            if (!ModelState.IsValid) return View("Cadastro", colaborador);

            try
            {
                DAO.SalvarColaborador(colaborador);
                return View("Index").ComMensagem("Cadastro efetuado com sucesso","alert-success");
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Cadastro");
            }
        }


        public ActionResult Excluir(int registro)
        {
           

            try
            {
                DAO.Excluir(DAO.GetColaborador(registro));
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Erro = ex.Message;
                return View("Cadastro");
            }
        }
    }
}