namespace RegistroHoras.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JornadaColaborador")]
    public partial class JornadaColaborador
    {
        public JornadaColaborador()
        {
           // RegistroHoras = new HashSet<RegistroHoras>();
        }

        public JornadaColaborador(int registroColaborador)
        {
            this.colaborador = registroColaborador;
            
        }

        [Key]
        public int registro { get; set; }
        
        
	    [Required(ErrorMessage="campo obrigatório")]
        [DisplayFormat(DataFormatString="{0:t}")]
        [DataType(DataType.Time,ErrorMessage="informe a hora no formato HH:MM")]
        public DateTime? horaEntrada { get; set; }


        [Required(ErrorMessage = "campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "informe a hora no formato HH:MM")]
        public DateTime? horaSaida { get; set; }

        public int turno { get; set; }

        public int colaborador { get; set; }

        public bool ativo { get; set; }

        [ForeignKey("colaborador")]
        public virtual Colaborador FK_Colaborador { get; set; }
       
        [ForeignKey("turno")]
        public virtual Turno FK_Turno { get; set; }

        //public virtual ICollection<RegistroHoras> RegistroHoras { get; set; }
    }
}
