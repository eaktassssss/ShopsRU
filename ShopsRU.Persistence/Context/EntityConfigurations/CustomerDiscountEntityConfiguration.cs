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
    public  class CustomerDiscountEntityConfiguration : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.DiscountId).IsRequired();
            builder.Property(x => x.CustomerTypeId).IsRequired();
            builder.HasOne(c => c.CustomerType).WithMany(p => p.CustomerDiscounts).HasForeignKey(p => p.CustomerTypeId);
            builder.HasOne(c => c.Discounts).WithMany(p => p.CustomerDiscounts).HasForeignKey(p => p.DiscountId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion
           
        }
    }
}
