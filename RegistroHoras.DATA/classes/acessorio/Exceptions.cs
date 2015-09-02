using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes.acessorio
{
    public class Exceptions
    {
        public class ErroAoSalvar : Exception
        {
            public ErroAoSalvar(Object item) : base("Não foi possível salvar o item " + item.GetType().BaseType.Name + ". Verifique se os campos foram preenchidos corretamente") { }
            public ErroAoSalvar(string mensagem) : base(mensagem) { }
        }



        public class ErroAoExcluir : Exception
        {
            public ErroAoExcluir(Object item) : base("Não foi possível excluir o item " + item.GetType().BaseType.Name) { }
        }


        public class ErroAoAtualizar : Exception
        {
            public ErroAoAtualizar(Object item) : base("Não foi possível atualizar o item " + item.GetType().BaseType.Name + ". Verifique se os campos foram preenchidos corretamente") { }

        }


        public class ErroDesconhecido : Exception
        {
            public ErroDesconhecido() : base("Não foi possível concluir a operação.") { }
            public ErroDesconhecido(string mensagem) : base(mensagem) { }

        }
    }
}
