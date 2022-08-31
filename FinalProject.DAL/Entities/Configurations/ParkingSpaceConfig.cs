using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities.Configurations
{
    public class ParkingSpaceConfig : IEntityTypeConfiguration<ParkingSpace>
    {
        public void Configure(EntityTypeBuilder<ParkingSpace> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Area)
                .HasColumnType("nvarchar(5)")
                .HasMaxLength(5)
                .IsRequired();

            builder.Property(x => x.Occupied)
                .IsRequired();

            builder.Property(x => x.PricePerHour)
                .HasColumnType("decimal(4,2)")
                .IsRequired();

            builder.HasOne(p => p.Car) 
                .WithOne(p => p.ParkingSpace)
                .HasForeignKey<ParkingSpace>(p => p.CarId);

        }
    }
}
