using GermanOutletStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GermanOutletStore.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ReviewedProduct).WithMany(x => x.Reviews);
            builder.HasOne(x => x.Customer).WithMany(x => x.Reviews);
        }
    }
}
