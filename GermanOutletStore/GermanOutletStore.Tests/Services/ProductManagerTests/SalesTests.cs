using AutoMapper;
using GermanOutletStore.Common;
using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using GermanOutletStore.Tests.Mocks;
using GermanOutletStore.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace GermanOutletStore.Tests.Services.ProductManagerTests
{
    [TestClass]
    public class SalesTests
    {
        private StoreDbContext context;
        private ProductManager productManager;

        [TestMethod]
        public void PutOnSale_WithValidProduct_ExpectNewSaleEntity()
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

            Sale model = new Sale()
            {
                ProductId = 1,
                DiscountPrice = 25,
                StartsOn = DateTime.Now,
                EndsOn = DateTime.Now.AddDays(18),
            };

            context.Products.Add(testProduct);
            context.Sales.Add(model);
            context.SaveChanges();            

            productManager.PutOnSale(testProduct.Id, model.Id);
            
            Assert.AreEqual(testProduct.SaleId, model.Id);
        }

        [TestInitialize]
        public void TestInitialise()
        {
            this.context = MockDbContext.GetDbContext();
            this.productManager = new ProductManager(context);
        }
    }
}