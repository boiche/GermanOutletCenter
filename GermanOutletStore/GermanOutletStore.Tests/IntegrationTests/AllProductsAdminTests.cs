using GermanOutletStore.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace GermanOutletStore.Tests.IntegrationTests
{
    [TestClass]
    public class AllProductsAdminTests
    {
        [TestMethod]
        public async Task GetAllProducts_ExpectStatusOK()
        {
            var factory = new WebApplicationFactory<Startup>();
            HttpClient client = factory.CreateClient();

            HttpResponseMessage result = await client.GetAsync("/Admin/Products/AllProducts");            

            StringAssert.Contains(result.ToString(), "OK");
        }
    }
}
