using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class DetalleMovimientoConfiguration : IEntityTypeConfiguration<DetalleMovimientoInventario>
    {
        public void Configure(EntityTypeBuilder<DetalleMovimientoInventario> builder)
        {
            builder.ToTable("DetalleMovimientoInventario");
        builder.HasKey(e=>e.Id);
        builder.Property(e=>e.Id);

        builder.Property(p=>p.Cantidad);
        builder.Property(o=>o.Precio);


        builder.HasOne(p=>p.MovimientosInventarios)
        .WithMany(p=>p.DetallesMovimientosInventarios)
        .HasForeignKey(p=>p.IdMovimientoInventario);

        builder.HasOne(p=>p.Inventarios)
        .WithMany(p=>p.DetallesMovimientosInventarios)
        .HasForeignKey(p=>p.IdInventario);
        }
    }
}