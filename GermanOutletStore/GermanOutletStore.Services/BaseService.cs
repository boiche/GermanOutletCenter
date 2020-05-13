using GermanOutletStore.Data;

namespace GermanOutletStore.Services
{
    public abstract class BaseService
    {
        protected StoreDbContext context;

        protected BaseService(StoreDbContext context)
        {
            this.context = context;            
        }
    }
}
