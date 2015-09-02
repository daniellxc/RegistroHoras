using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistroHoras.WEB.Content
{
    public static class Utils
    {
        public static Dictionary<string, int> MesesDoAno()
        {
            Dictionary<string, int> meses = new Dictionary<string, int>();
            meses.Add("Janeiro", 1);
            meses.Add("Fevereiro", 2);
            meses.Add("Março", 3);
            meses.Add("Abril", 4);
            meses.Add("Maio", 5);
            meses.Add("Junho", 6);
            meses.Add("Julho", 7);
            meses.Add("Agosto", 8);
            meses.Add("Setembro", 9);
            meses.Add("Outubro", 10);
            meses.Add("Novembro", 11);
            meses.Add("Desembro", 12);
            return meses;
        }
    }
}