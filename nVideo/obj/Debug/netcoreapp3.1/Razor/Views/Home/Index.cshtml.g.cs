#pragma checksum "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ebc3d687ce839947e8e2b125429ab89d40b0007"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ebc3d687ce839947e8e2b125429ab89d40b0007", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<!--Body Section--> \r\n\r\n    <div class=\"span9\">\r\n        <div class=\"well np\">\r\n            <div id=\"myCarousel\" class=\"carousel slide homCar\">\r\n                <div class=\"carousel-inner\">\r\n\r\n");
#nullable restore
#line 11 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                      foreach(var e in Model.ForCarousel) { 
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                       Write(Html.Partial("HomeCarouselPartial", e));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                                                   
                      }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <a class=""left carousel-control"" href=""#myCarousel"" data-slide=""prev"">&lsaquo;</a>
                <a class=""right carousel-control"" href=""#myCarousel"" data-slide=""next"">&rsaquo;</a>
            </div>
        </div>

        <!--New Products-->

        <div class=""well well-small"">
            <h3>Новые товары</h3>
            <hr class=""soften"" />
            <div class=""row-fluid"">
                <div id=""newProductCar"" class=""carousel slide"">
                    <div class=""carousel-inner"">
                        <div class=""item active"">
                            <ul class=""thumbnails"">

");
#nullable restore
#line 33 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                  foreach (var e in Model.ForNewProductsBlock.Take(4)){
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                   Write(Html.Partial("NewProductPartial", e));

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                                                             
                                  }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </ul>\r\n                        </div>\r\n                        <div class=\"item\">\r\n                            <ul class=\"thumbnails\">\r\n\r\n");
#nullable restore
#line 43 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                  foreach (var e in Model.ForNewProductsBlock.Skip(4)){
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                   Write(Html.Partial("NewProductPartial", e));

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                                                             
                                  }
                                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </ul>
                        </div>
                    </div>
                    <a class=""left carousel-control"" href=""#newProductCar"" data-slide=""prev"">&lsaquo;</a>
                    <a class=""right carousel-control"" href=""#newProductCar"" data-slide=""next"">&rsaquo;</a>
                </div>
            </div>

            <div class=""row-fluid"">
                <ul class=""thumbnails"">

");
#nullable restore
#line 59 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                      foreach (var e in Model.ForThumbnailBlock){
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                       Write(Html.Partial("ThumbnailsPartial", e));

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                                                 
                      }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    
                </ul>
            </div>
        </div>

        <!--Featured Products-->

        <div class=""well well-small"">
            <h3><a class=""btn btn-mini pull-right"" href=""products.html"" title=""View more"">View More<span class=""icon-plus""></span></a> Featured Products  </h3>
            <hr class=""soften"" />
            <div class=""row-fluid"">
                <ul class=""thumbnails"">

");
#nullable restore
#line 76 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                      foreach (var e in Model.ForFeaturedBlock){
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                       Write(Html.Partial("FeaturedPartial", e));

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\danik\OneDrive\Documents\GIthub\nVideo\nVideo\Views\Home\Index.cshtml"
                                                               
                      }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n            </div>\r\n        </div>\r\n\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
