using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities.Configurations
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Created)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
            
            builder.Property(x => x.PhoneNo)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30);

        }
    }
}
