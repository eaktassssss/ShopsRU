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
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(50);
            builder.HasMany(c => c.CustomerDiscounts).WithOne(p => p.Discounts).HasForeignKey(p => p.CustomerTypeId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion
            #region Seed Data
            builder.HasData(new Discount() { Id = 1, DiscountType = "%", DiscountRate = 30, Description = "Mağaza çalışanı için belirlenmiş indirim oranı" },
                new Discount() { Id = 2, DiscountType = "%", DiscountRate = 10, Description = "Mağaza üyesi iiçin belirlenmiş indirim oranı" }, new Discount() { DiscountType = "%", DiscountRate = 5, Id = 3, Description = "Sadık müşteri  için belirlenmiş indirim oranı" }
                );
            #endregion
        }
    }
}
