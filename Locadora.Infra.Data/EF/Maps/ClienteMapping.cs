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
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {

        public void Configure(EntityTypeBuilder<Cliente> builder) 
        {
       //     builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);
          
            builder.Property(x => x.Nome)
               .HasMaxLength(200)
               .IsRequired();

            builder.Property(x => x.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .IsRequired();
            
        }
    }
}
