using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.configurations
{
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
    {
        public void Configure(EntityTypeBuilder<ContactoPersona> builder)
        {
            builder.ToTable("ContactoPersona");
        builder.HasKey(e=>e.Id);
        builder.Property(e=>e.Id);

        builder.HasOne(p=>p.Personas)
        .WithMany(p=>p.ContactosPersonas)
        .HasForeignKey(p=>p.IdPersona);

        builder.HasOne(p=>p.TiposContactos)
        .WithMany(p=>p.ContactosPersonas)
        .HasForeignKey(p=>p.IdTipoContacto);
        }
    }
}