<<<<<<< HEAD
#pragma checksum "C:\Users\User\Desktop\nVideo\nVideo\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13b80b2c32464e8e3fd46dacec2946486c991f4d"
=======
#pragma checksum "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13b80b2c32464e8e3fd46dacec2946486c991f4d"
>>>>>>> main
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
<<<<<<< HEAD
#line 1 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
=======
#line 1 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
>>>>>>> main
using nVideo;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 2 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
=======
#line 2 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
>>>>>>> main
using nVideo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 3 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
=======
#line 3 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
>>>>>>> main
using nVideo.DATA.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 4 "C:\Users\User\Desktop\nVideo\nVideo\Views\_ViewImports.cshtml"
=======
#line 4 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
>>>>>>> main
using nVideo.DATA.ControllerModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13b80b2c32464e8e3fd46dacec2946486c991f4d", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
<<<<<<< HEAD
#line 2 "C:\Users\User\Desktop\nVideo\nVideo\Views\Shared\Error.cshtml"
=======
#line 2 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\Shared\Error.cshtml"
>>>>>>> main
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n<h2>");
#nullable restore
<<<<<<< HEAD
#line 8 "C:\Users\User\Desktop\nVideo\nVideo\Views\Shared\Error.cshtml"
=======
#line 8 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\Shared\Error.cshtml"
>>>>>>> main
       if (ViewBag.Message != null)
        

#line default
#line hidden
#nullable disable
#nullable restore
<<<<<<< HEAD
#line 9 "C:\Users\User\Desktop\nVideo\nVideo\Views\Shared\Error.cshtml"
=======
#line 9 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\Shared\Error.cshtml"
>>>>>>> main
   Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n\r\n");
#nullable restore
<<<<<<< HEAD
#line 11 "C:\Users\User\Desktop\nVideo\nVideo\Views\Shared\Error.cshtml"
=======
#line 11 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\Shared\Error.cshtml"
>>>>>>> main
 if (Model.ShowRequestId)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        <strong>Request ID:</strong> <code>");
#nullable restore
<<<<<<< HEAD
#line 14 "C:\Users\User\Desktop\nVideo\nVideo\Views\Shared\Error.cshtml"
=======
#line 14 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\Shared\Error.cshtml"
>>>>>>> main
                                      Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n    </p>\r\n");
#nullable restore
<<<<<<< HEAD
#line 16 "C:\Users\User\Desktop\nVideo\nVideo\Views\Shared\Error.cshtml"
=======
#line 16 "C:\Users\Alexander Putilin\source\repos\nVideo\nVideo\Views\Shared\Error.cshtml"
>>>>>>> main
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Development Mode</h3>
<p>
    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
