namespace RegistroHoras.DATA
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistroHoras")]
    public  class RegistroHoras
    {
        

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("registro")]
        public long registro { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("entrada")]
        public DateTime entrada { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("saida")]
        public DateTime saida { get; set; }

        [Column("jornadaColaborador")]
        [Required(ErrorMessage="campo obrigatório")]
        public int jornadaColaborador { get; set; }

        [Column("observacao")]
        public string Observacao { get; set; }


        [ForeignKey("jornadaColaborador")]
        public virtual JornadaColaborador FK_JornadaColaborador { get; set; }

     //   public virtual StatusRegistro FK_StatusRegistro { get; set; }

        #region Construtores

        public RegistroHoras()
        {

        }

        public RegistroHoras(int jornadaColaborador, DateTime dataHora, string observacao)
        {
            this.entrada = dataHora;
            this.jornadaColaborador = jornadaColaborador;
            this.Observacao = observacao;
         
        }

       

        #endregion
    }
}
