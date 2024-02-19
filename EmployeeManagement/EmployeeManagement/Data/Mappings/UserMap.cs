using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Tabela
            builder.ToTable("User");

            // Chave Primária
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId)
                    .UseIdentityColumn();

            // Colunas
            builder.Property(x => x.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("nvarchar")
                .HasMaxLength(80);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            builder.Property(x => x.Enabled)
                .IsRequired()
                .HasColumnName("Enabled")
                .HasColumnType("boolean");

        }
    }
}
