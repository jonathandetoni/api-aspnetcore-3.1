using Api.Domain.Entities.CadastrosGerais;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            //Nome da Tabela
            builder.ToTable("user");

            //Chave primaria
            builder.HasKey(p => p.Id);

            //Criando um index
            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.SenhaHash);

            builder.Property(u => u.SenhaSalt);
        }
    }
}
