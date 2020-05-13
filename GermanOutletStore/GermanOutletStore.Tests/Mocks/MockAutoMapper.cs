using AutoMapper;
using GermanOutletStore.Web.Mapping;

namespace GermanOutletStore.Tests.Mocks
{
    public class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile<AutoMapperProfiles>());
        }

        public static IMapper GetMapper()
        {
            return Mapper.Instance;
        }
    }
}
