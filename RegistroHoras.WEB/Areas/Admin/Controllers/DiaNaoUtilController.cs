using RegistroHoras.DATA.classes;
using RegistroHoras.DATA.classes.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroHoras.WEB.Areas.Admin.Controllers
{
    [Authorize]
    public class DiaNaoUtilController : Controller
    {

        private DiaNaoUtilBO DAO = new DiaNaoUtilBO();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CadastroDiaNaoUtil()
        {
            return View();
        }
        public ActionResult CadastrarDiaNaoUtil(DiaNaoUtil diaNaoUtil)
        {
            if (!ModelState.IsValid) return View("CadastroDiaNaoUtil", diaNaoUtil);

            try
            {
                DAO.Salvar(diaNaoUtil);
                return View("Index").ComMensagem("Novo registro adicionado", "alert-success");
            }
            catch(Exception ex)
            {
                return View("CadastroDiaNaoUtil", diaNaoUtil).ComMensagem(ex.Message, "alert-error");
            }
        }
        public ActionResult Excluir(int registro)
        {
            try
            {
                DAO.Excluir(DAO.Get(registro));
                return View("Index").ComMensagem("Registro excluído com sucesso","alert-success");
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = ex.Message;
                return View("Index");
            }
        }

    }
}