using GermanOutletStore.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace GermanOutletStore.Tests.Mocks
{
    public static class MockDbContext
    {
        public static StoreDbContext GetDbContext()
        {
            DbContextOptions<StoreDbContext> options = new DbContextOptionsBuilder<StoreDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            StoreDbContext context = new StoreDbContext(options);

            return context;
        }
    }
}
