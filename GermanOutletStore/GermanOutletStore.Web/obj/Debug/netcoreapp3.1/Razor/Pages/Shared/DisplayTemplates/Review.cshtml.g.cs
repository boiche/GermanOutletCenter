#pragma checksum "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Shared\DisplayTemplates\Review.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb64cba06ea852c93cc0553ab58ec11873e3277d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared_DisplayTemplates_Review), @"mvc.1.0.view", @"/Pages/Shared/DisplayTemplates/Review.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\_ViewImports.cshtml"
using GermanOutletStore.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\_ViewImports.cshtml"
using GermanOutletStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\_ViewImports.cshtml"
using GermanOutletStore.Common.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Shared\DisplayTemplates\Review.cshtml"
using GermanOutletStore.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb64cba06ea852c93cc0553ab58ec11873e3277d", @"/Pages/Shared/DisplayTemplates/Review.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8510f6fdda78693689951d6262cb6ae304a530c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_DisplayTemplates_Review : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Review>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("   \r\n<div class=\"row\">\r\n    <div class=\"col-lg-6\">");
#nullable restore
#line 6 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Shared\DisplayTemplates\Review.cshtml"
                     Write(Model.PublishedOnDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"col-lg-6\">Review by ");
#nullable restore
#line 7 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Shared\DisplayTemplates\Review.cshtml"
                               Write(context.Users.First(x=>x.Id == Model.CustomerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n</div>\r\n<span>");
#nullable restore
#line 9 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Shared\DisplayTemplates\Review.cshtml"
 Write(Model.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n<hr />        ");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public StoreDbContext context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Review> Html { get; private set; }
    }
}
#pragma warning restore 1591
