using GermanOutletStore.Common.BindingModels;
using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace GermanOutletStore.Web.Pages.Reviews
{
    [Authorize]
    public class AddReviewModel : PageModel
    {
        private readonly StoreDbContext context;
        private readonly ProductManager productManager;
        private readonly UserManager<User> userManager;

        [BindProperty]
        public Product Product { get; set; }
        public ReviewCreatingBindingModel CreateModel { get; set; }

        public AddReviewModel(StoreDbContext context, ProductManager product, UserManager<User> userManager)
        {
            this.context = context;
            this.productManager = product;
            this.userManager = userManager;
        }
        
        public void OnGet(int id)
        {
            this.Product = productManager.GetProduct(id);
        }

        public async Task<IActionResult> OnPost(ReviewCreatingBindingModel model, int id)
        {            
            Review newReview = new Review()
            {
                Content = model.Content,
                CustomerId = userManager.GetUserId(User),
                ProductId = id,
                PublishedOnDate = DateTime.Now,
                Rating = model.Rating,                
            };

            context.Reviews.Add(newReview);            
            context.SaveChanges();
            await productManager.UpdateRating(id, model.Rating);

            return this.RedirectToPage("/Products/Details", id);
        }
    }
}