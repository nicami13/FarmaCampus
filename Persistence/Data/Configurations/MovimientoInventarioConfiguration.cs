using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class MovimientoInventarioConfiguration : IEntityTypeConfiguration<MovimientoInventario>
    {
        public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
        {
            builder.ToTable("MovimientoInventario");
        builder.HasKey(e=>e.Id);
        builder.Property(e=>e.Id);

        builder.Property(p=>p.FechaMovimiento);
        builder.Property(p=>p.FechaVencimiento);
        
        builder.HasOne(p=>p.TiposMovimientosInventarios)
        .WithMany(p=>p.MovimientoInventarios)
        .HasForeignKey(p=>p.IdTipoMovimientoInventario);

        builder.HasOne(p=>p.Personas)
        .WithMany(p=>p.MovimientoInventarios)
        .HasForeignKey(p=>p.IdResponsable);


        }
    }
}