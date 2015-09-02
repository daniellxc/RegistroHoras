using RegistroHoras.DATA.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int COLABORADOR { get; set; }

        [Column("login")]
        [Required(ErrorMessage="informe um login para o usuário")]
        public string Login { get; set; }

        [Column("senha")]
        [Required(ErrorMessage = "informe a senha do usuário")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

        #region ForeignKey

        [ForeignKey("COLABORADOR")]
        public virtual Colaborador FK_Colaborador { get; set; }

        public virtual List<Grupo> Grupos { get; set; }

        #endregion
    }
}
