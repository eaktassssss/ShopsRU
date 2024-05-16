using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ShopsRU.Persistence.Context.EntityConfigurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Price).HasPrecision(18, 0);
            builder.Property(x => x.Price).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(80);
            builder.Property(x => x.CategoryId).IsRequired(true);
            builder.Property(x => x.StockQuantity).IsRequired(true);
            //builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);
            #region Base Entity Configuration
            //builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion

            #region Seed Data
            //builder.HasData(new Product() { Id = 1, Name = "Gardırop", Price = 3000, CategoryId = 1,StockQuantity=10 },
            //  new Product() { Id = 2, Name = "Fırın", Price = 4000, CategoryId = 2, StockQuantity = 10 }
            //, new Product() { Id = 3, Name = "Fıstık Ezmesi", Price = 85, CategoryId = 3, StockQuantity = 10 }, new Product() { Id = 4, Name = "ModeLight Işıl 3'lü Avize", Price = 4000, CategoryId = 4, StockQuantity = 10 });
            #endregion
        }
    }
}
