#pragma checksum "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/AttributesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39faf485d10b057234270b75b31689535f62eb86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_AttributesPartial), @"mvc.1.0.view", @"/Views/Shared/AttributesPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39faf485d10b057234270b75b31689535f62eb86", @"/Views/Shared/AttributesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c72bbff02bf8846323edcc6f38763f3d8d52447", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AttributesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Catalog_Attribute>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n    <tr class=\"techSpecRow\">\n        <td class=\"techSpecTD1\">\n            ");
#nullable restore
#line 5 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/AttributesPartial.cshtml"
       Write(Model.AttributeName);

#line default
#line hidden
#nullable disable
            WriteLiteral(":\n        </td>\n        <td class=\"techSpecTD2\">\n");
#nullable restore
#line 8 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/AttributesPartial.cshtml"
               
                if (Model.Value != null)
                {
                    if (Model.Value.IntegerValue.HasValue)
                    { 

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/AttributesPartial.cshtml"
                 Write(Model.Value.IntegerValue);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/AttributesPartial.cshtml"
                                                }
                    else
                    { 

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/AttributesPartial.cshtml"
                 Write(Model.Value.StringValue);

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/Marshall483/Documents/sources/repos/nVideo/nVideo/nVideo/Views/Shared/AttributesPartial.cshtml"
                                               }
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\n    </tr>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Catalog_Attribute> Html { get; private set; }
    }
}
#pragma warning restore 1591
