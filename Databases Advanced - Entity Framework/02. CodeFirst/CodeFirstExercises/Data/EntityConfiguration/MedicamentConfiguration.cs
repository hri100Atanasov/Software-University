using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityConfiguration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(k => k.MedicamentId);

            builder.Property(n => n.Name).IsUnicode().HasMaxLength(50);

            builder.HasMany(x => x.Prescriptions).WithOne(x => x.Medicament).HasForeignKey(x => x.MedicamentId);
        }
    }
}
