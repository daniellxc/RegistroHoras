namespace RegistroHoras.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Turno")]
    public partial class Turno
    {
        public Turno()
        {
            JornadaColaborador = new HashSet<JornadaColaborador>();
        }

        [Key]
        public int registro { get; set; }

        [Required]
        [StringLength(20)]
        public string descricao { get; set; }

        [Required]
        public DateTime horaInicio { get; set; }

        [Required]
        public DateTime horaFim { get; set; }

        public bool ativo { get; set; }

        public virtual ICollection<JornadaColaborador> JornadaColaborador { get; set; }
    }
}
