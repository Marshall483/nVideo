#pragma checksum "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Cart/Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b0435eb25179dcb452ab83fc6bea21caae7fd98"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b0435eb25179dcb452ab83fc6bea21caae7fd98", @"/Views/Cart/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c72bbff02bf8846323edcc6f38763f3d8d52447", @"/Views/_ViewImports.cshtml")]
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
          <label class=""span2 control-label"">To pay:$ ");
#nullable restore
#line 17 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Cart/Checkout.cshtml"
                                                  Write(Model.TotalValue / 74);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </label>
        </div>
      </td>
    </tr>
    </tbody>
  </table>
  <div class=""control-group"">
    <div class=""controls"">
      <a href=""#selectDelivery"" class=""btn"" data-toggle=""modal"">Go to checkout |-></a>
    </div>
  </div>
</div>

<!-- Delivery Select Modal -->
<div id=""selectDelivery"" class=""modal hide fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
  <div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
  </div>
<div class=""modal-body"">
  <div class=""span8 well well-small"">
            
    <h2> What type of delivery you want? </h2>
");
#nullable restore
#line 39 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Cart/Checkout.cshtml"
     using (Html.BeginForm("ProcessOrder", "Order", FormMethod.Get)){
           

#line default
#line hidden
#nullable disable
            WriteLiteral("      <p>\n        <strong>Delivery?</strong>\n        ");
#nullable restore
#line 43 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Cart/Checkout.cshtml"
   Write(Html.DropDownList("deliveryType", Model.DeliveryType , new { required="" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n      </p>\n");
            WriteLiteral("      <p>\n        <input type=\"submit\" value=\"Apply\"/>\n      </p>\n");
#nullable restore
#line 49 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Cart/Checkout.cshtml"
           
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("       \n  </div>\n</div>\n</div>");
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