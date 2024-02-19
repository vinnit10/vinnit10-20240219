using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Data.Mappings
{
    public class CollaboratorMap : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            // Tabela
            builder.ToTable("Collaborator");

            // Chave Primária
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .UseIdentityColumn();

            // Colunas
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(80);

            builder.Property(x => x.UnitCode)
                .IsRequired()
                .HasColumnName("Code")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
        }
    }
}
