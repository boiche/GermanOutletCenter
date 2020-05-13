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
    public class EditProductTest
    {
        private StoreDbContext context;
        private ProductManager productManager;

        [TestMethod]
        public void EditProduct_WithValidData_ExpectSuccessfullyEditedProduct()
        {
            Product product = new Product()
            {
                Name = "TestProduct",
                IsInStock = true,
                Price = 50,
                ImagePath = "asdasdasdsad",
                Description = "TestDescription",
            };

            List<Brand> brands = new List<Brand>()
            {
                new Brand()
                {
                    Name = "OldBrand",
                },
                new Brand()
                {
                    Name = "TestBrand",
                },
            };

            context.Brands.AddRange(brands);
            context.ProductSizes.AddRange();
            context.Sizes.AddRange(AppBuilderExtensions.availableSizes);
            context.Types.AddRange(AppBuilderExtensions.availableTypes);
            context.Products.Add(product);            
            context.SaveChanges();
            product.BrandId = context.Brands.First().Id;

            ProductCreationBindingModel model = new ProductCreationBindingModel()
            {
                Name = product.Name,
                BrandName = "TestBrand",
                Description = product.Description,
                AllSizes = AppBuilderExtensions.availableSizes,
                ImagePath = product.ImagePath,
                Price = product.Price,
                Types = AppBuilderExtensions.availableTypes,
                ProductId = product.Id,
                BrandId = 1,
                TypeId = 1,                
            };

            if (AppBuilderExtensions.availableTypes[1].Name == "Shoes")
            {
                int a = 0;
                int starttingShoesSizes = context.Sizes.First(x => int.TryParse(x.Name, out a)).Id;
                model.AvailableSizes = new List<bool>() { false, true, true, false, false, true, true, false };
                ProductSize[] productSizes = new ProductSize[]
                {
                    new ProductSize()
                    {
                        IsInStock = true,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes,                        
                    },
                    new ProductSize()
                    {
                        IsInStock = true,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes + 1,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes + 2,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes + 3,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes + 4,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes + 5,
                    },
                    new ProductSize()
                    {
                        IsInStock = true,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes + 6,
                    },
                    new ProductSize()
                    {
                        IsInStock = true,
                        ProductId = product.Id,
                        SizeId = starttingShoesSizes + 7,
                    },
                };
                context.ProductSizes.AddRange(productSizes);
                context.SaveChanges();
            }
            else
            {
                int a = 0;
                int starttingSizes = context.Sizes.First(x => int.TryParse(x.Name, out a) == false).Id;
                model.AvailableSizes = new List<bool>() { false, false, true, true, true, false };

                ProductSize[] productSizes = new ProductSize[]
                {
                    new ProductSize()
                    {
                        IsInStock = true,
                        ProductId = product.Id,
                        SizeId = starttingSizes,
                    },
                    new ProductSize()
                    {
                        IsInStock = true,
                        ProductId = product.Id,
                        SizeId = starttingSizes + 1,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingSizes + 2,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingSizes + 3,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingSizes + 4,
                    },
                    new ProductSize()
                    {
                        IsInStock = false,
                        ProductId = product.Id,
                        SizeId = starttingSizes + 5,
                    },
                };
                context.ProductSizes.AddRange(productSizes);
                context.SaveChanges();
            }

            this.productManager.EditProduct(model, product, AppBuilderExtensions.availableTypes[1].Name);

            Assert.AreEqual(model.AvailableSizes.Where(x => x == true).Count(), product.AvailableSizes.Where(x => x.IsInStock == true).Count());
            Assert.AreEqual(product.AvailableSizes.Count(x => x.IsInStock == true), context.ProductSizes.Count(x => x.ProductId == product.Id && x.IsInStock == true));
        }

        [TestInitialize]
        public void InitialiseTest()
        {
            this.context = MockDbContext.GetDbContext();
            this.productManager = new ProductManager(context);
        }
    }
}
