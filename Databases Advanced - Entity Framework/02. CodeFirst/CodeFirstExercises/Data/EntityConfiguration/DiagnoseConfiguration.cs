using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityConfiguration
{
    public class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(d => d.DiagnoseId);
            builder.Property(n => n.Name).IsUnicode().HasMaxLength(50);
            builder.Property(c => c.Comments).IsUnicode().HasMaxLength(250);
        }
    }
}
