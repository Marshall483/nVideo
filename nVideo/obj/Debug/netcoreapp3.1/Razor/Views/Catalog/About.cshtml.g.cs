#pragma checksum "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "611296ea664973c968fd5a550d239287eb1cf099"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalog_About), @"mvc.1.0.view", @"/Views/Catalog/About.cshtml")]
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
#line 1 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\_ViewImports.cshtml"
using nVideo.DATA.ControllerModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"611296ea664973c968fd5a550d239287eb1cf099", @"/Views/Catalog/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalog_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AboutViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Catalog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"span9\">\r\n\r\n    <ul class=\"breadcrumb\">\r\n        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "611296ea664973c968fd5a550d239287eb1cf0994381", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <span class=\"divider\">/</span></li>\r\n        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "611296ea664973c968fd5a550d239287eb1cf0995588", async() => {
                WriteLiteral("Items");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" <span class=""divider"">/</span></li>
        <li class=""active"">About</li>
    </ul>

    <div class=""well well-small"">
        <div class=""row-fluid"">
            <div class=""span5"">
                <div id=""myCarousel"" class=""carousel slide cntr"">
                    <div class=""carousel-inner"">

");
#nullable restore
#line 16 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                           foreach (var p in Model.Entity.Images)
                           {
                               

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                          Write(await Html.PartialAsync("ItemCarouselPartial", p));

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                                                                                 
                           }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <a class=""left carousel-control"" href=""#myCarousel"" data-slide=""prev"">‹</a>
                    <a class=""right carousel-control"" href=""#myCarousel"" data-slide=""next"">›</a>
                </div>
            </div>
            ");
#nullable restore
#line 27 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
       Write(await Html.PartialAsync("AboutItemPartial", Model.Entity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n        <hr class=\"softn clr\">\r\n\r\n        <ul id=\"productDetail\" class=\"nav nav-tabs\">\r\n            <li class=\"active\"><a href=\"#home\" data-toggle=\"tab\">Product Details</a></li>\r\n            <li");
            BeginWriteAttribute("class", " class=\"", 1325, "\"", 1333, 0);
            EndWriteAttribute();
            WriteLiteral(@"><a href=""#profile"" data-toggle=""tab"">Related Products </a></li>
        </ul>

        <div id=""myTabContent"" class=""tab-content tabWrapper"">
            <div class=""tab-pane fade active in"" id=""home"">
                <h4>More info</h4>
                <table class=""table table-striped"">
                    <tbody>
");
#nullable restore
#line 42 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                       foreach (var atr in Model.Entity.Attributes)
                       {
                           

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                      Write(await Html.PartialAsync("AttributesPartial", atr));

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                                                                             
                       }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n\r\n            ");
#nullable restore
#line 51 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
       Write(Model.Entity.Long_Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            <div class=\"tab-pane fade\" id=\"profile\">\r\n                <div class=\"row-fluid\">\r\n\r\n");
#nullable restore
#line 56 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                      
                        foreach (var product in Model.Related_Products)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                       Write(await Html.PartialAsync("ReleatedProductsPartial", product));

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                                                                                        
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    \r\n    <h4>Comments</h4>\r\n    \r\n    <div class=\"well well-small span9\">\r\n");
#nullable restore
#line 71 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
         using (Html.BeginForm("AddCommentAsync", "Catalog", FormMethod.Post))
        {
      
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
       Write(Html.ValidationMessage("Error"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
       Write(Html.Hidden("entityId", Model.Entity.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-12\">\r\n                <div class=\"panel\">Raiting\r\n\r\n                    ");
#nullable restore
#line 80 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
               Write(Html.DropDownList("rating", Model.SelectRating, new { required="" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    <div class=\"panel-body\">\r\n                        ");
#nullable restore
#line 83 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                   Write(Html.TextArea("content", value: "", rows: 5, columns: 200, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"mar-top clearfix\">\r\n                            <p><input type=\"submit\" value=\"Add\"/></p>\r\n                        </div>\r\n                    </div>\r\n            \r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 91 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("      \r\n\r\n        <hr class=\"softn clr\" />\r\n\r\n");
#nullable restore
#line 96 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
          
            if (Model.Entity.Comments.Any())
            {
                foreach (var comment in Model.Entity.Comments)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
               Write(await Html.PartialAsync("CommentsPartial", comment));

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
                                                                        
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h2>Here is no comments now... Be First!</h2>\r\n");
#nullable restore
#line 107 "C:\Users\jows1\source\repos\nVideo\nVideo\Views\Catalog\About.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"      
    </div>
</div>
<style>
  .img-sm {
    width: 46px;
    height: 46px;
  }

  .media-block .media-left {
    display: block;
    float: left
  }

  .media-block .media-right {
    float: right
  }

  .media-block .media-body {
    display: block;
    overflow: hidden;
    width: auto
  }

  .middle .media-left,
  .middle .media-right,
  .middle .media-body {
    vertical-align: middle
  }
</style>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AboutViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
