#pragma checksum "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\Shared\AttributesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "875c3b5f6b2949bebe930ead57bd1e3d43e655ce"
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
#line 1 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ControllerModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"875c3b5f6b2949bebe930ead57bd1e3d43e655ce", @"/Views/Shared/AttributesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_AttributesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Catalog_Attribute>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <tr class=\"techSpecRow\">\r\n        <td class=\"techSpecTD1\">\r\n            ");
#nullable restore
#line 5 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\Shared\AttributesPartial.cshtml"
       Write(Model.AttributeName);

#line default
#line hidden
#nullable disable
            WriteLiteral(":\r\n        </td>\r\n        <td class=\"techSpecTD2\">\r\n");
#nullable restore
#line 8 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\Shared\AttributesPartial.cshtml"
               
                if (Model.Value != null)
                {
                    if (Model.Value.IntegerValue.HasValue)
                    { 

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\Shared\AttributesPartial.cshtml"
                 Write(Model.Value.IntegerValue);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\Shared\AttributesPartial.cshtml"
                                                }
                    else
                    { 

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\Shared\AttributesPartial.cshtml"
                 Write(Model.Value.StringValue);

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\Shared\AttributesPartial.cshtml"
                                               }
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n    </tr>");
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
