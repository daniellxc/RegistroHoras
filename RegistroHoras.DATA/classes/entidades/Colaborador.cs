namespace RegistroHoras.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Colaborador")]
    public partial class Colaborador
    {
        public Colaborador()
        {
            JornadaColaborador = new HashSet<JornadaColaborador>();
        }

        [Key]
        public int registro { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [StringLength(14)]
        public string cpf { get; set; }

        [Display(Name="Horas Diárias")]
        [Required(ErrorMessage="campo obrigatório")]
        public int regimeDiario { get; set; }

   

        public virtual ICollection<JornadaColaborador> JornadaColaborador { get; set; }
    }
}
