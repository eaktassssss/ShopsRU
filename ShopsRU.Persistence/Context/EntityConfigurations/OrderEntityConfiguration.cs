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
            builder.Property(x => x.TotalAmount).HasPrecision(18, 2);
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.HasMany(c => c.OrderItems).WithOne(p => p.Order).HasForeignKey(p => p.OrderId);
            builder.HasMany(c => c.Invoices).WithOne(p => p.Order).HasForeignKey(p => p.OrderId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            #endregion
        }
    }
}
