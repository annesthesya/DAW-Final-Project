using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities.Configurations
{
    public class ClientSubscriptionConfig : IEntityTypeConfiguration<ClientSubscription>
    {
        public void Configure(EntityTypeBuilder<ClientSubscription> builder)
        {
            
            builder.HasOne(p => p.Client)
                .WithMany(p => p.ClientSubscriptions)
                .HasForeignKey(p => p.ClientId)
                .IsRequired();

            builder.HasOne(p => p.Subscription)
                .WithMany(p => p.ClientSubscriptions)
                .HasForeignKey(p => p.SubscriptionId)
                .IsRequired();

            builder.Property(x => x.CarLicensePlate)
                .HasColumnType("nvarchar(25)")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .HasColumnType("Date")
                .IsRequired();
            
            builder.Property(x => x.EndDate)
                .HasColumnType("Date")
                .IsRequired();
            
            builder.Property(x => x.Total)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

        }
    }
}
