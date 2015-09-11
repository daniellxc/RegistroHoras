using RegistroHoras.DATA.classes.acessorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    public class RegistroHorasBO
    {
        #region DAO

        private class RegistroHorasDAO : AbstractDAO<RegistroHoras>
        {


           
        }

        #endregion

        RegistroHorasDAO DAO = new RegistroHorasDAO();

        public RegistroHoras GetRegistroHora(int registro)
        {
            return DAO.Get(registro);
        }

        public void SalvarRegistroHoras(RegistroHoras registroHora)
        {
            try
            {
                if(registroHora.registro==0)
                {
                    registroHora.saida = DateTime.Parse("1900-01-01");
                    DAO.Add(registroHora);
                    DAO.CommitChanges();
                }else
                {
                    DAO.Update(registroHora,registroHora.registro);
                }

            }
            catch (DbUpdateException) { throw new Exceptions.ErroAoAtualizar(registroHora);}
            catch (Exception) { throw new Exceptions.ErroAoSalvar(registroHora); }

        }

        public void ExcluirRegistroHoras(RegistroHoras registroHora)
        {
            try
            {

                DAO.Delete(registroHora);
            }
            catch (DbUpdateException) { throw new Exceptions.ErroAoExcluir(registroHora); }
            catch (Exception) { throw new Exceptions.ErroDesconhecido(); }

        }

        #region Consultas

        /// <summary>
        /// Retorna todos os registros de horas do colaborador
        /// </summary>
        /// <param name="registroColaborador"></param>
        /// <returns></returns>
        public List<RegistroHoras> RegistroHorasColaborador(int registroColaborador)
        {
            return DAO.Find(rh => rh.FK_JornadaColaborador.colaborador == registroColaborador);
        }

        public List<RegistroHoras> RegistroHorasColaboradorData(int registroColaborador, DateTime data)
        {
            return RegistroHorasColaborador(registroColaborador).Where(r => r.entrada.Date == data).ToList();
        }





        /// <summary>
        /// Horas registradas pelo colaborador no mês
        /// </summary>
        /// <param name="registroColaborador"></param>
        /// <param name="mes"></param>
        /// <returns></returns>
        public List<RegistroHoras> RegistroHorasColaboradorMes(int registroColaborador, int mes, int ano)
        {
            return DAO.Find(rh => rh.FK_JornadaColaborador.colaborador == registroColaborador && rh.entrada.Month == mes && rh.entrada.Year == ano);
        }


        /// <summary>
        /// Retorna o primeiro registro do colaborador para no dia atual
        /// </summary>
        /// <param name="registroJornadaColaborador"></param>
        /// <returns></returns>
        public RegistroHoras RegistroJornadaHoje(int registroJornadaColaborador)
        {
            try
            {
                return DAO.Find(rh => rh.jornadaColaborador == registroJornadaColaborador &&
                                  DbFunctions.TruncateTime(rh.entrada) == DbFunctions.TruncateTime(DateTime.Now)).First();
            }
            catch
            {
                return null;
            }
            
                     
        }

        /// <summary>
        /// Retorno o primeiro registros de horas do colaborador para a jornada informada na data.
        /// </summary>
        /// <param name="registroJornadaColaborador"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public RegistroHoras RegistroJornadaData(int registroJornadaColaborador, DateTime data)
        {
            try
            {
                return DAO.Find(rh => rh.jornadaColaborador == registroJornadaColaborador &&
                                  DbFunctions.TruncateTime(rh.entrada) == DbFunctions.TruncateTime(data)).First();
            }
            catch
            {
                return null;
            }


        }

        public TimeSpan TotalHorasMes(int registroColaborador, int mes, int ano)
        {
            try
            {
                TimeSpan retorno = new TimeSpan(0,0,0);

                foreach (RegistroHoras rh in this.RegistroHorasColaboradorMes(registroColaborador, mes, ano))
                {
                    if (rh.saida.TimeOfDay != new TimeSpan(0,0,0))
                        retorno += rh.saida.TimeOfDay - rh.entrada.TimeOfDay;
                }

                return retorno;
            }
            catch
            {
                throw new Exception("Erro ao calcular as horas acumuladas no mês.");
            }
        }

        public string StringPercentualHorasMes(int registroColaborador, int mes, int ano)
        {
            if (TotalHorasMes(registroColaborador, mes, ano) != new TimeSpan(0, 0, 0))
            {
                Double percent = Math.Round((Math.Round(TotalHorasMes(registroColaborador,mes,ano).TotalHours, 2) / new ColaboradorBO().RegimeDoMes(registroColaborador,mes,ano)) * 100, 2);
                return percent.ToString().Replace(',', '.') + "%";
            }
            return "0%";
        }

        #endregion

        #region Métodos Gerais



        #endregion

    }
}
