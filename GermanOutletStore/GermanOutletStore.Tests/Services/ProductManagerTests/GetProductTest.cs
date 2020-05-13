using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using GermanOutletStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GermanOutletStore.Tests.Services.ProductManagerTests
{
    [TestClass]
    public class GetProductTest
    {
        private StoreDbContext context;
        private ProductManager productManager;

        [TestMethod]
        public void GetProduct_WithValidId_ExpectReturnedProduct()
        {
            context.Products.Add(new Product() { Id = 1 });
            context.SaveChanges();
            object product = productManager.GetProduct(context.Products.First().Id);

            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void GetProduct_WithInvalidId_ExpectNull()
        {
            object product = productManager.GetProduct(2);

            Assert.IsNull(product);            
        }

        [TestInitialize]
        public void InitialiseTest()
        {
            this.context = MockDbContext.GetDbContext();
            this.productManager = new ProductManager(context);
        }
    }    
}
