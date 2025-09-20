using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_Layer.Models.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class DliveryMethodConfigurations : IEntityTypeConfiguration<DlievryMethod>
    {
        public void Configure(EntityTypeBuilder<DlievryMethod> builder)
        {
            builder.ToTable(name: "DeliveryMethods");
            builder.Property(propertyExpression: D => D.Price)
                .HasColumnType(typeName: "decimal(8,2)");
            builder.Property(propertyExpression: D => D.ShortName)
                .HasColumnType(typeName: "varchar")
                .HasMaxLength(maxLength: 50);

            builder.Property(propertyExpression: D => D.Description)
                .HasColumnType(typeName: "varchar")
                .HasMaxLength(maxLength: 100);

            builder.Property(propertyExpression: D => D.DeliveryTime)
                .HasColumnType(typeName: "varchar")
                .HasMaxLength(maxLength: 50);
        }
    }
 }

