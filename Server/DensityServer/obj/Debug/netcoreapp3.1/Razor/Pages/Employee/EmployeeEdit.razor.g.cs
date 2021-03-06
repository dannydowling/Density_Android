#pragma checksum "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "190673326572594b3f854306549ccf43596c521d"
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
#line 2 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
using DensityServer.Server.Pages;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Employee/{EmployeeId}")]
    public partial class EmployeeEdit : EmployeeEditBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "section");
            __builder.AddAttribute(1, "class", "employee-edit");
            __builder.AddMarkupContent(2, "\r\n");
#nullable restore
#line 6 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
     if (!Saved)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "        ");
            __builder.OpenElement(4, "h1");
            __builder.AddAttribute(5, "class", "page-title");
            __builder.AddContent(6, "Details for ");
            __builder.AddContent(7, 
#nullable restore
#line 8 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                            employee.FirstName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(8, " ");
            __builder.AddContent(9, 
#nullable restore
#line 8 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                employee.LastName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n");
            __builder.AddContent(11, "        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(12);
            __builder.AddAttribute(13, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 10 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                          employee

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "OnValidSubmit+", 
#nullable restore
#line 10 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                     HandleValidSubmit()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(15, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 10 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                            HandleInvalidSubmit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(17, "\r\n\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(18);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(19, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(20);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(21, "\r\n\r\n            ");
                __builder2.OpenElement(22, "div");
                __builder2.AddAttribute(23, "class", "form-group row");
                __builder2.AddMarkupContent(24, "\r\n                ");
                __builder2.AddMarkupContent(25, "<label for=\"firstName\" class=\"col-sm-3\">First name: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(26);
                __builder2.AddAttribute(27, "id", "firstName");
                __builder2.AddAttribute(28, "class", "form-control col-sm-8");
                __builder2.AddAttribute(29, "placeholder", "Enter first name");
                __builder2.AddAttribute(30, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                      employee.FirstName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(31, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => employee.FirstName = __value, employee.FirstName))));
                __builder2.AddAttribute(32, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => employee.FirstName));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(33, "\r\n                ");
                __Blazor.DensityServer.Pages.Employee.EmployeeEdit.TypeInference.CreateValidationMessage_0(__builder2, 34, 35, "offset-sm-3 col-sm-8", 36, 
#nullable restore
#line 18 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                       () => employee.FirstName

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(37, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(38, "\r\n\r\n            ");
                __builder2.OpenElement(39, "div");
                __builder2.AddAttribute(40, "class", "form-group row");
                __builder2.AddMarkupContent(41, "\r\n                ");
                __builder2.AddMarkupContent(42, "<label for=\"lastName\" class=\"col-sm-3\">Last name: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(43);
                __builder2.AddAttribute(44, "id", "lastName");
                __builder2.AddAttribute(45, "class", "form-control col-sm-8");
                __builder2.AddAttribute(46, "placeholder", "Enter last name");
                __builder2.AddAttribute(47, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 23 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                     employee.LastName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(48, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => employee.LastName = __value, employee.LastName))));
                __builder2.AddAttribute(49, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => employee.LastName));
                __builder2.AddComponentReferenceCapture(50, (__value) => {
#nullable restore
#line 23 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                                                                            LastNameInputText = (Microsoft.AspNetCore.Components.Forms.InputText)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(51, "\r\n                ");
                __Blazor.DensityServer.Pages.Employee.EmployeeEdit.TypeInference.CreateValidationMessage_1(__builder2, 52, 53, "offset-sm-3 col-sm-8", 54, 
#nullable restore
#line 24 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                       () => employee.LastName

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(55, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(56, "\r\n\r\n            ");
                __builder2.OpenElement(57, "div");
                __builder2.AddAttribute(58, "class", "form-group row");
                __builder2.AddMarkupContent(59, "\r\n                ");
                __builder2.AddMarkupContent(60, "<label for=\"lastName\" class=\"col-sm-3\">Last name: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(61);
                __builder2.AddAttribute(62, "id", "password");
                __builder2.AddAttribute(63, "class", "form-control col-sm-8");
                __builder2.AddAttribute(64, "placeholder", "Enter password");
                __builder2.AddAttribute(65, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 29 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                     employee.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(66, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => employee.Password = __value, employee.Password))));
                __builder2.AddAttribute(67, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => employee.Password));
                __builder2.AddComponentReferenceCapture(68, (__value) => {
#nullable restore
#line 29 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                                                                           PasswordInputText = (Microsoft.AspNetCore.Components.Forms.InputText)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(69, "\r\n                ");
                __Blazor.DensityServer.Pages.Employee.EmployeeEdit.TypeInference.CreateValidationMessage_2(__builder2, 70, 71, "offset-sm-3 col-sm-8", 72, 
#nullable restore
#line 30 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                       () => employee.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(73, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(74, "\r\n\r\n            ");
                __builder2.OpenElement(75, "div");
                __builder2.AddAttribute(76, "class", "form-group row");
                __builder2.AddMarkupContent(77, "\r\n                ");
                __builder2.AddMarkupContent(78, "<label for=\"email\" class=\"col-sm-3\">Email: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(79);
                __builder2.AddAttribute(80, "id", "email");
                __builder2.AddAttribute(81, "class", "form-control col-sm-8");
                __builder2.AddAttribute(82, "placeholder", "Enter email");
                __builder2.AddAttribute(83, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 35 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                  employee.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(84, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => employee.Email = __value, employee.Email))));
                __builder2.AddAttribute(85, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => employee.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(86, "\r\n                ");
                __Blazor.DensityServer.Pages.Employee.EmployeeEdit.TypeInference.CreateValidationMessage_3(__builder2, 87, 88, "offset-sm-3 col-sm-8", 89, 
#nullable restore
#line 36 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                       () => employee.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(90, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(91, "\r\n\r\n            ");
                __builder2.OpenElement(92, "div");
                __builder2.AddAttribute(93, "class", "form-group row");
                __builder2.AddMarkupContent(94, "\r\n                ");
                __builder2.AddMarkupContent(95, "<label for=\"street\" class=\"col-sm-3\">Street: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(96);
                __builder2.AddAttribute(97, "id", "street");
                __builder2.AddAttribute(98, "class", "form-control col-sm-8");
                __builder2.AddAttribute(99, "placeholder", "Enter street");
                __builder2.AddAttribute(100, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 41 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                   employee.Street

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(101, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => employee.Street = __value, employee.Street))));
                __builder2.AddAttribute(102, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => employee.Street));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(103, "\r\n                ");
                __Blazor.DensityServer.Pages.Employee.EmployeeEdit.TypeInference.CreateValidationMessage_4(__builder2, 104, 105, "offset-sm-3 col-sm-8", 106, 
#nullable restore
#line 42 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                       () => employee.Street

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(107, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(108, "\r\n\r\n            ");
                __builder2.OpenElement(109, "div");
                __builder2.AddAttribute(110, "class", "form-group row");
                __builder2.AddMarkupContent(111, "\r\n                ");
                __builder2.AddMarkupContent(112, "<label for=\"city\" class=\"col-sm-3\">City: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(113);
                __builder2.AddAttribute(114, "id", "city");
                __builder2.AddAttribute(115, "class", "form-control col-sm-8");
                __builder2.AddAttribute(116, "placeholder", "Enter city");
                __builder2.AddAttribute(117, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 47 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                 employee.City

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(118, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => employee.City = __value, employee.City))));
                __builder2.AddAttribute(119, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => employee.City));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(120, "\r\n                ");
                __Blazor.DensityServer.Pages.Employee.EmployeeEdit.TypeInference.CreateValidationMessage_5(__builder2, 121, 122, "offset-sm-3 col-sm-8", 123, 
#nullable restore
#line 48 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                       () => employee.City

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(124, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(125, "\r\n\r\n            ");
                __builder2.OpenElement(126, "div");
                __builder2.AddAttribute(127, "class", "form-group row");
                __builder2.AddMarkupContent(128, "\r\n                ");
                __builder2.AddMarkupContent(129, "<label for=\"zip\" class=\"col-sm-3\">Zip code: </label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(130);
                __builder2.AddAttribute(131, "id", "zip");
                __builder2.AddAttribute(132, "class", "form-control col-sm-8");
                __builder2.AddAttribute(133, "placeholder", "Enter zip code");
                __builder2.AddAttribute(134, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                                employee.Zip

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(135, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => employee.Zip = __value, employee.Zip))));
                __builder2.AddAttribute(136, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => employee.Zip));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(137, "\r\n                ");
                __Blazor.DensityServer.Pages.Employee.EmployeeEdit.TypeInference.CreateValidationMessage_6(__builder2, 138, 139, "offset-sm-3 col-sm-8", 140, 
#nullable restore
#line 54 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                       () => employee.Zip

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(141, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(142, "\r\n\r\n            ");
                __builder2.AddMarkupContent(143, "<button type=\"submit\" class=\"btn btn-primary edit-btn\">Save employee</button>\r\n            ");
                __builder2.OpenElement(144, "a");
                __builder2.AddAttribute(145, "class", "btn btn-outline-primary edit-outline-btn");
                __builder2.AddAttribute(146, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 58 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                                           NavigateToOverview

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(147, "Cancel");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(148, "\r\n\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(149, "\r\n");
#nullable restore
#line 61 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"

    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(150, "        ");
            __builder.OpenElement(151, "div");
            __builder.AddAttribute(152, "class", "alert" + " " + (
#nullable restore
#line 65 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                           StatusClass

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(153, 
#nullable restore
#line 65 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                         Message

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(154, "\r\n        ");
            __builder.OpenElement(155, "a");
            __builder.AddAttribute(156, "class", "btn btn-outline-primary");
            __builder.AddAttribute(157, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 66 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
                                                      NavigateToOverview

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(158, "Back to overview");
            __builder.CloseElement();
            __builder.AddMarkupContent(159, "\r\n");
#nullable restore
#line 67 "C:\Users\danny\source\repos\Density_Android\Server\DensityServer\Pages\Employee\EmployeeEdit.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.DensityServer.Pages.Employee.EmployeeEdit
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_6<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
