#pragma checksum "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b17d9fa6320bac563ee89c354a61c0e998fdc1a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GoalsTable_Index), @"mvc.1.0.view", @"/Views/GoalsTable/Index.cshtml")]
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
#line 1 "C:\Users\Mark\source\repos\IAR\IAR\Views\_ViewImports.cshtml"
using IAR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mark\source\repos\IAR\IAR\Views\_ViewImports.cshtml"
using IAR.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b17d9fa6320bac563ee89c354a61c0e998fdc1a9", @"/Views/GoalsTable/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"309e1cd1ee0282c11dda5cde4d6db8271c6bf44f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_GoalsTable_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IAR.Models.GoalModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewGoal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b17d9fa6320bac563ee89c354a61c0e998fdc1a93547", async() => {
                WriteLiteral("\r\n\t<div class=\"form-group\">\r\n\t\t<input type=\"submit\" value=\"Add New\" class=\"btn btn-primary\" />\r\n\t</div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>            \r\n            <th>\r\n                ");
#nullable restore
#line 13 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Activity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Goal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n");
#nullable restore
#line 25 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>            \r\n            <td>\r\n                ");
#nullable restore
#line 28 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Activity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Goal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>  \r\n            \r\n\t\t    <td>\t\t\t\r\n\t\t\t    ");
#nullable restore
#line 36 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
           Write(Html.ActionLink("Edit", "EditGoal", new { Id = item.Id, Activity = item.Activity, Goal = item.Goal }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n\t\t\t    ");
#nullable restore
#line 37 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
           Write(Html.ActionLink("Delete", "DeleteGoal", new { Id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral("\r\n\t\t    </td>\r\n        </tr>");
#nullable restore
#line 39 "C:\Users\Mark\source\repos\IAR\IAR\Views\GoalsTable\Index.cshtml"
             }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IAR.Models.GoalModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591