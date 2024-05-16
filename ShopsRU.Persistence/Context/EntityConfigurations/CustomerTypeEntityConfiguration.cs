using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.Context.EntityConfigurations
{
    public class CustomerTypeEntityConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).IsRequired(true);
            //builder.HasMany(c => c.Customers).WithOne(p => p.CustomerType).HasForeignKey(p => p.CustomerTypeId);
            builder.HasMany(c => c.CustomerDiscounts).WithOne(p => p.CustomerType).HasForeignKey(p => p.CustomerTypeId);
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion

            #region Seed Data
            builder.HasData(new CustomerType() {Id=1 ,Type="Mağaza Çalışanı"}, new CustomerType() { Id =2 , Type = "Mağaza Üyesi", });
            #endregion
        }
    }
}
