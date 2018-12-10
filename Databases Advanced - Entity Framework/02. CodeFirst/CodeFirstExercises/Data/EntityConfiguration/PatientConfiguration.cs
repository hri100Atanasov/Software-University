using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityConfiguration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(k => k.PatientId);

            builder.Property(fn => fn.FirstName).HasMaxLength(50).IsUnicode();
            builder.Property(ln => ln.LastName).HasMaxLength(50).IsUnicode();
            builder.Property(a => a.Address).HasMaxLength(250).IsUnicode();
            builder.Property(e => e.Email).HasMaxLength(80).IsUnicode(false);
            builder.HasMany(p => p.Prescriptions).WithOne(p => p.Patient).HasForeignKey(p => p.PatientId);
            builder.HasMany(d => d.Diagnoses).WithOne(p => p.Patient).HasForeignKey(p => p.PatientId);
            builder.HasMany(v => v.Visitations).WithOne(p => p.Patient).HasForeignKey(p => p.PatientId);
        }
    }
}
