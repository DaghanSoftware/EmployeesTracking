#pragma checksum "C:\Users\STElb\OneDrive\Belgeler\GitHub\Asp.Net-Core--lk-Proje-Employees-Tracking-\EmployeesTracking\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56921516677bc2074ab3b4e16426f15d85588151"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56921516677bc2074ab3b4e16426f15d85588151", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!doctype html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56921516677bc2074ab3b4e16426f15d855881512752", async() => {
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56921516677bc2074ab3b4e16426f15d855881513718", async() => {
                WriteLiteral("\r\n\r\n    <label>İsim</label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 135, "\"", 149, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 150, "\"", 158, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n    <br />\r\n    <label>Soy İsim.. </label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 273, "\"", 287, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 288, "\"", 296, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n    <br />\r\n    <label>Baba Adı        </label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 416, "\"", 430, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 431, "\"", 439, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n    <br />\r\n    <label>Anne Adı</label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 551, "\"", 565, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 566, "\"", 574, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n    <br />\r\n    <label>Cinsiyet</label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 686, "\"", 700, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 701, "\"", 709, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n    <br />\r\n    <label>Medeni Hal</label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 823, "\"", 837, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 838, "\"", 846, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n    <br />\r\n    <label>TcNo</label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 954, "\"", 968, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 969, "\"", 977, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n    <br />\r\n    <label>Dogum Yeri</label>\r\n    <input type=\"text\" class=\"form-control\" id=\"firstName\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1091, "\"", 1105, 0);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1106, "\"", 1114, 0);
                EndWriteAttribute();
                WriteLiteral(" required>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n");
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
