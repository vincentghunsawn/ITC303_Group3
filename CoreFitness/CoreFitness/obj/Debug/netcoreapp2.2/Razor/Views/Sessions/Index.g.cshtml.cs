#pragma checksum "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3bffdd1180d58e8492d77cb3a97b74d5554a1b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sessions_Index), @"mvc.1.0.view", @"/Views/Sessions/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sessions/Index.cshtml", typeof(AspNetCore.Views_Sessions_Index))]
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
#line 1 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\_ViewImports.cshtml"
using CoreFitness;

#line default
#line hidden
#line 2 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\_ViewImports.cshtml"
using CoreFitness.Models;

#line default
#line hidden
#line 3 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\_ViewImports.cshtml"
using CoreFitness.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3bffdd1180d58e8492d77cb3a97b74d5554a1b5", @"/Views/Sessions/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"041a0c756b17822164c60b120370a82d5a6fe193", @"/Views/_ViewImports.cshtml")]
    public class Views_Sessions_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CoreFitness.Models.Session>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary m-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("m-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
            BeginContext(87, 104, true);
            WriteLiteral("\r\n    <div class=\"container\">\r\n        <h1 class=\"text-center\">Timetable</h1>\r\n        <p>\r\n            ");
            EndContext();
            BeginContext(191, 90, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3bffdd1180d58e8492d77cb3a97b74d5554a1b55609", async() => {
                BeginContext(242, 35, true);
                WriteLiteral("<i class=\"fas fa-plus\"></i> Session");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(281, 628, true);
            WriteLiteral(@"
        </p>
        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        Class
                    </th>
                    <th>
                        Instructor
                    </th>
                    <th>
                        Day
                    </th>
                    <th>
                        Session Start
                    </th>
                    <th>
                        Session End
                    </th>

                    <th></th>
                </tr>
            </thead>
            <tbody>

");
            EndContext();
#line 36 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                 if (Model.Any())
                {
                    

#line default
#line hidden
#line 38 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
            BeginContext(1036, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1109, 44, false);
#line 42 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ClassName));

#line default
#line hidden
            EndContext();
            BeginContext(1153, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1233, 49, false);
#line 45 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.InstructorName));

#line default
#line hidden
            EndContext();
            BeginContext(1282, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1362, 38, false);
#line 48 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Day));

#line default
#line hidden
            EndContext();
            BeginContext(1400, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1480, 51, false);
#line 51 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SessionStartTime));

#line default
#line hidden
            EndContext();
            BeginContext(1531, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1611, 49, false);
#line 54 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SessionEndTime));

#line default
#line hidden
            EndContext();
            BeginContext(1660, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1739, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3bffdd1180d58e8492d77cb3a97b74d5554a1b510691", async() => {
                BeginContext(1796, 46, true);
                WriteLiteral("<i class=\"fas fa-pencil-alt text-success\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 57 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                                               WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1846, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(1872, 108, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3bffdd1180d58e8492d77cb3a97b74d5554a1b513197", async() => {
                BeginContext(1931, 45, true);
                WriteLiteral(" <i class=\"fas fa-trash-alt text-danger\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 58 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                                                 WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1980, 126, true);
            WriteLiteral("\r\n                        <a class=\"btn btn-primary m-1\" href=\"#\">Book</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 62 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                    }

#line default
#line hidden
#line 62 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                     
                }
                else
                {

#line default
#line hidden
            BeginContext(2189, 129, true);
            WriteLiteral("                    <tr>\r\n                        <td>No sessions available at the current time</td>\r\n                    </tr>\r\n");
            EndContext();
#line 69 "C:\Users\Dell\Documents\GitHub\ITC303_Group3\CoreFitness\CoreFitness\Views\Sessions\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2337, 54, true);
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CoreFitness.Models.Session>> Html { get; private set; }
    }
}
#pragma warning restore 1591
