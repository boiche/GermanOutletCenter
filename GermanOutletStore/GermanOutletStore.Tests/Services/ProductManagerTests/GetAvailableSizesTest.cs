using GermanOutletStore.Common;
using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using GermanOutletStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GermanOutletStore.Tests.Services.ProductManagerTests
{
    [TestClass]
    public class GetAvailableSizesTest
    {
        private StoreDbContext context;
        private ProductManager productManager;

        [TestMethod]
        public void GetAvailableSizes_WithValidInput_ExpectAllAvailableSizes()
        {
            Product product = new Product() { Name = "TestName" };
            context.Sizes.AddRange(AppBuilderExtensions.availableSizes);
            context.Types.AddRange(AppBuilderExtensions.availableTypes);
            context.Products.Add(product);
            context.SaveChanges();

            ProductCreationBindingModel model = new ProductCreationBindingModel()
            {
                Name = "TestName",                               
                BrandName = "TestBrand",
                Description = "TestDescription",
                AllSizes = AppBuilderExtensions.availableSizes,
                ImagePath = "asdasdasdsad",
                Price = 50,
                Types = AppBuilderExtensions.availableTypes,
                ProductId = product.Id,
                BrandId = 1,
                TypeId = 1,                
            };

            if (AppBuilderExtensions.availableTypes[1].Name == "Shoes")
            {
                model.AvailableSizes = new List<bool>() { false, true, true, false, false, true, true, false };
            }
            else
            {
                model.AvailableSizes = new List<bool>() { false, false, true, true, true, false };
            }

            var result = productManager.GetAvailableSizes(model, product, AppBuilderExtensions.availableTypes[0].Name);

            Assert.IsInstanceOfType(result, typeof(List<ProductSize>));
            CollectionAssert.AllItemsAreUnique(result);
            Assert.AreEqual(model.AvailableSizes.Count(), result.Count());
            Assert.AreEqual(model.AvailableSizes.Where(x => x == true).Count(), result.Where(x => x.IsInStock == true).Count());
        }

        [TestInitialize]
        public void InitialiseTest()
        {
            this.context = MockDbContext.GetDbContext();
            this.productManager = new ProductManager(context);
        }
    }
}
