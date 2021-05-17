#pragma checksum "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c82d0f2326b1a8101fcf4333b4a7a2fe9f19bb8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminPanel_AddEntityPartial), @"mvc.1.0.view", @"/Views/AdminPanel/AddEntityPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c82d0f2326b1a8101fcf4333b4a7a2fe9f19bb8c", @"/Views/AdminPanel/AddEntityPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68d520002171e45e2bd5b2ef281c5bea62615e49", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminPanel_AddEntityPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddEntityToDB", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
  
    Layout = "AdminPanelLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<section class=\"charts mt-4\">\r\n  <div class=\"chart-container p-3\">\r\n    <h3 class=\"fs-6 mb-3\">Add</h3>\r\n  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c82d0f2326b1a8101fcf4333b4a7a2fe9f19bb8c4956", async() => {
                WriteLiteral(@"
      <input required name=""Name"" minlength=""1"" type=""text"" maxlength=""20"" placeholder=""Name"">
      <br>
      <input  required name=""Category"" minlength=""1""  type=""text"" maxlength=""30"" placeholder=""Category"">
      <br>
      <input required name=""Articul"" minlength=""1""  type=""text"" maxlength=""20"" placeholder=""Articul"">
      <br>
      <input required name=""Price"" minlength=""1""  type=""text"" maxlength=""10"" placeholder=""Price"">
      <br>
      <input required name=""Short_Desc"" minlength=""1""  type=""text"" maxlength=""50"" placeholder=""Short Descr"">
      <br>
      <input required name=""Long_Desc"" minlength=""1""  type=""text"" maxlength=""200"" placeholder=""Long Descr"">
      <br>
      <input required name=""InStock"" minlength=""1""  type=""text"" maxlength=""8"" placeholder=""InStock"">
      <br>

");
#nullable restore
#line 26 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
        
          int i = ViewBag.Number;
          for (int j = 0; j < i; j++)
          {

#line default
#line hidden
#nullable disable
                WriteLiteral("              <input required minlength=\"1\"");
                BeginWriteAttribute("name", " name=\"", 1183, "\"", 1204, 3);
                WriteAttributeValue("", 1190, "Attributes[", 1190, 11, true);
#nullable restore
#line 30 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
WriteAttributeValue("", 1201, j, 1201, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1203, "]", 1203, 1, true);
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" maxlength=\"20\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1232, "\"", 1265, 3);
                WriteAttributeValue("", 1246, "Attribute", 1246, 9, true);
                WriteAttributeValue("  ", 1255, "name", 1257, 6, true);
#nullable restore
#line 30 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
WriteAttributeValue("  ", 1261, j, 1263, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n              <input required minlength=\"1\"");
                BeginWriteAttribute("name", "  name=\"", 1312, "\"", 1330, 3);
                WriteAttributeValue("", 1320, "Values[", 1320, 7, true);
#nullable restore
#line 31 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
WriteAttributeValue("", 1327, j, 1327, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1329, "]", 1329, 1, true);
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" maxlength=\"20\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1358, "\"", 1391, 3);
                WriteAttributeValue("", 1372, "Attribute", 1372, 9, true);
                WriteAttributeValue("  ", 1381, "value", 1383, 7, true);
#nullable restore
#line 31 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
WriteAttributeValue(" ", 1388, j, 1389, 2, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n              <br>                                                                                          \r\n");
#nullable restore
#line 33 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
          }
      
          int s = ViewBag.NumImg;
          for (int j = 0; j < s; j++)
          {

#line default
#line hidden
#nullable disable
                WriteLiteral("              <input required name=\"images\" type=\"file\"  /><br>\r\n");
#nullable restore
#line 39 "C:\NewProgram\GithubRepository\nVideo\nVideo\Views\AdminPanel\AddEntityPartial.cshtml"
          }
      

#line default
#line hidden
#nullable disable
                WriteLiteral("      <input type=\"submit\">\r\n  ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n      <div style=\"height: 300px\"> \r\n      </div>\r\n  </div>\r\n</section>   \r\n");
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
