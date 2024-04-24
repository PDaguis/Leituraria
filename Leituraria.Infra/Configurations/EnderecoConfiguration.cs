using Leituraria.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leituraria.Infra.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.CadastradoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.Numero).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Bairro).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(x => x.Cidade).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(x => x.Estado).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(x => x.Cep).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Pais).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Complemento).HasColumnType("VARCHAR(200)");
            builder.HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
