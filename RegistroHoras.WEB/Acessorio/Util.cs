using RegistroHoras.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistroHoras.WEB.Acessorio
{
    public class Util
    {
       public static string dia_semana(String dia)
        {
           switch (dia)
           {
               case "Sunday":
                   return "Domingo";
               case "Monday":
                   return "Segunda";
               case "Tuesday":
                   return "Terça";
               case "Wednesday":
                   return "Quarta";
               case "Thursday":
                   return "Quinta";
               case "Friday":
                   return "Sexta";
               default:
                   return "Sábado";
           }
       }
    }

    public class _Mes
    {
        public DateTime _data { get; set; }
        public _Mes(DateTime data) { _data = data; }
    }
    

}