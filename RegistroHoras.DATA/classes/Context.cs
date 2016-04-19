
using RegistroHoras.DATA.classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroHoras.DATA.classes
{
    public class Context:DbContext
    {
        #region DbSets

        public virtual DbSet<Colaborador> Colaboradores { get; set; }
        public virtual DbSet<DiaNaoUtil> DiasNaoUteis { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<JornadaColaborador> JornadasColaboradores { get; set; }
        public virtual DbSet<RegistroHoras> RegistroHoras { get; set; }
        public virtual DbSet<StatusRegistro> StatusRegistros { get; set; }
        public virtual DbSet<Turno> Turnos { get; set; }
        public virtual DbSet<Usuario> Usuarios{ get; set; }
        #endregion

        public Context() : base("Ponto") { }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grupo>()
                .HasMany<Usuario>(u => u.Usuarios)
                .WithMany(u => u.Grupos)
                .Map(ug =>  {
                             ug.ToTable("UsuarioGrupo");
                             ug.MapLeftKey("GRUPO");
                             ug.MapRightKey("USUARIO");
                }
                    );
            modelBuilder.Entity<Usuario>()
               .HasMany<Grupo>(u => u.Grupos)
               .WithMany(u => u.Usuarios)
               .Map(ug =>
               {
                   ug.ToTable("UsuarioGrupo");
                   ug.MapLeftKey("USUARIO");
                   ug.MapRightKey("GRUPO");
               }
                   );
            
        }
    }
}
