#pragma checksum "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\Products\AllCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d979d8bb9b0264f7dc63378d501065ff5232f189"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_AllCategories), @"mvc.1.0.view", @"/Views/Products/AllCategories.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d979d8bb9b0264f7dc63378d501065ff5232f189", @"/Views/Products/AllCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4880d326ecc15018aa15dbe345ed6f5f2e863b9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_AllCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AllCategoriesViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\Products\AllCategories.cshtml"
  
    ViewData["Title"] = "Browse categories";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <h1>All Categories</h1>\r\n    <br />\r\n    <center>\r\n        <div class=\"row\">\r\n            ");
#nullable restore
#line 11 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Views\Products\AllCategories.cshtml"
       Write(Html.DisplayForModel());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </center>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AllCategoriesViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
