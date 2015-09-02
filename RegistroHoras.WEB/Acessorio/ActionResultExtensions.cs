using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroHoras.WEB
{
    public static class ActionResultExtensions
    {
        public static ActionResult ComMensagem(this ActionResult actionResult, string mensagem, string classeAlert)
        {
            return new TempDataActionResult(actionResult, mensagem, classeAlert);
        }
    }
}