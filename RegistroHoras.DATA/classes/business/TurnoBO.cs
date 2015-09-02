using RegistroHoras.DATA.classes.acessorio;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    public class TurnoBO
    {
        #region DAO

        private class TurnoDAO : AbstractDAO<Turno>
        {


        }


        #endregion





        TurnoDAO DAO = new TurnoDAO();

        public List<Turno> TodosTurnos()
        {
            return DAO.GetAll();
        }

        public Turno GetTurno(int registro)
        {
            return DAO.Get(registro);
        }

        public List<Turno> TurnosAtivos()
        {
            return TodosTurnos().Where(t=>t.ativo).ToList();
        }
        public List<Turno> Consultar(string descricao)
        {
            return DAO.Find(turno => turno.descricao.Contains(descricao));
        }

     

        public void SalvarTurno(Turno turno)
        {
            try
            {
                if (turno.registro == 0)
                {
                    DAO.Add(turno);
                    DAO.CommitChanges();
                }
                else
                {
                    DAO.Update(turno, turno.registro);
                }


            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(turno);

            }
            catch
            {
                throw new Exceptions.ErroAoSalvar(turno);
            }

        }

        public void Excluir(Turno turno)
        {
            try
            {

            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(turno);
            }
            catch
            {
                throw new Exceptions.ErroDesconhecido();
            }
        }
    }
}
