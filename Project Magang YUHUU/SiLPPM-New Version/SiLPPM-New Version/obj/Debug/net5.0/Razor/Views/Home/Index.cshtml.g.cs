#pragma checksum "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f966f31b6fe21861250a8481fb932cd2536c9f23"
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
#line 1 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\_ViewImports.cshtml"
using SiLPPM_New_Version;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\_ViewImports.cshtml"
using SiLPPM_New_Version.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
using SiLPPM_New_Version.DAO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f966f31b6fe21861250a8481fb932cd2536c9f23", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b08c312e7ea83b29c6737124f9e35c37061a0152", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/StyleSheet.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/font-awesome-4.7.0/css/font-awesome.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
   Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "Dashboard";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
   var role = User.Claims
                            .Where(c => c.Type == "role")
                                .Select(c => c.Value).SingleOrDefault();

    var nama = User.Claims
        .Where(c => c.Type == "nama_lengkap")
            .Select(c => c.Value).SingleOrDefault();

    var username = User.Claims
        .Where(c => c.Type == "username")
            .Select(c => c.Value).SingleOrDefault();

        

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f966f31b6fe21861250a8481fb932cd2536c9f235804", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f966f31b6fe21861250a8481fb932cd2536c9f236066", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <link href=\"https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,200;0,400;0,600;1,200;1,400;1,600&display=swap\"\r\n          rel=\"stylesheet\">\r\n       <link rel = \"icon\" href = \"./images/atma-logo.png\" \r\n        type = \"image/x-icon\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f966f31b6fe21861250a8481fb932cd2536c9f237510", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <style>
        .icon-wrapper {
            width: 100%;
        }


        .judul {
            margin-top: 30px;
            margin-left: 16px;
        }

        .sub-judul {
            margin-left: 16px;
            font-size: 12pt;
            text-align: justify;
        }

        .card-content-1 {
            background-color: #FFBE69;
            border-radius: 15px;
            border-color: transparent;
            max-width: 30% !important;
        }

        .card-content-2 {
            background-color: #4BB7F2;
            border-radius: 15px;
            border-color: transparent;
            max-width: 30% !important;
        }

        .card-content-3 {
            background-color: #63F287;
            border-radius: 15px;
            border-color: transparent;
            max-width: 30% !important;
        }

        .content-wrapper {
            min-height: fit-content !important;
        }

     

        ");
                WriteLiteral(@"@media(max-width: 600px) {
            .judul

        {
            font-size: 18pt;
        }

        .sub-judul {
            font-size: 10pt;
        }

        .card-content-1 {
            margin-top: 30px;
        }

        .card-content-2 {
            margin-top: 30px;
        }

        .card-content-3 {
            margin-top: 30px;
        }
        }
    </style>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f966f31b6fe21861250a8481fb932cd2536c9f2310826", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 100 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
     if (TempData["err_message"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("<script>\r\n");
                WriteLiteral("        Swal.fire({\r\n            title: \'Login Berhasil! \',\r\n            text: \"");
#nullable restore
#line 106 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
              Write(TempData["err_message"].ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("\",\r\n            confirmButtonColor: \'#f2aa4c\',\r\n            confirmButtonText: \'Close\'\r\n        })\r\n</script>\r\n");
#nullable restore
#line 111 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div class=\"px-3 content-wrapper bg-transparent\">\r\n        <h1 class=\"judul\" style=\"text-align:center; background-color:aliceblue; font-family:\'Berlin Sans FB\'\">Selamat Datang ");
#nullable restore
#line 114 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                                                                                                                        Write(nama);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"  </h1>

        <h5 class=""sub-judul pr-4"" style=""text-align:center; font-family:'Comic Sans MS'"">
            Sistem Informasi Lembaga Penelitian dan Pengabdian Masyarakat Universitas
            Atma Jaya Yogyakarta
        </h5>
        <h5 class=""sub-judul pr-4"" style=""text-align:center; font-family:'Comic Sans MS'"">
            Sistem ini meliputi pelayanan akan kegiatan dosen berupa Penelitian dan
            Pengabdian.
        </h5>
        <br /><br />
              <div class=""row1-container"">
                  <div class=""box cyan"">
                      <h2 style=""font-size:25px""> Total Penelitian</h2>
");
#nullable restore
#line 128 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                       foreach (var item in Model.count)
                      {

#line default
#line hidden
#nullable disable
                WriteLiteral("                          <p>");
#nullable restore
#line 130 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                        Write(item.JUMLAH);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n");
#nullable restore
#line 131 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                      }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                      <img src=\"https://assets.codepen.io/2301174/icon-supervisor.svg\"");
                BeginWriteAttribute("alt", " alt=\"", 3819, "\"", 3825, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                  </div>\r\n\r\n                  <div class=\"box red\">\r\n                      <h2 style=\"font-size:25px\">Total Penelitian Selesai</h2>\r\n");
#nullable restore
#line 138 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                       foreach (var item in Model.countSelesai)
                      {

#line default
#line hidden
#nullable disable
                WriteLiteral("                          <p>");
#nullable restore
#line 140 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                        Write(item.JUMLAH);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n");
#nullable restore
#line 141 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                      }

#line default
#line hidden
#nullable disable
                WriteLiteral("                      <img src=\"https://assets.codepen.io/2301174/icon-team-builder.svg\"");
                BeginWriteAttribute("alt", " alt=\"", 4228, "\"", 4234, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                  </div>\r\n\r\n                  <div class=\"box blue\">\r\n                      <h2 style=\"font-size:25px\">Total Pengabdian</h2>\r\n");
#nullable restore
#line 147 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                       foreach (var item in Model.countPengabdian)
                      {

#line default
#line hidden
#nullable disable
                WriteLiteral("                          <p>");
#nullable restore
#line 149 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                        Write(item.JUMLAH);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>");
#nullable restore
#line 149 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                                             }

#line default
#line hidden
#nullable disable
                WriteLiteral("                      <img src=\"https://assets.codepen.io/2301174/icon-calculator.svg\"");
                BeginWriteAttribute("alt", " alt=\"", 4607, "\"", 4613, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                  </div>\r\n                  <div class=\"box orange\">\r\n                      <h2 style=\"font-size:25px\">Total Penelitian Menunggu Review</h2>\r\n");
#nullable restore
#line 154 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                       foreach (var item in Model.countMenungguReview)
                      {

#line default
#line hidden
#nullable disable
                WriteLiteral("                          <p>");
#nullable restore
#line 156 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                        Write(item.JUMLAH);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>");
#nullable restore
#line 156 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Home\Index.cshtml"
                                             }

#line default
#line hidden
#nullable disable
                WriteLiteral("                      <img src=\"https://assets.codepen.io/2301174/icon-karma.svg\"");
                BeginWriteAttribute("alt", " alt=\"", 5001, "\"", 5007, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                  </div>\r\n              </div>\r\n     \r\n\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>");
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
