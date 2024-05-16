using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Persistence.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(50);
            //builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            #region Base Entity Configuration
            //builder.Property(x => x.CreatedOn).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            #endregion
            #region Seed Data
            //builder.HasData(new Category() { Id = 1, Name = "Mutfak" }, new Category() { Id = 2, Name = "Mobilya" }, new Category() { Id = 3, Name = "Market" }, new Category() { Id = 4, Name = "Aydınlatma" });
            #endregion
        }
    }
}
