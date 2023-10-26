using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto
    >
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
        builder.ToTable("Producto");
        builder.HasKey(e=>e.Id);
        builder.Property(e=>e.Id);

        builder.Property(p=>p.NombreProducto)
        .HasMaxLength(50);

        builder.HasOne(p=>p.Marcas)
        .WithMany(p=>p.Productos)
        .HasForeignKey(p=>p.IdMarca);
        }
    }
}