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
    public class DiscountEntityConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DiscountType).IsRequired();
            builder.Property(x => x.DiscountRate).IsRequired();
            builder.HasMany(c => c.CustomerDiscounts).WithOne(p => p.Discounts).HasForeignKey(p => p.CustomerTypeId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion
            #region Seed Data
            builder.HasData(new Discount() { Id = 1, DiscountType = "Yüzde", DiscountRate = 30},
                new Discount() { Id = 2, DiscountType = "Yüzde", DiscountRate = 10}, new Discount() { DiscountType = "Yüzde", DiscountRate = 5, Id = 3}
                );
            #endregion
        }
    }
}
