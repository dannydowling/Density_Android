#pragma checksum "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Components\CultureSwitcher\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cba2fe42b1d2d5b4c3f3cc948700c4144959a1d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Components_CultureSwitcher_Default), @"mvc.1.0.view", @"/Pages/Components/CultureSwitcher/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cba2fe42b1d2d5b4c3f3cc948700c4144959a1d4", @"/Pages/Components/CultureSwitcher/Default.cshtml")]
    public class Pages_Components_CultureSwitcher_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DensityServer.Localization.CultureSwitcherModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <form id=\"culture-switcher\">\r\n        <select name=\"culture\" id=\"culture-options\">\r\n            <option></option>\r\n");
#nullable restore
#line 7 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Components\CultureSwitcher\Default.cshtml"
             foreach (var culture in Model.SupportedCultures)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <option");
            BeginWriteAttribute("value", " value=\"", 286, "\"", 307, 1);
#nullable restore
#line 9 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Components\CultureSwitcher\Default.cshtml"
WriteAttributeValue("", 294, culture.Name, 294, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("selected", " selected=\"", 308, "\"", 365, 1);
#nullable restore
#line 9 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Components\CultureSwitcher\Default.cshtml"
WriteAttributeValue("", 319, Model.CurrentUICulture.Name == culture.Name, 319, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 9 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Components\CultureSwitcher\Default.cshtml"
                                                                                                   Write(culture.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 10 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Components\CultureSwitcher\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </select>\r\n    </form>\r\n</div>\r\n\r\n\r\n<script>\r\n    document.getElementById(\"culture-options\").addEventListener(\"change\", () => {\r\n        document.getElementById(\"culture-switcher\").submit();\r\n    });\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DensityServer.Localization.CultureSwitcherModel> Html { get; private set; }
    }
}
#pragma warning restore 1591