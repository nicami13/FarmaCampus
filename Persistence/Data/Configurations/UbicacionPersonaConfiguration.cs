using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class UbicacionPersonaConfiguration : IEntityTypeConfiguration<UbicacionPersona>
    {
        public void Configure(EntityTypeBuilder<UbicacionPersona> builder)
        {
            builder.ToTable("UbicacionPersona"); 
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.TipoDeVia)
                .HasMaxLength(50); 

            builder.Property(p => p.NumeroPri);

            builder.Property(p => p.Letra)
                .HasMaxLength(2); 

            builder.Property(p => p.Bis)
                .HasMaxLength(10); 

            builder.Property(p => p.LetraSec)
                .HasMaxLength(2); 

            builder.Property(p => p.Cardinal)
                .HasMaxLength(10); 

            builder.Property(p => p.NumeroSec);

            builder.Property(p => p.LetraTer)
                .HasMaxLength(2); 

            builder.Property(p => p.NumeroTer);

            builder.Property(p => p.CardinalSec)
                .HasMaxLength(10); 

            builder.Property(p => p.Complemento)
                .HasMaxLength(255); 

            builder.Property(p => p.CodigoPostal)
                .HasMaxLength(10); 

            builder.HasOne(p => p.Ciudades)
                .WithMany(p=>p.UbicacionPersonas)
                .HasForeignKey(p => p.IdCiudad);

            builder.HasOne(p => p.Personas)
                .WithMany(p=>p.UbicacionPersonas)
                .HasForeignKey(p => p.IdPersona);
        }
    }
}