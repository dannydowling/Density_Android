#pragma checksum "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd0a175e3383d814fcca9a6c26ae311b9e22b6d3"
// <auto-generated/>
#pragma warning disable 1591
namespace DensityServer.Pages.Location
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
#line 3 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
using DensityServer.Server.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Airports")]
    public partial class LocationOverview : LocationOverviewBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1 class=\"page-title\">All Locations</h1>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
 if (locations == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.AddMarkupContent(2, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 10 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "    ");
            __builder.OpenElement(4, "table");
            __builder.AddAttribute(5, "class", "table");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.AddMarkupContent(7, "<thead>\r\n            <tr>\r\n                <th>City</th>\r\n                <th>State</th>\r\n                <th>Airport Name</th>\r\n                <th>Icao Code</th>\r\n            </tr>\r\n        </thead>\r\n\r\n        ");
            __builder.OpenElement(8, "tbody");
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 24 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
             foreach (var location in locations)
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
#line 27 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                     location.city

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                ");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 28 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                     location.state

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                ");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 29 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                     location.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                ");
            __builder.OpenElement(22, "td");
            __builder.AddContent(23, 
#nullable restore
#line 30 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                     location.icao

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n\r\n                ");
            __builder.OpenElement(25, "td");
            __builder.AddMarkupContent(26, "\r\n\r\n                    ");
            __builder.OpenElement(27, "form");
            __builder.AddAttribute(28, "action", 
#nullable restore
#line 34 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                                    $"Airport/{location.icao}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(29, "method", "get");
            __builder.AddMarkupContent(30, "\r\n                        ");
            __builder.AddMarkupContent(31, "<button type=\"submit\" name=\"details\" value=\"details\" class=\"btn btn-outline-dark table-btn\">Go</button>\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n\r\n                    ");
            __builder.OpenElement(33, "form");
            __builder.AddAttribute(34, "action", 
#nullable restore
#line 38 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                                    $"Airport/Edit/{location.icao}"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(35, "method", "post");
            __builder.AddMarkupContent(36, "\r\n                        ");
            __builder.AddMarkupContent(37, "<button type=\"submit\" name=\"edit\" value=\"edit\" class=\"btn btn-outline-dark table-btn\">Go</button>\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n");
#nullable restore
#line 45 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(41, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n");
#nullable restore
#line 48 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(44, "\r\n");
            __builder.OpenElement(45, "button");
            __builder.AddAttribute(46, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 50 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                   QuickAddLocation

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(47, "class", "btn btn-dark table-btn quick-add-btn");
            __builder.AddContent(48, "Add Location");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n\r\n");
            __builder.OpenComponent<DensityServer.Pages.Location.AddLocationDialog>(50);
            __builder.AddAttribute(51, "closeLocationEventCallback", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 53 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                             AllLocationsDialog_OnDialogClose

#line default
#line hidden
#nullable disable
            )));
            __builder.AddComponentReferenceCapture(52, (__value) => {
#nullable restore
#line 52 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\LocationOverview.razor"
                         AddLocationDialog = (DensityServer.Pages.Location.AddLocationDialog)__value;

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