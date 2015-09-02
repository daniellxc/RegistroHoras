namespace RegistroHoras.DATA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<JornadaColaborador> JornadaColaborador { get; set; }
        public virtual DbSet<RegistroHoras> RegistroHoras { get; set; }
        public virtual DbSet<StatusRegistro> StatusRegistro { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colaborador>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Colaborador>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Colaborador>()
                .HasMany(e => e.JornadaColaborador)
                .WithRequired(e => e.FK_Colaborador)
                .HasForeignKey(e => e.colaborador)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<JornadaColaborador>()
            //    .HasMany(e => e.RegistroHoras)
            //    .WithRequired(e => e.FK_JornadaColaborador)
            //    .HasForeignKey(e => e.jornadaColaborador)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusRegistro>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<StatusRegistro>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            //modelBuilder.Entity<StatusRegistro>()
            //    .HasMany(e => e.RegistroHoras)
            //    .WithRequired(e => e.FK_StatusRegistro)
            //    .HasForeignKey(e => e.statusRegistro)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turno>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Turno>()
                .HasMany(e => e.JornadaColaborador)
                .WithRequired(e => e.FK_Turno)
                .HasForeignKey(e => e.turno)
                .WillCascadeOnDelete(false);
        }
    }
}
