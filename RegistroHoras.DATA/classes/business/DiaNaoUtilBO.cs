using RegistroHoras.DATA.classes.acessorio;
using RegistroHoras.DATA.classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    
    public class DiaNaoUtilBO
    {
        #region DAO

        private class DiaNaoUtilDAO:AbstractDAO<DiaNaoUtil>
        {
            public DiaNaoUtilDAO()
            {

            }
        }

        private DiaNaoUtilDAO DAO = new DiaNaoUtilDAO();

        #endregion

        public void Salvar(DiaNaoUtil diaNaoUtil)
        {
            try
            {
                if (diaNaoUtil.Registro.Equals(0))
                {
                    DAO.Add(diaNaoUtil);
                    DAO.CommitChanges();
                }
                else
                {
                    DAO.Update(diaNaoUtil, diaNaoUtil.Registro);
                }

            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoAtualizar(diaNaoUtil);
            }
            catch (Exception)
            {
                throw new Exceptions.ErroAoSalvar(diaNaoUtil);
            }

        }

        public void Excluir(DiaNaoUtil diaNaoUtil)
        {
            try
            {
                DAO.Delete(diaNaoUtil);
            }
            catch (DbUpdateException)
            {
                throw new Exceptions.ErroAoExcluir(diaNaoUtil);
            }
            catch(Exception)
            {
                throw new Exceptions.ErroAoExcluir(diaNaoUtil);
            }
                
        }

        public List<DiaNaoUtil> GetDiasNaoUteisMes(int mes, int ano)
        {
            return DAO.Find(d => (d.Mes == mes && d.Permanente) || (d.Mes == mes && d.Ano == ano));
        }

        public DiaNaoUtil Get(int registro)
        {
            return DAO.Get(registro);
        }

        public List<DiaNaoUtil> GetAll()
        {
            return DAO.GetAll().OrderBy(d=>d.Mes).ThenBy(d=>d.Dia).ToList();
        }

    }
}
