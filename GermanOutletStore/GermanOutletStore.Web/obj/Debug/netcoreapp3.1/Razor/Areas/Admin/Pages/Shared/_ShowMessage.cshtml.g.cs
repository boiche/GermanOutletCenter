#pragma checksum "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\Shared\_ShowMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6e87270e0544230fa71e07e9d34dfe70001d42e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Pages_Shared__ShowMessage), @"mvc.1.0.view", @"/Areas/Admin/Pages/Shared/_ShowMessage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using GermanOutletStore.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using GermanOutletStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using GermanOutletStore.Common.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using GermanOutletStore.Common.BindingModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using GermanOutletStore.Web.Helpers.Messages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\_ViewImports.cshtml"
using GermanOutletStore.Web.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6e87270e0544230fa71e07e9d34dfe70001d42e", @"/Areas/Admin/Pages/Shared/_ShowMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1398e0b4f9e7d91f90182e8f235665fd89ce18f5", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Shared__ShowMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::GermanOutletStore.Web.Helpers.Messages.MessageTagHelper __GermanOutletStore_Web_Helpers_Messages_MessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container body-content\">\r\n");
#nullable restore
#line 2 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\Shared\_ShowMessage.cshtml"
     if (TempData.ContainsKey("__Message"))
    {
        var message = TempData.Get<MessageModel>("__Message");

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("message", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6e87270e0544230fa71e07e9d34dfe70001d42e5222", async() => {
            }
            );
            __GermanOutletStore_Web_Helpers_Messages_MessageTagHelper = CreateTagHelper<global::GermanOutletStore.Web.Helpers.Messages.MessageTagHelper>();
            __tagHelperExecutionContext.Add(__GermanOutletStore_Web_Helpers_Messages_MessageTagHelper);
#nullable restore
#line 5 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\Shared\_ShowMessage.cshtml"
__GermanOutletStore_Web_Helpers_Messages_MessageTagHelper.Type = message.Type;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("type", __GermanOutletStore_Web_Helpers_Messages_MessageTagHelper.Type, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 5 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\Shared\_ShowMessage.cshtml"
                                   WriteLiteral(message.Message);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __GermanOutletStore_Web_Helpers_Messages_MessageTagHelper.Message = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("message", __GermanOutletStore_Web_Helpers_Messages_MessageTagHelper.Message, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\35988\Documents\GitHub\GermanOutletCenter\GermanOutletStore\GermanOutletStore.Web\Areas\Admin\Pages\Shared\_ShowMessage.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
