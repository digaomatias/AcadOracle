using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcadOracle.DomainModel.Models.Mapping
{
    public class DisciplinaMap : EntityTypeConfiguration<Disciplina>
    {
        public DisciplinaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Disciplina");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Creditos).HasColumnName("Creditos");
            this.Property(t => t.PreCreditos).HasColumnName("PreCreditos");
            this.Property(t => t.Semestre).HasColumnName("Semestre");
            this.Property(t => t.Eletiva).HasColumnName("Eletiva");

            // Relationships
            this.HasMany(t => t.PreRequisitos)
                .WithMany(t => t.RequisitoPara)
                .Map(m =>
                    {
                        m.ToTable("DisciplinasPreRequisitos");
                        m.MapLeftKey("DisciplinaId");
                        m.MapRightKey("PreRequisitoId");
                    });


        }
    }
}
