using RegistroHoras.DATA.classes.acessorio;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    public class JornadaColaboradorBO
    {

        #region DAO

        private class JornadaColaboradorDAO : AbstractDAO<JornadaColaborador>
        {

        }

        #endregion

        private JornadaColaboradorDAO DAO = new JornadaColaboradorDAO();
        
        #region Consultas

        public List<JornadaColaborador> JornadasDoColaborador(int registroColaborador)
        {
            return DAO.Find(jc => jc.colaborador == registroColaborador);
        }
        #endregion


        public void SalvarJornada(JornadaColaborador jornadaColaborador)
        {
            try
            {
                if (jornadaColaborador.registro == 0)
                {
                    DAO.Add(jornadaColaborador);
                    DAO.CommitChanges();
                }
                else
                {
                    DAO.Update(jornadaColaborador, jornadaColaborador.registro);
                }
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(jornadaColaborador);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroAoSalvar(jornadaColaborador);
            }
        }

        public void ExcluirJornada(JornadaColaborador jornadaColaborador)
        {
            try
            {
                DAO.Delete(jornadaColaborador);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(jornadaColaborador);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroDesconhecido();
            }
        }



        public JornadaColaborador GetJornadaColaborador(int registro)
        {
            return DAO.Get(registro);
        }
    }
}
