#pragma checksum "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43a58a0c2618584cc69c09aeb8834ccc3f03375d"
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
#line 3 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
using DensityServer.Server.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Airport/Register")]
    public partial class AddLocationDialog : AddLocationDialogBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
 if (showDialog)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "    ");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "modal fade show d-block");
            __builder.AddAttribute(3, "id", "locationModal");
            __builder.AddAttribute(4, "tabindex", "-1");
            __builder.AddMarkupContent(5, "\r\n        ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "modal-dialog");
            __builder.AddAttribute(8, "role", "document");
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "modal-content");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "modal-header");
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.AddMarkupContent(16, "<h5 class=\"modal-title\" id=\"locationAdd_Title\">Location Quick Add</h5>\r\n                    ");
            __builder.OpenElement(17, "button");
            __builder.AddAttribute(18, "type", "button");
            __builder.AddAttribute(19, "class", "close");
            __builder.AddAttribute(20, "data-dismiss", "modal");
            __builder.AddAttribute(21, "aria-label", "Close");
            __builder.AddAttribute(22, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                                                          Close

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(23, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "modal-body");
            __builder.AddMarkupContent(28, "\r\n\r\n                    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(29);
            __builder.AddAttribute(30, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 17 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                      location

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(31, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 17 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                HandleValidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(32, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(33, "\r\n\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(34);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(35, "\r\n                        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(36);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(37, "\r\n\r\n                        ");
                __builder2.OpenElement(38, "div");
                __builder2.AddAttribute(39, "class", "form-group");
                __builder2.AddMarkupContent(40, "\r\n                            ");
                __builder2.AddMarkupContent(41, "<label for=\"state\">State: </label>\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(42);
                __builder2.AddAttribute(43, "id", "state");
                __builder2.AddAttribute(44, "class", "form-control");
                __builder2.AddAttribute(45, "placeholder", "Enter state");
                __builder2.AddAttribute(46, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 24 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                                     location.state

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(47, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => location.state = __value, location.state))));
                __builder2.AddAttribute(48, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => location.state));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(49, "\r\n                            ");
                __Blazor.DensityServer.Pages.Location.AddLocationDialog.TypeInference.CreateValidationMessage_0(__builder2, 50, 51, 
#nullable restore
#line 25 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                      () => location.state

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(52, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(53, "\r\n\r\n                        ");
                __builder2.OpenElement(54, "div");
                __builder2.AddAttribute(55, "class", "form-group");
                __builder2.AddMarkupContent(56, "\r\n                            ");
                __builder2.AddMarkupContent(57, "<label for=\"city\">City name: </label>\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(58);
                __builder2.AddAttribute(59, "id", "city");
                __builder2.AddAttribute(60, "class", "form-control");
                __builder2.AddAttribute(61, "placeholder", "Enter city name");
                __builder2.AddAttribute(62, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                                    location.city

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(63, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => location.city = __value, location.city))));
                __builder2.AddAttribute(64, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => location.city));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(65, "\r\n                            ");
                __Blazor.DensityServer.Pages.Location.AddLocationDialog.TypeInference.CreateValidationMessage_1(__builder2, 66, 67, 
#nullable restore
#line 31 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                      () => location.city

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(68, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(69, "\r\n\r\n                        ");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "class", "form-group");
                __builder2.AddMarkupContent(72, "\r\n                            ");
                __builder2.AddMarkupContent(73, "<label for=\"name\">Airport Name: </label>\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(74);
                __builder2.AddAttribute(75, "id", "name");
                __builder2.AddAttribute(76, "class", "form-control");
                __builder2.AddAttribute(77, "placeholder", "Enter Airport Name");
                __builder2.AddAttribute(78, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 36 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                                    location.name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(79, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => location.name = __value, location.name))));
                __builder2.AddAttribute(80, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => location.name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(81, "\r\n                            ");
                __Blazor.DensityServer.Pages.Location.AddLocationDialog.TypeInference.CreateValidationMessage_2(__builder2, 82, 83, 
#nullable restore
#line 37 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                      () => location.name

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(84, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(85, "\r\n\r\n                        ");
                __builder2.OpenElement(86, "div");
                __builder2.AddAttribute(87, "class", "form-group");
                __builder2.AddMarkupContent(88, "\r\n                            ");
                __builder2.AddMarkupContent(89, "<label for=\"icao\">Airport Icao Code: </label>\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(90);
                __builder2.AddAttribute(91, "id", "icao");
                __builder2.AddAttribute(92, "class", "form-control");
                __builder2.AddAttribute(93, "placeholder", "Enter Airport Code");
                __builder2.AddAttribute(94, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 42 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                                    location.icao

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(95, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => location.icao = __value, location.icao))));
                __builder2.AddAttribute(96, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => location.icao));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(97, "\r\n                            ");
                __Blazor.DensityServer.Pages.Location.AddLocationDialog.TypeInference.CreateValidationMessage_3(__builder2, 98, 99, 
#nullable restore
#line 43 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                      () => location.icao

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(100, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(101, "\r\n\r\n                        ");
                __builder2.OpenElement(102, "div");
                __builder2.AddAttribute(103, "class", "form-group");
                __builder2.AddMarkupContent(104, "\r\n                            ");
                __builder2.AddMarkupContent(105, "<label for=\"lat\">Airport Latitude: </label>\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(106);
                __builder2.AddAttribute(107, "id", "lat");
                __builder2.AddAttribute(108, "class", "form-control");
                __builder2.AddAttribute(109, "placeholder", "Enter Airport Latitude");
                __builder2.AddAttribute(110, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 48 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                                   location.lat

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(111, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => location.lat = __value, location.lat))));
                __builder2.AddAttribute(112, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => location.lat));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(113, "\r\n                            ");
                __Blazor.DensityServer.Pages.Location.AddLocationDialog.TypeInference.CreateValidationMessage_4(__builder2, 114, 115, 
#nullable restore
#line 49 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                      () => location.lat

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(116, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(117, "\r\n\r\n                        ");
                __builder2.OpenElement(118, "div");
                __builder2.AddAttribute(119, "class", "form-group");
                __builder2.AddMarkupContent(120, "\r\n                            ");
                __builder2.AddMarkupContent(121, "<label for=\"lon\">Airport Longitude: </label>\r\n                            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(122);
                __builder2.AddAttribute(123, "id", "lon");
                __builder2.AddAttribute(124, "class", "form-control");
                __builder2.AddAttribute(125, "placeholder", "Enter Airport Longitude");
                __builder2.AddAttribute(126, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 54 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                                   location.lon

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(127, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => location.lon = __value, location.lon))));
                __builder2.AddAttribute(128, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => location.lon));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(129, "\r\n                            ");
                __Blazor.DensityServer.Pages.Location.AddLocationDialog.TypeInference.CreateValidationMessage_5(__builder2, 130, 131, 
#nullable restore
#line 55 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                      () => location.lon

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(132, "\r\n                        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(133, "\r\n\r\n                        ");
                __builder2.AddMarkupContent(134, "<button type=\"submit\" class=\"btn btn-primary\">Save location</button>\r\n                        ");
                __builder2.OpenElement(135, "a");
                __builder2.AddAttribute(136, "class", "btn btn-outline-primary");
                __builder2.AddAttribute(137, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 59 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
                                                                      Close

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(138, "Close");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(139, "\r\n                    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(140, "\r\n\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(142, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(143, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(144, "\r\n");
#nullable restore
#line 66 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Location\AddLocationDialog.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.DensityServer.Pages.Location.AddLocationDialog
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
