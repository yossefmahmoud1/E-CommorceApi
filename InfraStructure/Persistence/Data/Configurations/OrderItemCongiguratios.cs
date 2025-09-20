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
    public class OrderItemCongiguratios : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable( "OrderItems");


            builder.Property(propertyExpression: OI => OI.Price)
                .HasColumnType(typeName: "decimal(8,2)");
            builder.OwnsOne(navigationExpression: OI => OI.Product);
        }
    }
}
