using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GermanOutletStore.Services.Products.Interfaces
{
    public interface IProductManager
    {
        Product GetProduct(int id);
        void EditProduct(ProductCreationBindingModel model, Product productToEdit, string typeName);
        List<ProductSize> GetAvailableSizes(ProductCreationBindingModel model, Product productToAdd, string typeName);
        void RemoveSale(int id);
        void PutOnSale(int id, int saleId);
        void Delete(int id);
        Task UpdateRating(int id, double newRating);
    }
}
