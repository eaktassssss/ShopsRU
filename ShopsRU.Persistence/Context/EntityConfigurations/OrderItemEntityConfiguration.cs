using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Context.EntityConfigurations
{
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x=> x.IsDiscountApplied).IsRequired();
            builder.Property(x => x.UnitPrice).HasPrecision(18, 0);
            builder.Property(x=> x.LineDiscountAmount).IsRequired();
            builder.Property(x => x.LineDiscountAmount).HasPrecision(18, 0);
            builder.HasOne(c => c.Order).WithMany(p => p.OrderItems).HasForeignKey(p => p.OrderId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion
        }
    }
}
