using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
    {
        public void Configure(EntityTypeBuilder<Inventario> builder)
        {
            builder.ToTable("Inventario");
        builder.HasKey(e=>e.Id);
        builder.Property(e=>e.Id);

        builder.Property(p=>p.Nombre)
        .HasMaxLength(50);

        builder.Property(p=>p.Precio);
        builder.Property(p=>p.Stock);
        builder.Property(p=>p.StockMax);
        builder.Property(p=>p.StockMin);

        builder.HasOne(p=>p.Productos)
        .WithMany(p=>p.Inventarios)
        .HasForeignKey(p=>p.IdProducto);

        builder.HasOne(p=>p.Presentaciones)
        .WithMany(p=>p.Inventarios)
        .HasForeignKey(p=>p.IdPresentacion);
        }
    }
}