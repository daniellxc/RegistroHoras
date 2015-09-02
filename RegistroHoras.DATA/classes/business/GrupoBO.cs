using RegistroHoras.DATA.classes;
using RegistroHoras.DATA.classes.acessorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    public class GrupoBO
    {
        #region DAO

        private class GrupoDAO : AbstractDAO<Grupo>
        {

        }

        private GrupoDAO DAO = new GrupoDAO();

        #endregion

        public Grupo GetGrupo(int registroGrupo)
        {

            return DAO.Get(registroGrupo);
            
        }

        public List<Grupo> GetGruposAtivos()
        {
            return DAO.GetAll().Where(g => g.ativo).ToList();
        }

        public List<Grupo> GetGruposDisponiveis(int colaborador)
        {
            using (Context context = new Context())
            {
                var retorno = from grupos in context.Grupos select grupos;

                return retorno.ToList<Grupo>().Except(context.Usuarios.Find(colaborador).Grupos).ToList();
            }
        }

        public void AddUsuarioAoGrupo(int registroUsuario, int registroGrupo)
        {
            using (Context context = new Context())
            {
                Grupo grp = context.Grupos.Find(registroGrupo) ;

                if (grp == null) throw new Exceptions.ErroDesconhecido("Grupo de usuário inexistente");

                grp.Usuarios.Add(context.Usuarios.Find(registroUsuario));
                context.SaveChanges();

            }
        }

        public void RemoverUsuarioDoGrupo(int registroUsuario, int registroGrupo)
        {
            using (Context context = new Context())
            {
                Grupo grp = context.Grupos.Find(registroGrupo);

                grp.Usuarios.Remove(context.Usuarios.Find(registroUsuario));
                context.SaveChanges();

            }
        }
    
    }
}
