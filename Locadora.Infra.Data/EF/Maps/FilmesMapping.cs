using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.EF.Maps
{
    public class FilmesMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
          //  builder.ToTable("Filmes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.ClassificacaoIndicativa)
                .IsRequired();

            builder.Property(x => x.Lancamento)
                .IsRequired();
        }
    }
}
