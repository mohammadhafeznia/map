#pragma checksum "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea9c06ca931270e27a64ed18d449ba89721fcbc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_driver_Views_Pay_Pay), @"mvc.1.0.view", @"/Areas/driver/Views/Pay/Pay.cshtml")]
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
#line 1 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\_ViewImports.cshtml"
using map;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\_ViewImports.cshtml"
using map.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea9c06ca931270e27a64ed18d449ba89721fcbc8", @"/Areas/driver/Views/Pay/Pay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54cb28107716c40960f0e895c5fc2bb422c29a3d", @"/Areas/driver/Views/_ViewImports.cshtml")]
    public class Areas_driver_Views_Pay_Pay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""page-content-wrapper"">
  <div class=""container"">
    <!-- Checkout Wrapper-->
    <div class=""checkout-wrapper-area py-3"">
      <!-- Choose Payment Method-->
      <div class=""choose-payment-method"">
        <h6 class=""mb-3 text-center"">روش پرداخت شارژ حساب خودرا انتخاب کنید</h6>
");
#nullable restore
#line 8 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
 if (ViewBag.msg!=null)
{
    
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
         if (ViewBag.msg=="پرداخت نا موفق بوده است ")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("          <p class=\"alert alert-danger text-center\">");
#nullable restore
#line 13 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
                                               Write(ViewBag.msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 14 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
          
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
          if (ViewBag.msg=="پرداخت با موفقیت انجام شد")
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("          <p class=\"alert alert-success text-center\">");
#nullable restore
#line 18 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
                                                Write(ViewBag.msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 19 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
          
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "c:\Users\123\Desktop\taxiclon\map\map\Areas\driver\Views\Pay\Pay.cshtml"
         
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row justify-content-center g-3"">
          <!-- Single Payment Method-->
          <div class=""col-6 col-md-5"">
            <div class=""single-payment-method""><a class=""credit-card"" href=""/driver/pay/index/10000""><i
                  class=""lni lni-credit-cards""></i>
                <h6>10000 تومان</h6>
              </a></div>
          </div>
          <!-- Single Payment Method-->
          <div class=""col-6 col-md-5"">
            <div class=""single-payment-method""><a class=""bank"" href=""/driver/pay/index/20000""><i
                  class=""lni lni-credit-cards""></i>
                <h6>20000 تومان</h6>
              </a></div>
          </div>
          <!-- Single Payment Method-->
          <div class=""col-6 col-md-5"">
            <div class=""single-payment-method""><a class=""paypal"" href=""/driver/pay/index/50000""><i
                  class=""lni lni-credit-cards""></i>
                <h6>50000 تومان </h6>
              </a></div>
          </div>
          <!-- Sin");
            WriteLiteral(@"gle Payment Method-->
          <div class=""col-6 col-md-5"">
            <div class=""single-payment-method""><a class=""cash"" href=""/driver/pay/index/100000""><i
                  class=""lni lni-credit-cards""></i>
                <h6>100000 هزار تومان</h6>
              </a></div>
          </div>
 
          <div class=""card cart-amount-area"">
            <div class=""card-body d-flex align-items-center justify-content-between"">
            
              <input style=""text-align: center;"" id=""pay25""  type=""number""  required  class=""form-control""  placeholder="" مبلغ دلخواه خود را وارد نمایید"">
                          </div>
          </div>

");
            WriteLiteral(@"
          <a class=""btn btn-warning btn-lg w-100""  onclick=""sendpay();"">پراخت و شارژ حساب تاکسی</a>
        



        </div>
      </div>
    </div>
  </div>
</div>




           <script>
            function sendpay()
            {
             
             
              window.location.href=""/driver/pay/index/""+document.getElementById('pay25').value;
            }
          </script>

          <script>
    function exitaccept()
{
  window.location.href=""/driver/home/privacy"";
}
</script>
<script>
  function b(phone)
  {
    
        window.location.href=""/driver/mapclient/mapclient?phone=""+phone;
    
  }


  
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
