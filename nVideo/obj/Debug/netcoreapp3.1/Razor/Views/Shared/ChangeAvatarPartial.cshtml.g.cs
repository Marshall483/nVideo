#pragma checksum "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/ChangeAvatarPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4583b7ed3e791095aafc7b8009c3a941e9186e2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ChangeAvatarPartial), @"mvc.1.0.view", @"/Views/Shared/ChangeAvatarPartial.cshtml")]
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
#line 1 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/_ViewImports.cshtml"
using nVideo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/_ViewImports.cshtml"
using nVideo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/_ViewImports.cshtml"
using nVideo.DATA.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/_ViewImports.cshtml"
using nVideo.DATA.ControllerModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4583b7ed3e791095aafc7b8009c3a941e9186e2c", @"/Views/Shared/ChangeAvatarPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c72bbff02bf8846323edcc6f38763f3d8d52447", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ChangeAvatarPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChangeAvatarViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeAvatar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Office", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div class=\"row\">\n    \n");
#nullable restore
#line 5 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/ChangeAvatarPartial.cshtml"
  
    if (Model.Error != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"span9\">\n\n            <div class=\"alert alert-info\">\n\n                <button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>\n\n                <h4>");
#nullable restore
#line 14 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/ChangeAvatarPartial.cshtml"
               Write(Model.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n\n            </div>\n        </div>\n");
#nullable restore
#line 18 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/ChangeAvatarPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div class=\"span8 well well-small\">\n        \n        <h2> Change ");
#nullable restore
#line 23 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/ChangeAvatarPartial.cshtml"
               Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" avatar</h2>\n        \n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4583b7ed3e791095aafc7b8009c3a941e9186e2c6260", async() => {
                WriteLiteral("\n            \n            <p>\n                <strong>Avatar</strong>\n                <input name=\"Avatar\" type=\"file\" class=\"form-control\"/>\n            </p>\n\n            <p>\n                <input type=\"submit\" value=\"Apply\"/>\n            </p>\n\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        \n    </div>\n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChangeAvatarViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
