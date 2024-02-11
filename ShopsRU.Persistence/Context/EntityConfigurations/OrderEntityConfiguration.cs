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
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.TotalOrderAmount).HasPrecision(18, 0);
            builder.Property(x => x.TotalOrderAmount).IsRequired();
            builder.Property(x => x.TotalDiscountAmount).HasPrecision(18, 0);
            builder.Property(x => x.TotalDiscountAmount).IsRequired();
            builder.Property(x => x.NetAmount).HasPrecision(18, 0);
            builder.Property(x => x.NetAmount).IsRequired();
            builder.Property(x => x.TotalFixedDiscountAmount).HasPrecision(18, 0);
            builder.Property(x => x.TotalFixedDiscountAmount).IsRequired();
            builder.Property(x => x.IsFixedDiscountApplied).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.HasMany(c => c.OrderItems).WithOne(p => p.Order).HasForeignKey(p => p.OrderId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.IsFixedDiscountApplied).HasDefaultValue(false);

            #endregion
        }
    }
}
