using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AcadOracle.DomainModel.Models.Mapping;

namespace AcadOracle.DomainModel.Models
{
    public partial class AcadOracleDBContext : DbContext
    {
        static AcadOracleDBContext()
        {
            Database.SetInitializer<AcadOracleDBContext>(null);
        }

        public AcadOracleDBContext()
            : base("Name=AcadOracleDBContext")
        {
        }

        public DbSet<Curso> Cursoes { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaHorario> TurmaHorarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CursoMap());
            modelBuilder.Configurations.Add(new DisciplinaMap());
            modelBuilder.Configurations.Add(new HorarioMap());
            modelBuilder.Configurations.Add(new TipoUsuarioMap());
            modelBuilder.Configurations.Add(new TurmaMap());
            modelBuilder.Configurations.Add(new TurmaHorarioMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
