using RegistroHoras.DATA;
using RegistroHoras.DATA.classes;
using RegistroHoras.DATA.classes.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroHoras.WEB.Controllers
{
 
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Colaborador colab = new Colaborador();
            ////colab.cpf = "072.167.914.52";
            //colab.nomeColaborador = "Diego Mesquita";

            //using (Context cont = new Context())
            //{
            //    cont.Colaboradores.Add(colab);
            //    cont.SaveChanges();
            //}

           

           

            return View();
        }
    }
}