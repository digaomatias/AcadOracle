using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcadOracle.DomainModel.Models.Mapping
{
    public class TurmaHorarioMap : EntityTypeConfiguration<TurmaHorario>
    {
        public TurmaHorarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("TurmaHorario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TurmaId).HasColumnName("TurmaId");
            this.Property(t => t.DiaSemana).HasColumnName("DiaSemana");

            // Relationships
            this.HasRequired(t => t.Turma)
                .WithMany(t => t.TurmaHorarios)
                .HasForeignKey(d => d.TurmaId);

        }
    }
}
