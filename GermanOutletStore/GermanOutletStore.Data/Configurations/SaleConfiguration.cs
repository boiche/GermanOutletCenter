using GermanOutletStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GermanOutletStore.Data.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithOne(x => x.Sale).HasForeignKey<Product>(x => x.SaleId);
            builder.Property(x => x.DiscountPrice).HasColumnType("real");
        }
    }
}
