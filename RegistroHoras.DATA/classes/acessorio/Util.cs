using RegistroHoras.DATA.classes.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.acessorio
{
    public class Util
    {

        public static int TotalDiasUteisMes(int mes, int ano)
        {
            int dias = 0;
            int diasUteis = 0;
            int feriadosMes = new DiaNaoUtilBO().GetDiasNaoUteisMes(mes, ano).Count();
            dias = DateTime.DaysInMonth(ano, mes);

            for (int i = 1; i < dias; i++)
            {
                DateTime data = new DateTime(ano,mes,i);

                if (data.DayOfWeek != DayOfWeek.Sunday && data.DayOfWeek != DayOfWeek.Saturday)

                    diasUteis++;

            }

            return diasUteis - feriadosMes;

        }

        public static string RetornaStringHorasMinutos(double hora)
        {
            decimal m = Math.Abs((decimal)hora) % 1;

            string horas, minutos = "00";

            string[] strHoras = hora.ToString().Split(',');

            horas = strHoras[0];

            if (strHoras.Length == 2)
            {
                int resultado = (int.Parse(strHoras[1].PadRight(2,'0')) * 60) / 100;

                if (resultado >= 60)
                {
                    horas = (int.Parse(strHoras[0]) + 1).ToString();
                }
                else
                    minutos = resultado.ToString();

            }
               

            
            return horas + " hora(s) e " + minutos + " minuto(s)";
        }

    }
}
