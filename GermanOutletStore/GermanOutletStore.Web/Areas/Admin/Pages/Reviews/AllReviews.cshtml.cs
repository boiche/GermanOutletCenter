using GermanOutletStore.Data;
using GermanOutletStore.Models;
using GermanOutletStore.Services.Products;
using GermanOutletStore.Web.Extensions;
using GermanOutletStore.Web.Helpers.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GermanOutletStore.Web.Areas.Admin.Pages.Reviews
{
    public class AllReviewsModel : PageModel
    {
        private readonly StoreDbContext context;
        private readonly ProductManager productManager;

        public AllReviewsModel(StoreDbContext context, ProductManager productManager)
        {
            this.productManager = productManager;
            this.context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        public List<Review> AllReviews { get; set; }


        public void OnGet(int id)
        {
            Product = productManager.GetProduct(id);
            AllReviews = context.Reviews.Where(x => x.ProductId == id).ToList();
        }

        public IActionResult OnPost(int id, int reviewId)
        {
            Review toRemove = context.Reviews.First(x => x.Id == reviewId);

            context.Remove(toRemove);            
            context.SaveChanges();

            productManager.UpdateRatingAfterRemovingReview(id, toRemove);

            this.TempData.Put("__Message", new MessageModel()
            {
                Type = MessageType.Success,
                Message = "Review successfuly deleted.",
            });

            return this.RedirectToPage(id);
        }
    }
}