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
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.CadastradoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.Titulo).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(x => x.DataPublicacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.Isbn10).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Isbn13).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Idioma).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(600)").IsRequired();
            builder.Property(x => x.QuantidadePaginas).HasColumnType("INT").IsRequired();
            builder.Property(x => x.Imagem).HasColumnType("VARCHAR(600)");
            builder.Property(x => x.Valor).HasColumnType("MONEY");
            builder.HasOne(l => l.Autor)
                .WithMany(a => a.Livros)
                .HasPrincipalKey(a => a.Id);
            builder.HasMany(l => l.Alugueis);
        }
    }
}
