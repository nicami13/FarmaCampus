using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations;

    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Depatamento");
        builder.HasKey(e=>e.Id);
        builder.Property(e=>e.Id);

        builder.Property(p=>p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(p=>p.Paises)
        .WithMany(p=>p.Departamentos)
        .HasForeignKey(p=>p.Idpais);



        }


    }
