using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcadOracle.DomainModel.Models.Mapping
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Turma");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DisciplinaId).HasColumnName("DisciplinaId");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.TurmaHorario).HasColumnName("TurmaHorario").HasMaxLength(50);
            this.Ignore(t => t.TurmaHorarios);

            // Relationships
            this.HasRequired(t => t.Disciplina)
                .WithMany(t => t.Turmas)
                .HasForeignKey(d => d.DisciplinaId);

        }
    }
}
