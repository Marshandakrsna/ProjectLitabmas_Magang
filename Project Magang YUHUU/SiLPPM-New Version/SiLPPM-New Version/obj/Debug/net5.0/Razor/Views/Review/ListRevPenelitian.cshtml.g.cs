#pragma checksum "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec6da0cdd8c5f49d381999678eae1f3ec5ece515"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Review_ListRevPenelitian), @"mvc.1.0.view", @"/Views/Review/ListRevPenelitian.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec6da0cdd8c5f49d381999678eae1f3ec5ece515", @"/Views/Review/ListRevPenelitian.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b08c312e7ea83b29c6737124f9e35c37061a0152", @"/Views/_ViewImports.cshtml")]
    public class Views_Review_ListRevPenelitian : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/font-awesome-4.7.0/css/font-awesome.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml"
  
    ViewData["Title"] = "List Review Penelitian";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec6da0cdd8c5f49d381999678eae1f3ec5ece5155001", async() => {
                WriteLiteral("\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 110, "\"", 192, 2);
                WriteAttributeValue("", 117, "https://cdn.jsdelivr.net/npm/", 117, 29, true);
                WriteLiteral("@");
                WriteAttributeValue("", 148, "mdi/font@5.x/css/materialdesignicons.min.css", 148, 44, true);
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ec6da0cdd8c5f49d381999678eae1f3ec5ece5155689", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec6da0cdd8c5f49d381999678eae1f3ec5ece5156868", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- Data Table-->\r\n");
                WriteLiteral("    <style>\r\n        ");
                WriteLiteral(@"@import url('https://fonts.googleapis.com/css2?family=Karla:wght@400;500;600;700&display=swap');

        body {
            font-family: 'Karla', sans-serif;
        }


        [aria-expanded=""false""] > .expanded, [aria-expanded=""true""] > .collapsed {
            display: none;
        }

        .table thead th {
            vertical-align: middle;
            align-content: center;
            text-align: center;
        }

        .label {
            color: white;
            border-radius: 5px;
            border-spacing: 20px;
            padding: 5px;
            margin-top: 50px;
            margin-bottom: 60px;
        }



        .btn:active {
            background-color: indianred;
            transform: translateY(4px);
        }

        .btn:hover {
            background-color: indianred;
        }

        .content-wrapper {
            border-radius: 10px;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
            transition: 0.3s;
          ");
                WriteLiteral(@"  background-color: white;
            border-radius: 10px;
            min-height: 402px !important;
        }

        .title-card {
            color: #FFFFFF;
            background-color: #F2AA4C;
            padding: 15px;
            border-radius: 10px 10px 0px 0px;
            min-width: inherit;
        }

        a:hover, a:active {
            color: white;
        }


        .td, th {
            vertical-align: middle;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec6da0cdd8c5f49d381999678eae1f3ec5ece51510417", async() => {
                WriteLiteral(@"


    <div class=""px-3 mt-3"">
        <div class=""content-wrapper p-3"" style="" background-color: white;"">

            <h5 class=""card-header font-weight-bold bg-light""><span class=""text-black"">History Penelitian</span></h5>


            <div style=""width: 100%; overflow-x: auto;"" class=""col"">
                <div class=""card-body"">
                    <table id=""tblDataHistoryPenelitian"" class=""table table-bordered table-striped"">
                        <thead>
                            <tr>
                                <th>AKSI</th>
                                <th>ID PROPOSAL</th>
                              
                                <th>JUDUL</th>
                                <th>STATUS</th>
                           
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 105 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml"
                             foreach (var item in Model.listReview)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <tr>
                                    <td>
                                        <p  style="" font-weight: bold; background-color: coral; border-radius: 33px; margin-left: 10px; width: 82px; vertical-align: middle; text-align-last: center; padding: 5px; cursor: pointer;"" class="" btn text-center""><i class=""fas fa-comment-dots"">&nbsp;<a style=""color:black; """);
                BeginWriteAttribute("href", " href=\"", 3429, "\"", 3479, 2);
                WriteAttributeValue("", 3436, "RevPenelitian?id_proposal=", 3436, 26, true);
#nullable restore
#line 109 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml"
WriteAttributeValue("", 3462, item.id_proposal, 3462, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Pilih</a></i></p>\r\n                                    </td>\r\n                                    <td> ");
#nullable restore
#line 111 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml"
                                    Write(item.id_proposal);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                 \r\n                                    <td>");
#nullable restore
#line 113 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml"
                                   Write(item.Judul);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 114 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml"
                                   Write(item.DESKRIPSI);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                \r\n                                </tr>\r\n");
#nullable restore
#line 117 "E:\Kuliah\SEMESTER 6\Magang\Project Magang YUHUU\SiLPPM-New Version\SiLPPM-New Version\Views\Review\ListRevPenelitian.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </tbody>
                    </table>
                </div>

            </div>


        </div>
    </div>


    <script src=""https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js""></script>
    <script src=""https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.25/js/dataTables.bootstrap4.min.js""></script>

");
                DefineSection("Scripts", async() => {
                    WriteLiteral(@"

        <script>
            var tblDataDaftarPengabdian;
            refreshTabelDaftarPengabdian();

            function refreshTabelDaftarPengabdian() {
                tblDataDaftarPengabdian = $(""#tblDataHistoryPenelitian"").DataTable({

                    ""paging"": true,
                    ""lengthChange"": true,
                    ""searching"": true,
                    ""ordering"": true,
                    ""info"": true,
                    ""autoWidth"": false,
                    ""responsive"": true,
                }).buttons().container().appendTo('#tblDataHistoryPenelitian_wrapper .col-md-6:eq(0)');
            }


        </script>
    ");
                }
                );
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
            WriteLiteral("\r\n</html>\r\n");
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
