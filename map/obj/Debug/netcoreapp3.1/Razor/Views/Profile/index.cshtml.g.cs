#pragma checksum "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e51600fb555cc37ceb0f42c2a2e60c10cd541758"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_index), @"mvc.1.0.view", @"/Views/Profile/index.cshtml")]
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
#line 1 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\_ViewImports.cshtml"
using map;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\_ViewImports.cshtml"
using map.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e51600fb555cc37ceb0f42c2a2e60c10cd541758", @"/Views/Profile/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54cb28107716c40960f0e895c5fc2bb422c29a3d", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataLayer.Entites.Tbl_User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 150px;border-radius: 50%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/app/img/bg-img/9.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@" <div class=""page-content-wrapper"">
      <div class=""container"">
        <!-- Profile Wrapper-->
        <div class=""profile-wrapper-area py-3"">
          <!-- User Information-->
          <div class=""card user-info-card"">
            <div class=""card-body p-4 d-flex align-items-center"">
");
#nullable restore
#line 9 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"
               if(Model.photo!=null)
              {

#line default
#line hidden
#nullable disable
            WriteLiteral("              <div class=\"user-profile mr-3\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e51600fb555cc37ceb0f42c2a2e60c10cd5417584744", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 445, "~/fileupload/", 445, 13, true);
#nullable restore
#line 11 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"
AddHtmlAttributeValue("", 458, Model.photo, 458, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n");
#nullable restore
#line 12 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"

              }
              else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                              <div class=\"user-profile mr-3\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e51600fb555cc37ceb0f42c2a2e60c10cd5417586679", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</div>\r\n");
#nullable restore
#line 16 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"

              }

#line default
#line hidden
#nullable disable
            WriteLiteral("              <div class=\"user-info\">\r\n                <p class=\"mb-0 text-white\">تاکسی جو </p>\r\n                <h5 class=\"mb-0\">");
#nullable restore
#line 20 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"
                            Write(Model.NameFamily);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n              </div>\r\n            </div>\r\n          </div>\r\n          <!-- User Meta Data-->\r\n          <div class=\"card user-data-card\">\r\n            <div class=\"card-body\">\r\n");
            WriteLiteral(@"              <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                <div class=""title d-flex align-items-center""><i class=""lni lni-user""></i><span>نام و نام خانوادگی</span></div>
                <div class=""data-content"" >");
#nullable restore
#line 33 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"
                                      Write(Model.NameFamily);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              </div>
              <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                <div class=""title d-flex align-items-center""><i class=""lni lni-phone""></i><span>تلفن</span></div>
                <div class=""data-content"">");
#nullable restore
#line 37 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"
                                     Write(Model.phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n              </div>\r\n");
            WriteLiteral(@"              <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                <div class=""title d-flex align-items-center""><i class=""lni lni-map-marker""></i><span>آدرس:</span></div>
                <div class=""data-content"">");
#nullable restore
#line 45 "c:\Users\MEDIA MARK\Desktop\taxi64bit\map\map\Views\Profile\index.cshtml"
                                     Write(Model.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
              </div>
              <div class=""single-profile-data d-flex align-items-center justify-content-between"">
                <div class=""title d-flex align-items-center""><i class=""lni lni-star""></i><span>سفارش من</span></div>
                <div class=""data-content""><a class=""btn btn-danger btn-sm"" href=""my-order.html"">نمایش</a></div>
              </div>
            </div>
          </div>
          <!-- Edit Profile-->
          <div class=""edit-profile-btn mt-3""><a class=""btn btn-info w-100"" href=""/profile/edit""><i class=""lni lni-pencil mr-2""></i>ویرایش نمایه</a></div>
        </div>
      </div>
    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataLayer.Entites.Tbl_User> Html { get; private set; }
    }
}
#pragma warning restore 1591
