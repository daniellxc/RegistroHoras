using RegistroHoras.DATA.classes.acessorio;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.business
{
    public class UsuarioBO
    {
        #region DAO

        private class UsuarioDAO : AbstractDAO<Usuario> { }

        UsuarioDAO DAO = new UsuarioDAO();
        #endregion

        public List<Usuario> GetAll()
        {
            return DAO.GetAll();
        }

        public void SalvarUsuario(Usuario usuario)
        {
            try
            {
                Usuario aux = Get(usuario.COLABORADOR);
                if (aux == null)
                {
                    DAO.Add(usuario);
                    DAO.CommitChanges();
                }
                else
                    throw new Exceptions.ErroAoSalvar("Já existe um usuário vinculado a este colaborador.");

            }
            catch (DbUpdateException) { throw new Exceptions.ErroAoAtualizar(usuario); }
            catch (Exception) { throw new Exceptions.ErroAoSalvar(usuario); }
        }

        public void AlterarSenha(int colaborador, string senha)
        {
            try
            {
                Usuario usr = Get(colaborador);
                usr.Senha = senha;
                DAO.Update(usr, usr.COLABORADOR);
            }
            catch (Exception ex)
            {
                throw new Exceptions.ErroDesconhecido("Erro ao alterar a senha. " + ex.Message);
            }
            

        }

        public void ExcluirUsuario(Usuario usuario)
        {
            try
            {
                DAO.Delete(usuario);
            }
            catch (DbUpdateException) { throw new Exceptions.ErroAoExcluir(usuario); }
            catch (Exception) { throw new Exceptions.ErroDesconhecido(); }
        }

        public Usuario Get(int colaborador)
        {
            return DAO.Get(colaborador);
        }

        public Usuario GetUsuario(string login, string senha)
        {
            return DAO.Find(u => u.Login == login && u.Senha == senha).SingleOrDefault();
        }

    
    }
}