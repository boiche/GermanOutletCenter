using GermanOutletStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GermanOutletStore.Data.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Products).WithOne(x => x.Size);
            builder.HasMany(x => x.ProductOrders).WithOne(x => x.Size);
        }
    }
}
