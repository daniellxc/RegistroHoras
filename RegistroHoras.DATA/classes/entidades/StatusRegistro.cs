namespace RegistroHoras.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusRegistro")]
    public partial class StatusRegistro
    {
        public StatusRegistro()
        {
         
        }

        [Key]
        public int registro { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [StringLength(255)]
        public string descricao { get; set; }

      
    }
}
