using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcadOracle.DomainModel.Models.Mapping
{
    public class HorarioMap : EntityTypeConfiguration<Horario>
    {
        public HorarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descricao)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("Horario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            // Relationships
            this.HasMany(t => t.TurmaHorarios)
                .WithMany(t => t.Horarios)
                .Map(m =>
                    {
                        m.ToTable("HoraAula");
                        m.MapLeftKey("HorarioId");
                        m.MapRightKey("TurmaHorarioId");
                    });


        }
    }
}
