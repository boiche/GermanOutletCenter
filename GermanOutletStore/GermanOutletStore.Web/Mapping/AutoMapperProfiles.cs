using AutoMapper;
using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Common.ViewModels;
using GermanOutletStore.Models;

namespace GermanOutletStore.Web.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            this.CreateMap<ProductType, AllCategoriesViewModel>();
            this.CreateMap<Product, ProductViewModel>();
            this.CreateMap<Product, ProductCreationBindingModel>().ForMember(x => x.ProductId, a => a.MapFrom(s => s.Id));
            this.CreateMap<ProductCreationBindingModel, Product>();
            this.CreateMap<Brand, BrandCreationBindingModel>().ForMember(x => x.OldName, a => a.MapFrom(s => s.Name));
            this.CreateMap<BrandCreationBindingModel, Brand>().ForMember(x => x.Name, a => a.MapFrom(s => s.NewName));
            this.CreateMap<Brand, AllBrandsViewModel>();
            this.CreateMap<Product, AllProductsViewModel>();
            this.CreateMap<ProductType, CategoryViewModel>();
            this.CreateMap<Product, SaleCreationBindingModel>()
                .ForMember(x => x.OldPrice, a => a.MapFrom(s => s.Price))
                .ForMember(x => x.ProductName, a => a.MapFrom(s => s.Name))
                .ForMember(x => x.ProductId, a => a.MapFrom(s => s.Id));
            this.CreateMap<ProductShoppingCartViewModel, ProductCheckoutViewModel>();
            this.CreateMap<CheckoutBindingModel, Order>();
        }
    }
}
