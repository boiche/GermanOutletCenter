using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using GermanOutletStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GermanOutletStore.Tests.Services.ProductManagerTests
{
    [TestClass]
    public class DeleteTest
    {
        private StoreDbContext context;
        private ProductManager productManager;

        [TestMethod]
        public void Delete_ExistProduct_ExpectSuccessfullDelete()
        {
            context.Products.Add(new Product() { Id = 1 });
            context.SaveChanges();

            productManager.Delete(1);

            Assert.IsFalse(context.Products.Any());            
        }

        [TestMethod]
        public void Delete_UnexistProduct_ExpectException()
        {            
            Assert.ThrowsException<ArgumentNullException>(() => productManager.Delete(1));
        }

        [TestInitialize]
        public void InitialiseTest()
        {
            this.context = MockDbContext.GetDbContext();
            this.productManager = new ProductManager(context);
        }
    }
}
