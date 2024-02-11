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
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired(true);
            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.CustomerTypeId).IsRequired(true);
            builder.Property(x => x.JoiningDate).IsRequired(true);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.HasOne(c => c.CustomerType).WithMany(p => p.Customers).HasForeignKey(p => p.CustomerTypeId);
          
            #region Base Entity Configuration
            builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion

            #region Seed Data
            builder.HasData(new Customer() { Id = 1, FirstName = "EVREN", LastName = "AKTAŞ", CustomerTypeId = 1, JoiningDate = DateTime.Now }
            , new Customer() { Id = 2, FirstName = "ECE", LastName = "DAĞDELEN", CustomerTypeId = 2, JoiningDate = DateTime.Now }
            , new Customer() { Id = 3, FirstName = "İBRAHİM", LastName = "AKIŞIK", CustomerTypeId = 1, JoiningDate = DateTime.Now }
            , new Customer() { Id = 4, FirstName = "GİZEM", LastName = "KURTCUOĞLU", CustomerTypeId = 2, JoiningDate = DateTime.Now });
            #endregion
        }
    }
}
