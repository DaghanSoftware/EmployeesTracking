#pragma checksum "C:\Users\STElb\OneDrive\Belgeler\GitHub\Asp.Net-Core--lk-Proje-Employees-Tracking-\EmployeesTracking\Views\Home\Deneme.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cdaf338bfe3155213cddc0f75b7d4ff843847da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Deneme), @"mvc.1.0.view", @"/Views/Home/Deneme.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4cdaf338bfe3155213cddc0f75b7d4ff843847da", @"/Views/Home/Deneme.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a67e1bc04bd13950d2576b6c5ab68b6edae8296", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Deneme : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("Deneme"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cdaf338bfe3155213cddc0f75b7d4ff843847da4725", async() => {
                WriteLiteral(@"
    <script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>
    <link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"" rel=""stylesheet"" integrity=""sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"" crossorigin=""anonymous"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cdaf338bfe3155213cddc0f75b7d4ff843847da6093", async() => {
                WriteLiteral(@"
    <div class=""buttons"">
        <div class=""upload-button"">
            <div class=""label"">Click me!</div>
            <input id=""Resim"" name=""Resim"" type=""file"" size=""1""  />
            <button type=""submit"" id=""btnPersonelKaydet"" class=""btn btn-success""> Personel Kaydet  </button>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>

    $(""#form"").submit(function (e) {
        e.preventDefault();
        //Alt tarafta bulunan kodların hepsine eşit olan değişken başlangıç
        let data = new FormData($(""#form"")[0]);
        //Alt tarafta bulunan kodların hepsine eşit olan değişken son


        var input = document.getElementById(""Resim"");
        var files = input.files;
        var formData = new FormData();

        for (var i = 0; i != files.length; i++) {
            formData.append(""Resim"", files[i]);
        }

        $.ajax(
            {
                url: ""/Home/PersonelKaydet"",
                data: formData,
                processData: false,
                contentType: false,
                type: ""POST"",
                success: function (data) {
                    alert(""Files Uploaded!"");
                }
            }
        );
    });

        
    
</script>
<div id=""Resim göndermek için yapılan denemeler"">
    <!--<div class=""col-12 grid-margin stretch-card"">");
            WriteLiteral(@"
    <div class=""card"">
        <div class=""card-body"">
            <h4 class=""card-title"">Profi bilgileri düzenleme</h4>
            <form asp-action=""Deneme"" asp-controller=""Home"" class=""forms-sample"" enctype=""multipart/form-data"">
                <div asp-validation-summary=""All"" id=""hatalar""> </div>
                <input type=""hidden"" asp-for=""Id"" class=""form-control"">
                <div class=""col-md-6"">
                    <label asp-for=""Adi"" class=""form-label"">İsim</label>
                    <input asp-for=""Adi"" class=""form-control"">
                    <span asp-validation-for=""Adi"" class=""text-danger""></span>
                </div>
                <div class=""col-md-6"">
                    <label asp-for=""Soyadi"" class=""form-label"">Soyisim</label>
                    <input asp-for=""Soyadi"" class=""form-control"">
                    <span asp-validation-for=""Soyadi"" class=""text-danger""></span>
                </div>
                <div class=""col-md-6"">
                    <labe");
            WriteLiteral(@"l asp-for=""TcNo"" class=""form-label"">Tc Kimlik Numarası</label>
                    <input asp-for=""TcNo"" maxlength=""11"" class=""form-control"">
                    <span asp-validation-for=""TcNo"" class=""text-danger""></span>
                </div>
                <div class=""col-md-6"">
                    <label asp-for=""BabaAdi"" class=""form-label"">Baba Adı</label>
                    <input asp-for=""BabaAdi"" class=""form-control"">
                    <span asp-validation-for=""BabaAdi"" class=""text-danger""></span>
                </div>
                <div class=""col-md-6"">
                    <label asp-for=""AnaAdi"" class=""form-label"">Anne Adı</label>
                    <input asp-for=""AnaAdi"" class=""form-control"">
                </div>
                <div class=""col-md-6"">
                    <div class=""form-group"">
                        <label>Erkek</label>
                        <input type=""radio"" value=""1"" asp-for=""GenderId"" />
                        <br />
                        ");
            WriteLiteral(@"<label>Kadın</label>
                        <input type=""radio"" value=""2"" asp-for=""GenderId"" />
                        <span asp-validation-for=""GenderId"" class=""text-danger""></span>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""form-group"">
                        <label asp=""Doğum Yeri"">Doğum Yeri</label>
                        <select asp-for=""CityId"" asp-items=""");
#nullable restore
#line 96 "C:\Users\STElb\OneDrive\Belgeler\GitHub\Asp.Net-Core--lk-Proje-Employees-Tracking-\EmployeesTracking\Views\Home\Deneme.cshtml"
                                                       Write(ViewBag.Cities);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" class=""form-control"">
                            <option selected disabled>Şehir Seçiniz</option>

                        </select>
                        <span asp-validation-for=""CityId"" class=""text-danger""></span>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <div class=""form-group"">
                        <label>Evli</label>
                        <input type=""radio"" value=""1"" asp-for=""MaritalStatusId"" />
                        <br />
                        <label>Bekar</label>
                        <input type=""radio"" value=""2"" asp-for=""MaritalStatusId"" />
                        <span asp-validation-for=""MaritalStatusId"" class=""text-danger""></span>
                    </div>
                </div>
                <div class=""col-md-12"">
                    <div class=""form-group"">
                        <label>Profil Resmi</label>
                        <input type=""file"" asp-for=""Resim"" class=""form-control"">");
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"col-12\">\r\n                    <button type=\"submit\" class=\"btn btn-gradient-primary mr-2\">Güncelle</button>-->\r\n");
            WriteLiteral("    <!--</div>\r\n                </form>\r\n            </div>\r\n        </div>\r\n    </div>-->\r\n\r\n\r\n\r\n\r\n\r\n");
            WriteLiteral(@"
<script>
    //function uploadFiles(inputId) {
    //    var input = document.getElementById(inputId);
    //    var files = input.files;
    //    var formData = new FormData();

    //    for (var i = 0; i != files.length; i++) {
    //        formData.append(""files"", files[i]);
    //    }

    //    $.ajax(
    //        {
    //            url: ""/Home/Deneme"",
    //            data: formData,
    //            processData: false,
    //            contentType: false,
    //            type: ""POST"",
    //            success: function (data) {
    //                alert(""Files Uploaded!"");
    //            }
    //        }
    //    );
    //}
</script>
</div>






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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
