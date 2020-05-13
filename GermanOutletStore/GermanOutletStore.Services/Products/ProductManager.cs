using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GermanOutletStore.Services.Products
{
    public class ProductManager : BaseService, IProductManager
    {
        public ProductManager(StoreDbContext context) : base(context) { }

        public void Delete(int id)
        {
            context.Products.Remove(this.GetProduct(id));
            context.SaveChanges();
        }

        public List<ProductSize> GetAvailableSizes(ProductCreationBindingModel model, Product productToAdd, string typeName)
        {
            int startingClothesSizeId = context.Sizes.First(x => int.TryParse(x.Name, out startingClothesSizeId) == false).Id;
            int startingShoesSizeId = context.Sizes.First(x => int.TryParse(x.Name, out startingShoesSizeId)).Id;
            int productId = productToAdd.Id;

            int currentSizeId = 0;
            if (typeName == "Shoes") currentSizeId = startingShoesSizeId;
            else currentSizeId = startingClothesSizeId;

            List<ProductSize> result = new List<ProductSize>();

            for (int i = 0; i < model.AvailableSizes.Count; i++)
            {
                if (model.AvailableSizes[i] == false)
                {
                    ProductSize productSizeOutOfStock = new ProductSize() { ProductId = productId, SizeId = currentSizeId, IsInStock = false };
                    result.Add(productSizeOutOfStock);
                    currentSizeId++;
                    continue;
                }

                ProductSize productSize = new ProductSize() { ProductId = productId, SizeId = currentSizeId, IsInStock = true };
                result.Add(productSize);
                currentSizeId++;
            }

            return result;
        }

        public void EditProduct(ProductCreationBindingModel model, Product productToEdit, string typeName)
        {
            List<ProductSize> oldSizes = context.ProductSizes.Where(x => x.ProductId == productToEdit.Id).ToList();
            List<ProductSize> newSizes = this.GetAvailableSizes(model, productToEdit, typeName);
            Product save = productToEdit;

            if (newSizes.All(x => x.IsInStock == false))
            {
                save.IsInStock = false;
                oldSizes.ForEach(x => x.IsInStock = false);
            }
            else
            {
                for (int i = 0; i < newSizes.Count; i++)
                {
                    if (oldSizes[i].IsInStock != newSizes[i].IsInStock)
                    {
                        oldSizes[i].IsInStock = newSizes[i].IsInStock;
                    }
                }
                save.IsInStock = true;
            }

            save.Name = model.Name;
            save.Price = model.Price;
            save.Description = model.Description;
            save.BrandId = context.Brands.First(x => x.Name == model.BrandName).Id;
            if (model.UploadedFile != null)
            {
                save.ImagePath = model.ImagePath;
            }

            context.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void PutOnSale(int id, int saleId)
        {
            this.GetProduct(id).SaleId = saleId;
            context.SaveChanges();
        }

        public void RemoveSale(int id)
        {
            this.GetProduct(id).SaleId = null;
            context.Sales.Remove(context.Sales.First(x => x.ProductId == id));
            context.SaveChanges();
        }

        public async Task UpdateRating(int id, double newRating)
        {
            if (newRating > 5 || newRating < 1)
            {
                // That's invalid rating
            }
            else
            {
                Product product = this.GetProduct(id);
                if (context.Reviews.Where(x => x.ProductId == id).Count() > 0)
                {
                    int reviewsCount = context.Reviews.Count(x => x.ProductId == id);
                    double reviewsRatingSum = context.Reviews.Where(x => x.ProductId == id).Sum(x => x.Rating);

                    product.Rating = Math.Round(reviewsRatingSum / reviewsCount, 2);
                }
                else product.Rating = newRating;
            }

            await context.SaveChangesAsync();
        }

        public async Task UpdateRatingAfterRemovingReview(int id, Review review)
        {
            Product productToEdit = this.GetProduct(id);
            int reviewsCount = context.Reviews.Count(x => x.ProductId == id);            

            if (reviewsCount > 0)
            {
                double reviewsRatingSum = context.Reviews.Where(x => x.ProductId == id).Sum(x => x.Rating);
                productToEdit.Rating = Math.Round(reviewsRatingSum / reviewsCount, 2);
            }
            else productToEdit.Rating = 0;

            await context.SaveChangesAsync();
        }
    }
}
