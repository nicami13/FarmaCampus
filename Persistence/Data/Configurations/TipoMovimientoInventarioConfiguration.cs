using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class TipoMovimientoInventarioConfiguration : IEntityTypeConfiguration<TipoMovimientoInventario>
    {
        public void Configure(EntityTypeBuilder<TipoMovimientoInventario> builder)
        {
            builder.ToTable("TipoMovimientoInventario");
        builder.HasKey(e=>e.Id);
        builder.Property(e=>e.Id);

        builder.Property(p=>p.Nombre)
        .HasMaxLength(50);
        }
    }
}