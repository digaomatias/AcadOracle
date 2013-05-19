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
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Turma");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.DisciplinaId).HasColumnName("DisciplinaId");
            this.Property(t => t.Numero).HasColumnName("Numero");

            // Relationships
            this.HasRequired(t => t.Disciplina)
                .WithMany(t => t.Turmas)
                .HasForeignKey(d => d.DisciplinaId);

        }
    }
}
