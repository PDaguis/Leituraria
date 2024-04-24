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
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.CadastradoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(300)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("DATETIME");
            builder.HasMany(x => x.Livros);
            builder.Property(x => x.Imagem).HasColumnType("VARCHAR(600)");
        }
    }
}
