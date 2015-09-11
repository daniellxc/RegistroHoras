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
    public class RegistroHorasController : Controller
    {
        // GET: RegistroHoras
        private RegistroHorasBO DAO = new RegistroHorasBO();

        public ActionResult Index()
        {
            return View("RegistrarHoraColaborador");
        }


        public ActionResult MesAtual(int registroColaborador)
        {
            return View(DAO.RegistroHorasColaboradorMes(registroColaborador, DateTime.Now.Month,DateTime.Now.Year));
        }

        public ActionResult PegarJornadasColaborador(int registroColaborador)
        {
            List<JornadaColaborador> jornadas = new JornadaColaboradorBO().JornadasDoColaborador(registroColaborador);

            return Json(new SelectList(jornadas,"registro","FK_Turno.descricao"));
        }

        public ActionResult SalvarRegistroHora(int jornada, DateTime data, string hora, string Observacao)
        {
            try
            {
                
                string[] strHora = hora.Split(':');
                data = data.AddHours(double.Parse(strHora[0]));
                data = data.AddMinutes(double.Parse(strHora[1]));


                RegistroHoras.DATA.RegistroHoras regHora; 

                //verifica se existe registro para jornada no dia, se existir registra como saída
                regHora = DAO.RegistroJornadaData(jornada, data);
                if (regHora != null)
                {
                    regHora.saida = data;
                    if (Observacao != "" && Observacao != null)
                        regHora.Observacao += Observacao;
                }
                  
                    
            
                else
                    regHora = new DATA.RegistroHoras(jornada, data, Observacao);
             

                DAO.SalvarRegistroHoras(regHora);
                return RedirectToAction("Index", "Home").ComMensagem("Registro realizado com sucesso!", "alert-success") ;

            }
            catch(Exception ex) 
            {
                return View("RegistroHoraColaborador").ComMensagem(ex.Message, "alert-erro");
            }
           
            
        }

   
        public ActionResult ExcluirRegistroHora(int registroHora, string caminho)
        {
            
            RegistroHoras.DATA.RegistroHoras regHora = DAO.GetRegistroHora(registroHora);
            int colaborador = regHora.FK_JornadaColaborador.colaborador;
            int mes = regHora.entrada.Month;
            int ano = regHora.entrada.Year;
            string[] path = caminho.Split('/');
            try
            {
                DAO.ExcluirRegistroHoras(DAO.GetRegistroHora(registroHora));

                return View(path[3],DAO.RegistroHorasColaboradorMes(colaborador,mes,ano));
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return View(path[3], DAO.RegistroHorasColaboradorMes(colaborador, mes,ano));
            }
        }


        public PartialViewResult ConsultarRegistroHorasMes(int registroColaborador,int Mes, int Ano)
        {

            return PartialView("PartialRegistroHorasMes", DAO.RegistroHorasColaboradorMes(registroColaborador, Mes, Ano));
        }


   

        public ActionResult ListarHorasRegistradasColaborador(int registroColaborador)
        {
            return View(new ColaboradorBO().GetColaborador(registroColaborador));
        }
    }
}