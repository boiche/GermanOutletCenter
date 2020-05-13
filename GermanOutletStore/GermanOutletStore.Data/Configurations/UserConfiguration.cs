using GermanOutletStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GermanOutletStore.Data.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Reviews).WithOne(x => x.Customer);
            builder.HasMany(x => x.Orders).WithOne(x => x.Customer);
        }
    }
}
