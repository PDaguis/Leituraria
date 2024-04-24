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
    public class AluguelConfiguration : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("Aluguel");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.CadastradoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.AlugadoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.DevolverEm).HasColumnType("DATETIME").IsRequired();
            builder.HasOne(x => x.Cliente)
                .WithMany(c => c.Alugueis)
                .HasPrincipalKey(p => p.Id);
            builder.HasMany(x => x.Livros);
        }
    }
}
