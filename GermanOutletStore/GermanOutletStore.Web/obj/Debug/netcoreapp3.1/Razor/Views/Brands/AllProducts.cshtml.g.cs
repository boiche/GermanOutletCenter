#pragma checksum "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\Brands\AllProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7fe925487785b30641d1f2e9f6e8236fb5c62d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Brands_AllProducts), @"mvc.1.0.view", @"/Views/Brands/AllProducts.cshtml")]
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
#line 1 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\_ViewImports.cshtml"
using GermanOutletStore.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\_ViewImports.cshtml"
using GermanOutletStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\_ViewImports.cshtml"
using GermanOutletStore.Common.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\_ViewImports.cshtml"
using GermanOutletStore.Common.BindingModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\_ViewImports.cshtml"
using GermanOutletStore.Web.Helpers.Messages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\_ViewImports.cshtml"
using GermanOutletStore.Web.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7fe925487785b30641d1f2e9f6e8236fb5c62d1", @"/Views/Brands/AllProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4880d326ecc15018aa15dbe345ed6f5f2e863b9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Brands_AllProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\Brands\AllProducts.cshtml"
  
    ViewData["Title"] = "All Products";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>All Products by ");
#nullable restore
#line 6 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\Brands\AllProducts.cshtml"
               Write(Model.First().BrandName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<ul class=\"list-unstyled\">\r\n    <div class=\"row\">\r\n        ");
#nullable restore
#line 9 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\Brands\AllProducts.cshtml"
   Write(Html.DisplayForModel());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</ul>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
