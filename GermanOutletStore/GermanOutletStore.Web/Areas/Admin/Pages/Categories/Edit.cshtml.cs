using AutoMapper;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using GermanOutletStore.Web.Extensions;
using GermanOutletStore.Web.Helpers.Messages;

namespace GermanOutletStore.Web.Areas.Admin.Pages.Categories
{
    public class EditModel : PageModel
    {
        public StoreDbContext context;
        public IMapper mapper;

        [BindProperty]
        public ProductType ProductType { get; set; }

        public EditModel(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void OnGet(int id)
        {
            ProductType = context.Types.First(x => x.Id == id);
        }

        public void OnPost(string newName, int id)
        {
            ProductType type = context.Types.First(x => x.Id == id);
            string oldName = type.Name;
            type.Name = newName;
            
            context.SaveChanges();

            this.TempData.Put<MessageModel>("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{oldName} successfully renamed to {newName}",
            });

            this.RedirectToPage("AllCategories");
        }

        public void OnPostDelete(int id)
        {
            ProductType type = context.Types.First(x => x.Id == id);
            context.Types.Remove(type);
            context.SaveChanges();

            this.TempData.Put<MessageModel>("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = $"{type.Name} successfully deleted.",
            });

            this.RedirectToPage("/Admin/Categories/AllCategories");
        }
    }
}