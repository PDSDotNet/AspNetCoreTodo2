#pragma checksum "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\Shared\_AdminActionsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d32865b6508866d23d70ddd2097dfd5d9db86452"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AdminActionsPartial), @"mvc.1.0.view", @"/Views/Shared/_AdminActionsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_AdminActionsPartial.cshtml", typeof(AspNetCore.Views_Shared__AdminActionsPartial))]
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
#line 2 "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\Shared\_AdminActionsPartial.cshtml"
using AspNetCoreTodo.Models;

#line default
#line hidden
#line 1 "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\Shared\_AdminActionsPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d32865b6508866d23d70ddd2097dfd5d9db86452", @"/Views/Shared/_AdminActionsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63823eaa5b73e495aebe7447edc96790f50c299d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AdminActionsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ManageUsers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(68, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(176, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\Shared\_AdminActionsPartial.cshtml"
 if(signInManager.IsSignedIn( User))
{
	var currentUser = await userManager.GetUserAsync(User);

	var isAdmin = currentUser != null && await userManager.IsInRoleAsync(currentUser, Constants.AdministratorRole);

	if(isAdmin)
	{

#line default
#line hidden
            BeginContext(413, 57, true);
            WriteLiteral("\t\t<ul class=\"nav navbar-nav navbar-right\">\r\n\t\t\t<li>\r\n\t\t\t\t");
            EndContext();
            BeginContext(470, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72b09d3268d24561bab65754d2557fd7", async() => {
                BeginContext(521, 18, true);
                WriteLiteral(" Lista de usuarios");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(543, 21, true);
            WriteLiteral("\r\n\t\t\t</li>\r\n\t\t</ul>\r\n");
            EndContext();
#line 21 "D:\Facultad\Cursos\dotNet\Codigo\AspNetCoreTodo2\AspNetCoreTodo\Views\Shared\_AdminActionsPartial.cshtml"
	}
}

#line default
#line hidden
            BeginContext(571, 2, true);
            WriteLiteral("\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> signInManager { get; private set; }
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
