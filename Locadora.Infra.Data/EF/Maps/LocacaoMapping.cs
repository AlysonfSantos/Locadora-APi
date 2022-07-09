

using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.EF.Maps
{
    public class LocacaoMapping : IEntityTypeConfiguration<Locacao>
    {

        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
          //  builder.ToTable("Locacao");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Cliente)
                .WithMany(x=> x.Locacao)
                .HasForeignKey(x => x.IdCliente)
                .IsRequired();

            builder.HasOne(x => x.Filme)
                .WithMany(x => x.Locacao)
                .HasForeignKey(x => x.IdFilmes)
                .IsRequired();


            builder.Property(x => x.DataLocacao)
                .IsRequired();

            builder.Property(x => x.DataDevolucao);
        }
    }
}
