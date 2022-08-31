using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities.Configurations
{
    public class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                .HasColumnType("nvarchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Discount)
                .HasColumnType("decimal(2,2)")
                .IsRequired();
            
        }
    }
}
