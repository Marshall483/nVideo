#pragma checksum "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3afb12d44191eb0bfdd400c3be5653c3f941045f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminPanel_EditEntity), @"mvc.1.0.view", @"/Views/AdminPanel/EditEntity.cshtml")]
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
#line 1 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ControllerModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3afb12d44191eb0bfdd400c3be5653c3f941045f", @"/Views/AdminPanel/EditEntity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminPanel_EditEntity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
  
  Layout = "AdminPanelLayout";

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
  
        foreach (Catalog_Entity ent in ViewBag.Entities)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("          <div class=\"p-4\">\r\n            <div class=\"welcome\">\r\n              <div class=\"content rounded-3 p-3\">\r\n      \r\n                <h3 color=\"black\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3afb12d44191eb0bfdd400c3be5653c3f941045f4493", async() => {
#nullable restore
#line 11 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
                                                                                Write(ent.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 295, "~/Catalog/About/", 295, 16, true);
#nullable restore
#line 11 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
AddHtmlAttributeValue("", 311, ent.Id, 311, 7, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n                <p>");
#nullable restore
#line 12 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
              Write(ent.Short_Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Is Awailable: ");
#nullable restore
#line 13 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
                            Write(ent.Awailable);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <h5><a class=\"nav-link\"");
            BeginWriteAttribute("href", " href=\"", 472, "\"", 513, 2);
            WriteAttributeValue("", 479, "/AdminPanel/EditProduct?Id=", 479, 27, true);
#nullable restore
#line 14 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
WriteAttributeValue("", 506, ent.Id, 506, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>     <a color=\"black\" class=\"nav-link\"");
            BeginWriteAttribute("href", " href=\"", 561, "\"", 605, 2);
            WriteAttributeValue("", 568, "/AdminPanel/DeleteEntities?Id=", 568, 30, true);
#nullable restore
#line 14 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
WriteAttributeValue("", 598, ent.Id, 598, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></h5>\r\n                <br/>\r\n                <br/>\r\n        \r\n      \r\n              </div>\r\n            </div>\r\n          </div>\r\n");
#nullable restore
#line 22 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\AdminPanel\EditEntity.cshtml"
        } 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
