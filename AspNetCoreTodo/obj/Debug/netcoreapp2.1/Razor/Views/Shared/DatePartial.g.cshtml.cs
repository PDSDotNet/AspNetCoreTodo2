#pragma checksum "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\Shared\DatePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3ddc99267af45d9ee8bfb6dc1f228f0969b865b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_DatePartial), @"mvc.1.0.view", @"/Views/Shared/DatePartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/DatePartial.cshtml", typeof(AspNetCore.Views_Shared_DatePartial))]
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
#line 1 "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\_ViewImports.cshtml"
using AspNetCoreTodo;

#line default
#line hidden
#line 2 "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\_ViewImports.cshtml"
using AspNetCoreTodo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3ddc99267af45d9ee8bfb6dc1f228f0969b865b", @"/Views/Shared/DatePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63823eaa5b73e495aebe7447edc96790f50c299d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_DatePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 40, true);
            WriteLiteral("<!--Para que sea fuertemente tipado-->\r\n");
            EndContext();
            BeginContext(57, 58, true);
            WriteLiteral("\r\n<!--es un HTML Box que renderea un campo de entrada-->\r\n");
            EndContext();
            BeginContext(116, 112, false);
#line 5 "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\Shared\DatePartial.cshtml"
Write(Html.TextBox("", String.Format("{0:d}", Model.ToShortDateString()), new { @class = "datefield", type = "date" }));

#line default
#line hidden
            EndContext();
            BeginContext(228, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime> Html { get; private set; }
    }
}
#pragma warning restore 1591
