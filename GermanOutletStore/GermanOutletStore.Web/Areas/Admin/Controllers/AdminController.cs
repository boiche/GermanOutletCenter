using AutoMapper;
using GermanOutletStore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GermanOutletStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public abstract class AdminController : Controller
    {
        protected readonly IMapper mapper;
        protected readonly StoreDbContext context;

        public AdminController(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            RemoveExpiredSales(context);
        }

        private void RemoveExpiredSales(StoreDbContext context)
        {
            var toRemove = context.Sales.Where(x => x.EndsOn <= DateTime.Now).ToList();

            if (toRemove.Count() > 0)
            {
                foreach (var sale in toRemove)
                {
                    context.Products.First(x => x.SaleId == sale.Id).SaleId = null;
                }
                context.Sales.RemoveRange(toRemove);
                context.SaveChanges();
            }
        }
    }
}