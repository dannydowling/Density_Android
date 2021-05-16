#pragma checksum "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d92a0c35034ca97293166e5bd892ebcb0b542c0"
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
#line 3 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
using DensityServer.Server.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Employees")]
    public partial class EmployeeOverview : EmployeeOverviewBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 class=\"page-title\">All Employees</h1>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
 if (employees == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.AddMarkupContent(2, "<p><em>Loading...</em></p> ");
#nullable restore
#line 8 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                                }
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "  ");
            __builder.OpenElement(4, "table");
            __builder.AddAttribute(5, "class", "table");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.AddMarkupContent(7, "<thead>\r\n            <tr>\r\n                <th>First name</th>\r\n                <th>Last name</th>\r\n                <th>Employee ID</th>\r\n            </tr>\r\n        </thead>\r\n\r\n        ");
            __builder.OpenElement(8, "tbody");
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 20 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
             foreach (var employee in employees)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(10, "            ");
            __builder.OpenElement(11, "tr");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 23 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                     employee.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 24 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                     employee.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                ");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 25 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                     employee.Id

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n\r\n                ");
            __builder.OpenElement(22, "td");
            __builder.AddMarkupContent(23, "\r\n                    ");
            __builder.OpenElement(24, "a");
            __builder.AddAttribute(25, "href", 
#nullable restore
#line 28 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                               $"employeedetail/{employee.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(26, "class", "btn btn-outline-dark table-btn");
            __builder.AddMarkupContent(27, "\r\n                        ");
            __builder.AddMarkupContent(28, "<i class=\"fas fa-info-circle\">details</i>\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "               \r\n                    ");
            __builder.OpenElement(30, "a");
            __builder.AddAttribute(31, "href", 
#nullable restore
#line 31 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                               $"employeeedit/{employee.Id}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(32, "class", "btn btn-outline-dark table-btn");
            __builder.AddMarkupContent(33, "\r\n                        ");
            __builder.AddMarkupContent(34, "<i class=\"fas fa-edit\">edit</i>\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n            ");
            __builder.CloseElement();
            __builder.AddContent(37, "  ");
#nullable restore
#line 35 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                   }

#line default
#line hidden
#nullable disable
            __builder.AddContent(38, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n    ");
            __builder.CloseElement();
            __builder.AddContent(40, "  ");
#nullable restore
#line 37 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
              }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(41, "\r\n");
            __builder.OpenElement(42, "button");
            __builder.AddAttribute(43, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 39 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                   QuickAddEmployee

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(44, "class", "btn btn-dark table-btn quick-add-btn");
            __builder.AddContent(45, "Add Employee");
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n");
            __builder.OpenComponent<DensityServer.Pages.Employee.AddEmployeeDialog>(47);
            __builder.AddAttribute(48, "closeEmployeeEventCallback", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 40 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                                                                         AllEmployeesDialog_OnDialogClose

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(49, (__value) => {
#nullable restore
#line 40 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeOverview.razor"
                         AddEmployeeDialog = (DensityServer.Pages.Employee.AddEmployeeDialog)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
