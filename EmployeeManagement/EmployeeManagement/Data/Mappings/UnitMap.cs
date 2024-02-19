using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Data.Mappings
{
    public class UnitMap : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            // Tabela
            builder.ToTable("Unit");

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

            builder.Property(x => x.Code)
                .IsRequired()
                .HasColumnName("Code")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.Enabled)
                .IsRequired()
                .HasColumnName("Enabled")
                .HasColumnType("boolean");
        }
    }
}
