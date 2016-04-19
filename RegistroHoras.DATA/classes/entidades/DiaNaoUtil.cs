using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes
{
    [Table("DiaNaoUtil")]
    public class DiaNaoUtil
    {
    
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public int Registro { get; set; }

        [Column("nome")]
        [MaxLength(255)]
        [Required(ErrorMessage="Campo obrigatório")]
        public string Nome { get; set; }

        [Column("dia")]
        [Range(1,31,ErrorMessage="Apenas números de 1 a 31")]
        public int Dia { get; set; }

        [Column("mes")]
        [Range(1, 12, ErrorMessage = "Apenas números de 1 a 12")]
        public int Mes { get; set; }

        [Column("ano")]
        [Range(1900,2100)]
        public int Ano { get; set; }

        [Column("permanente")]
        public bool  Permanente { get; set; }

        public DateTime GetData
        {
            get
            {
                int ano = Permanente ? DateTime.Now.Year : Ano;
                return new DateTime(ano, Mes, Dia);
            }
        }
    }
}
