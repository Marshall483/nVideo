#pragma checksum "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Catalog/List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7af520d13f4c4d48bdf9d9374ac0fa5131bc3d5d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalog_List), @"mvc.1.0.view", @"/Views/Catalog/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7af520d13f4c4d48bdf9d9374ac0fa5131bc3d5d", @"/Views/Catalog/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c72bbff02bf8846323edcc6f38763f3d8d52447", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalog_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CatalogViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/JS/sortList.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n\n<div class=\"span9\">\n    <div class=\"well well-small\">\n        <h5>Фильтры</h5>\n        <hr class=\"soften\">\n");
#nullable restore
#line 8 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Catalog/List.cshtml"
         if (Model.Entities.Count() != 0)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Catalog/List.cshtml"
       Write(await Component.InvokeAsync("Attribute", Model.Entities.First()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Catalog/List.cshtml"
                                                                             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <button id=""sort-asc"" class=""btn"">Price by asceding</button>
        <button id=""sort-desc"" class=""btn"">Price by desceding</button>
        <button id=""sort-raiting"" class=""btn"">По рейтингу</button>
    </div>
  <div class=""well well-small"">
    <div class=""goods-wrap"">
");
#nullable restore
#line 18 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Catalog/List.cshtml"
        
        foreach (Catalog_Entity e in Model.Entities)
        {
          

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Catalog/List.cshtml"
     Write(await Html.PartialAsync("ListCatalogPartial", e));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Catalog/List.cshtml"
                                                           
        }
      

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n  </div>\n</div>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7af520d13f4c4d48bdf9d9374ac0fa5131bc3d5d5767", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CatalogViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
