using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AcadOracle.DomainModel.Models.Mapping
{
    public class TipoUsuarioMap : EntityTypeConfiguration<TipoUsuario>
    {
        public TipoUsuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descricao)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TipoUsuario");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
        }
    }
}
