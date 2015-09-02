using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    public class StatusRegistroBO
    {
        #region DAO

        private class StatusRegistroDAO : AbstractDAO<StatusRegistro> { }

        #endregion

        StatusRegistroDAO DAO = new StatusRegistroDAO();

        #region Consultas

        public List<StatusRegistro> TodosStatusRegistro()
        {
            return DAO.GetAll();
        }



        #endregion


        #region Métodos Gerais

       

        #endregion

    }
}
