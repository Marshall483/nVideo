#pragma checksum "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e93dafe1bef482e4ef103918c06b5531c21bde4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Checkout), @"mvc.1.0.view", @"/Views/Cart/Checkout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e93dafe1bef482e4ef103918c06b5531c21bde4", @"/Views/Cart/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopCartView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
  <div class=""span8 well well-small"">
    <table class=""table table-bordered"">
      <tbody>
        <tr><td>Confirmation of an order:</td></tr>
        <tr>
          <td>
            <div class=""control-group"">
              <label class=""span2 control-label"">Pick-up from: Moscow sity, Leningradskaya 29  </label>
            </div>
          </td>
        </tr>
        <tr>
          <td>
            <div class=""control-group"">
              <label class=""span2 control-label"">To pay: ");
#nullable restore
#line 17 "C:\Users\User\Desktop\nVideo\nVideo\Views\Cart\Checkout.cshtml"
                                                    Write(Model.TotalValue);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n            </div>\r\n          </td>\r\n        </tr>\r\n      </tbody>\r\n    </table>\r\n    <div class=\"control-group\">\r\n      <div class=\"controls\">\r\n        <button type=\"submit\" class=\"shopBtn\">Checkout</button>\r\n      </div>\r\n    </div>\r\n  </div>");
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
