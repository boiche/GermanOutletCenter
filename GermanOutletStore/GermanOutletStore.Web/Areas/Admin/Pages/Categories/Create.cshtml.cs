using AutoMapper;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Web.Extensions;
using GermanOutletStore.Web.Helpers.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace GermanOutletStore.Web.Areas.Admin.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public StoreDbContext context;
        public IMapper mapper;
        public ProductType ProductType { get; set; }
        public IFormFile ToUploadFile { get; set; }

        public CreateModel(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            ProductType = new ProductType();            
        }

        public void OnGet()
        {

        }

        public async Task OnPost(string newCategoryName, IFormFile uploadedFile)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"SiteImages/categories/{newCategoryName}.jpg");
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
            await uploadedFile.CopyToAsync(stream);


            ProductType.Name = newCategoryName;
            context.Types.Add(ProductType);
            context.SaveChanges();

            this.TempData.Put<MessageModel>("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{ProductType.Name} successfully created.",
            });

            this.RedirectToPage("/Admin/Categories/AllCategories");
        }
    }
}