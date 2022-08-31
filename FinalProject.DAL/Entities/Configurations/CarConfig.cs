using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LicensePlateNumber)
                .HasColumnType("nvarchar(25)")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.Manufacturer)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30);
            
            builder.Property(x => x.Model)
                .HasColumnType("nvarchar(35)")
                .HasMaxLength(35);
            
            builder.Property(x => x.Colour)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20);

            builder.HasOne(p => p.Client)
                .WithMany(p => p.Cars)
                .HasForeignKey(p => p.ClientId)
                .IsRequired();

        }

    }
}
