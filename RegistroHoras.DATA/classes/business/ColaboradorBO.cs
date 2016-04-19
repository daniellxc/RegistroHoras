using RegistroHoras.DATA.classes.acessorio;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    public class ColaboradorBO
    {

       

        #region DAO

        private class ColaboradorDAO:AbstractDAO<Colaborador>
        {
            

        }


        #endregion

      
      


        ColaboradorDAO DAO = new ColaboradorDAO();

        public Colaborador GetColaborador(int registro)
        {
            return DAO.Get(registro);
        }

        public List<Colaborador> TodosColaboradores()
        {
            return DAO.GetAll();
        }

        public List<Colaborador> Find(Expression<Func<Colaborador,bool>> where)
        {
            return DAO.Find(where);
        }

        public List<Colaborador> Consultar(string nome)
        {
            return DAO.Find(colab => colab.nome.Contains(nome));
        }

        public List<Colaborador> ConsultarCpf(string cpf)
        {
            return DAO.Find(colab => colab.cpf.Equals(cpf));
        }

        public void SalvarColaborador(Colaborador colaborador)
        {
            try
            {
                if (colaborador.registro == 0)
                {
                    DAO.Add(colaborador);
                    DAO.CommitChanges();
                }
                else
                {
                    DAO.Update(colaborador, colaborador.registro);
                }


            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(colaborador);

            }
            catch
            {
                throw new Exceptions.ErroAoSalvar(colaborador);
            }

        }

        public void Excluir(Colaborador colaborador)
        {
            try
            {
                DAO.Delete(colaborador);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(colaborador);
            }
            catch
            {
                throw new Exceptions.ErroDesconhecido();
            }
        }

        #region Consultas
        /// <summary>
        /// Retorna a quantidade de horas a serem trabalhadas no mes
        /// </summary>
        /// <param name="registroColaborador"></param>
        /// <param name="mes"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        public int RegimeDoMes(int registroColaborador, int mes, int ano)
        {
            //total de dias uteis menos os feriados registrados
             int totalDias = Util.TotalDiasUteisMes(mes, ano) - new DiaNaoUtilBO().GetDiasNaoUteisMes(mes, ano).Count;
             return totalDias * this.GetColaborador(registroColaborador).regimeDiario;
        }

        public TimeSpan HorasUteisMes(int registroColaborador, int mes, int ano)
        {
            
            return new TimeSpan(RegimeDoMes(registroColaborador,mes,ano),0,0);
            
        }

        #endregion


    }
}
