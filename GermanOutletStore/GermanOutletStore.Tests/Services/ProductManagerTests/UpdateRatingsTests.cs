using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using GermanOutletStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GermanOutletStore.Tests.Services.ProductManagerTests
{
    [TestClass]
    public class UpdateRatingsTests
    {
        private StoreDbContext context;
        private ProductManager productManager;

        [TestMethod]
        public void UpdateRating_WithValidData_ExpectUpdatedAverageRating()
        {
            Product testProduct = new Product()
            {
                Name = "TestName",
                SaleId = null,
                TypeId = 0,
                Rating = 0,
                Price = 50,
                IsInStock = true,
            };

            context.Products.Add(testProduct);
            context.SaveChanges();

            productManager.UpdateRating(testProduct.Id, 3.5);

            Assert.AreNotEqual(0, testProduct.Rating);
        }

        [TestMethod]
        public void UpdateRating_WithInvalidData_ExpectSameRating()
        {
            Product testProduct = new Product()
            {
                Name = "TestName",
                SaleId = null,
                TypeId = 0,
                Rating = 0,
                Price = 50,
                IsInStock = true,
            };

            context.Products.Add(testProduct);
            context.SaveChanges();

            productManager.UpdateRating(testProduct.Id, 5.5);

            Assert.AreEqual(0, testProduct.Rating);
        }

        [TestInitialize]
        public void TestInitialise()
        {
            this.context = MockDbContext.GetDbContext();
            this.productManager = new ProductManager(context);
        }
    }
}
