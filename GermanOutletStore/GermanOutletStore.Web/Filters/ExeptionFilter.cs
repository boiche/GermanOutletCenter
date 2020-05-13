using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GermanOutletStore.Web.Filters
{
    public class ExeptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new RedirectResult("/Home/Error");
        }
    }
}
