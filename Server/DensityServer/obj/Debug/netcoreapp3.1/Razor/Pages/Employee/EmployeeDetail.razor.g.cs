#pragma checksum "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4883b120406f25f197520627d5ee348493243458"
// <auto-generated/>
#pragma warning disable 1591
namespace DensityServer.Pages.Employee
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.AspNetCore.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using DensityServer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using DensityServer.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using DensityServer.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\_Imports.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
using DensityServer.Server.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Employee/{EmployeeId}")]
    public partial class EmployeeDetail : EmployeeDetailBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "section");
            __builder.AddAttribute(1, "class", "employee-detail");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "h1");
            __builder.AddAttribute(4, "class", "page-title");
            __builder.AddContent(5, "Details for ");
            __builder.AddContent(6, 
#nullable restore
#line 6 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                        employee.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(7, " ");
            __builder.AddContent(8, 
#nullable restore
#line 6 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                                            employee.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n    \r\n    ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "col-12 row");
            __builder.AddMarkupContent(12, "\r\n\r\n        ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "form-group row");
            __builder.AddMarkupContent(15, "\r\n            ");
            __builder.AddMarkupContent(16, "<label class=\"col-sm-4 col-form-label\">First name</label>\r\n            ");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "col-sm-8");
            __builder.AddMarkupContent(19, "\r\n                ");
            __builder.OpenElement(20, "label");
            __builder.AddAttribute(21, "type", "text");
            __builder.AddAttribute(22, "readonly", true);
            __builder.AddAttribute(23, "class", "form-control-plaintext");
            __builder.AddContent(24, 
#nullable restore
#line 14 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                                                            employee.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n\r\n        ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "form-group row");
            __builder.AddMarkupContent(30, "\r\n            ");
            __builder.AddMarkupContent(31, "<label class=\"col-sm-4 col-form-label\">Last name</label>\r\n            ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "col-sm-8");
            __builder.AddMarkupContent(34, "\r\n                ");
            __builder.OpenElement(35, "label");
            __builder.AddAttribute(36, "type", "text");
            __builder.AddAttribute(37, "readonly", true);
            __builder.AddAttribute(38, "class", "form-control-plaintext");
            __builder.AddContent(39, 
#nullable restore
#line 21 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                                                            employee.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n\r\n\r\n        ");
            __builder.OpenElement(43, "div");
            __builder.AddAttribute(44, "class", "form-group row");
            __builder.AddMarkupContent(45, "\r\n            ");
            __builder.AddMarkupContent(46, "<label class=\"col-sm-4 col-form-label\">Email</label>\r\n            ");
            __builder.OpenElement(47, "div");
            __builder.AddAttribute(48, "class", "col-sm-8");
            __builder.AddMarkupContent(49, "\r\n                ");
            __builder.OpenElement(50, "label");
            __builder.AddAttribute(51, "type", "text");
            __builder.AddAttribute(52, "readonly", true);
            __builder.AddAttribute(53, "class", "form-control-plaintext");
            __builder.AddContent(54, 
#nullable restore
#line 29 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                                                            employee.Email

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n\r\n        ");
            __builder.OpenElement(58, "div");
            __builder.AddAttribute(59, "class", "form-group row");
            __builder.AddMarkupContent(60, "\r\n            ");
            __builder.AddMarkupContent(61, "<label class=\"col-sm-4 col-form-label\">Street</label>\r\n            ");
            __builder.OpenElement(62, "div");
            __builder.AddAttribute(63, "class", "col-sm-8");
            __builder.AddMarkupContent(64, "\r\n                ");
            __builder.OpenElement(65, "label");
            __builder.AddAttribute(66, "type", "text");
            __builder.AddAttribute(67, "readonly", true);
            __builder.AddAttribute(68, "class", "form-control-plaintext");
            __builder.AddContent(69, 
#nullable restore
#line 36 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                                                            employee.Street

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(70, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(71, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n\r\n\r\n\r\n        ");
            __builder.OpenElement(73, "div");
            __builder.AddAttribute(74, "class", "form-group row");
            __builder.AddMarkupContent(75, "\r\n            ");
            __builder.AddMarkupContent(76, "<label class=\"col-sm-4 col-form-label\">City</label>\r\n            ");
            __builder.OpenElement(77, "div");
            __builder.AddAttribute(78, "class", "col-sm-8");
            __builder.AddMarkupContent(79, "\r\n                ");
            __builder.OpenElement(80, "label");
            __builder.AddAttribute(81, "type", "text");
            __builder.AddAttribute(82, "readonly", true);
            __builder.AddAttribute(83, "class", "form-control-plaintext");
            __builder.AddContent(84, 
#nullable restore
#line 45 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                                                            employee.City

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n\r\n        ");
            __builder.OpenElement(88, "div");
            __builder.AddAttribute(89, "class", "form-group row");
            __builder.AddMarkupContent(90, "\r\n            ");
            __builder.AddMarkupContent(91, "<label class=\"col-sm-4 col-form-label\">Zip</label>\r\n            ");
            __builder.OpenElement(92, "div");
            __builder.AddAttribute(93, "class", "col-sm-8");
            __builder.AddMarkupContent(94, "\r\n                ");
            __builder.OpenElement(95, "label");
            __builder.AddAttribute(96, "type", "text");
            __builder.AddAttribute(97, "readonly", true);
            __builder.AddAttribute(98, "class", "form-control-plaintext");
            __builder.AddContent(99, 
#nullable restore
#line 52 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeDetail.razor"
                                                                            employee.Zip

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(102, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(103, "\r\n       \r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
