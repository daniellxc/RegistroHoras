using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA
{
   [Table("Grupo")]
    public class Grupo
    {
        [Key]
        public int registro { get; set; }

        [Required(ErrorMessage="campo obrigatório")]
        public string descricao { get; set; }

        [Required(ErrorMessage="campo obrigatório")]
        public bool ativo { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }
    }
}
