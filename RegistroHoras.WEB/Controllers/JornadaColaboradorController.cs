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
    public class JornadaColaboradorController : Controller
    {
        JornadaColaboradorBO DAO = new JornadaColaboradorBO();
        // GET: JornadaColaborador
        public ActionResult CadastroJornada(int? registroColaborador)
        {
           if(!registroColaborador.HasValue)
               return View(new JornadaColaborador(0));
            return View(new JornadaColaborador(registroColaborador.Value));
        }

  

        public ActionResult SalvarJornada(JornadaColaborador jornada)
        {
            if (!ModelState.IsValid) return View("CadastroJornada", jornada);
            try
            {
                DAO.SalvarJornada(jornada);
                return View("CadastroJornada", new JornadaColaborador(jornada.colaborador));
            }
            catch (Exception)
            {
                return View("CadastroJornada", jornada);
            }
        }

        public ActionResult RemoverJornada(int registro)
        {
            JornadaColaborador jornada = DAO.GetJornadaColaborador(registro);
            try
            {
               
                DAO.ExcluirJornada(jornada);

                return View("CadastroJornada", new JornadaColaborador(jornada.colaborador));
            }
            catch (Exception)
            {
                return View("CadastroJornada");
            }
        }
    }
}