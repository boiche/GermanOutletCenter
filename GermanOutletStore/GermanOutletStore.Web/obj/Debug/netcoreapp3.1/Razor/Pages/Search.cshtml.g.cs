#pragma checksum "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e621a2207a226c414a4fa7c22f100d0b1485d33e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Search), @"mvc.1.0.razor-page", @"/Pages/Search.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e621a2207a226c414a4fa7c22f100d0b1485d33e", @"/Pages/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8510f6fdda78693689951d6262cb6ae304a530c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Search : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Search.cshtml"
  
    ViewData["Title"] = "Search";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Search results: \"");
#nullable restore
#line 7 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Search.cshtml"
                Write(Model.SearchTerm);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</h2>\r\n<ul class=\"list-unstyled\">\r\n    <div class=\"row\">\r\n        ");
#nullable restore
#line 10 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Pages\Search.cshtml"
   Write(Html.DisplayFor(model => model.SearchResults));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GermanOutletStore.Web.Pages.SearchModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GermanOutletStore.Web.Pages.SearchModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GermanOutletStore.Web.Pages.SearchModel>)PageContext?.ViewData;
        public GermanOutletStore.Web.Pages.SearchModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
