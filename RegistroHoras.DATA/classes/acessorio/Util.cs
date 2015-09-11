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

            dias = DateTime.DaysInMonth(ano, mes);

            for (int i = 1; i < dias; i++)
            {
                DateTime data = new DateTime(ano,mes,i);

                if (data.DayOfWeek != DayOfWeek.Sunday && data.DayOfWeek != DayOfWeek.Saturday)

                    diasUteis++;

            }

            return diasUteis;

        }

    }
}
