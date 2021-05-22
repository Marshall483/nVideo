#pragma checksum "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fddc4e09eef5063193a1d3c805f530d8fe76b09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ControllerModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fddc4e09eef5063193a1d3c805f530d8fe76b09", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopCartView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("shopBtn btn-large pull-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""span9"">
  <div class=""well well-small"">
    <h1>Checkout </h1>
    <hr class=""soften"" />
    <div class=""goods-wrap"">
      <table class=""table table-bordered table-condensed"">
        <thead>
          <tr>
            <th>Product</th>
            <th>Description</th>
            <th>Price</th>
            <th>Count </th>
            <th>Items</th>
          </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
            
            if (Model.ShopCartItems != null)
            {
              foreach (var shopCartItem in Model.ShopCartItems)
              {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                  ");
#nullable restore
#line 25 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
             Write(Html.Partial("ListShopCartPartial", shopCartItem.Entity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                  <td>\r\n                    <h3><small> ");
#nullable restore
#line 27 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
                           Write(shopCartItem.Quanity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </small></h3>\r\n                  </td>\r\n                </tr>\r\n");
#nullable restore
#line 30 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
              }
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("              ");
            WriteLiteral(" Cart is empty\r\n");
#nullable restore
#line 35 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
            }
          

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n      </table>\r\n      <hr class=\"soften\" />\r\n      <h3>Total products:$ ");
#nullable restore
#line 40 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
                       Write(Model.TotalValue / 74);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 41 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
        
        if (Model.ShopCartItems != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fddc4e09eef5063193a1d3c805f530d8fe76b096525", async() => {
                WriteLiteral("Next <span class=\"icon-arrow-right\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Index.cshtml"
        }
      

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n  </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopCartView> Html { get; private set; }
    }
}
#pragma warning restore 1591
