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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(x => x.CadastradoEm).HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(x => x.Cpf).HasColumnType("VARCHAR(11)").IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("DATETIME");
            builder.HasMany(c => c.Enderecos);
            builder.HasMany(x => x.Alugueis);
        }
    }
}
