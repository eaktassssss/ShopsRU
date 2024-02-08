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
    public class InvoiceEntityConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.TotalAmount).HasPrecision(18, 2);
            builder.Property(x => x.TotalAmount).IsRequired();
            builder.Property(x => x.InvoiceDate).IsRequired();
            builder.Property(x => x.BillingUserId).IsRequired();
            builder.Property(x => x.NetAmount).IsRequired();
            builder.Property(x => x.NetAmount).HasPrecision(18, 2);
            builder.Property(x => x.DiscountAmount).IsRequired();
            builder.Property(x => x.DiscountAmount).HasPrecision(18, 2);
            builder.Property(x => x.OrderId).IsRequired();
            builder.HasOne(c => c.Order).WithMany(p => p.Invoices).HasForeignKey(p => p.OrderId);
            builder.HasOne(c => c.Customer).WithMany(p => p.Invoices).HasForeignKey(p => p.CustomerId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            #endregion
        }
    }
}
