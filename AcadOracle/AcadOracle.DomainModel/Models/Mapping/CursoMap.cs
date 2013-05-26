using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcadOracle.DomainModel.Models.Mapping
{
    public class CursoMap : EntityTypeConfiguration<Curso>
    {
        public CursoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Curso");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");

            // Relationships
            this.HasMany(t => t.Disciplinas)
                .WithMany(t => t.Cursoes)
                .Map(m =>
                    {
                        m.ToTable("CursoDisciplina");
                        m.MapLeftKey("CursoId");
                        m.MapRightKey("DisciplinaId");
                    });


        }
    }
}
