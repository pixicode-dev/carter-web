#pragma checksum "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a18b46bc23e9b5ff38a749b455141e766839d0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutAdminHeader), @"mvc.1.0.view", @"/Views/Shared/_LayoutAdminHeader.cshtml")]
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
#line 1 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\_ViewImports.cshtml"
using CARTER.App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\_ViewImports.cshtml"
using CARTER.App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
using CARTER.App.Utilities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
using CARTER.Models.System.Users;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a18b46bc23e9b5ff38a749b455141e766839d0c", @"/Views/Shared/_LayoutAdminHeader.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25031e4d01e39a91224f5c9a2ab996c40b2229e0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LayoutAdminHeader : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
  

    var loginResponse = httpContextAccessor.HttpContext.Session.Get<LoginResponse>("LogOn");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- app-Header -->
<div class=""app-header header sticky"">
    <div class=""container-fluid main-container"">
        <div class=""d-flex align-items-center"">
            <a aria-label=""Hide Sidebar"" class=""app-sidebar__toggle"" data-bs-toggle=""sidebar"" href=""javascript:void(0);""></a>
            <div class=""responsive-logo"">
                <a href=""index.html"" class=""header-logo"">
                    <img src=""../assets/images/brand/carter/logo-3.png"" class=""mobile-logo logo-1"" alt=""logo"">
                    <img src=""../assets/images/brand/carter/logo.png"" class=""mobile-logo dark-logo-1"" alt=""logo"">
                </a>
            </div>
            <!-- sidebar-toggle-->
            <a class=""logo-horizontal "" href=""index.html"">
                <img src=""../assets/images/brand/carter/logo.png"" class=""header-brand-img desktop-logo"" alt=""logo"">
                <img src=""../assets/images/brand/carter/logo-3.png"" class=""header-brand-img light-logo1""
                     alt=""logo"">
            <");
            WriteLiteral("/a>\r\n            <!-- LOGO -->\r\n");
            WriteLiteral(@"            <div class=""d-flex order-lg-2 ms-auto header-right-icons"">
                <!-- SEARCH -->
                <button class=""navbar-toggler navresponsive-toggler d-lg-none ms-auto"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#navbarSupportedContent-4"" aria-controls=""navbarSupportedContent-4"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                    <span class=""navbar-toggler-icon fe fe-more-vertical text-dark""></span>
                </button>
                <div class=""navbar navbar-collapse responsive-navbar p-0"">
                    <div class=""collapse navbar-collapse"" id=""navbarSupportedContent-4"">
                        <div class=""d-flex order-lg-2"">
                            <div class=""dropdown d-block d-lg-none"">
                                <a href=""javascript:void(0);"" class=""nav-link icon"" data-bs-toggle=""dropdown"">
                                    <i class=""fe fe-search""></i>
                                </a>
                        ");
            WriteLiteral(@"        <div class=""dropdown-menu header-search dropdown-menu-start"">
                                    <div class=""input-group w-100 p-2"">
                                        <input type=""text"" class=""form-control"" placeholder=""Search...."">
                                        <div class=""input-group-text btn btn-primary"">
                                            <i class=""fa fa-search"" aria-hidden=""true""></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""dropdown d-md-flex"">
                                <a class=""nav-link icon theme-layout nav-link-bg layout-setting"">
                                    <span class=""dark-layout""><i class=""fe fe-moon""></i></span>
                                    <span class=""light-layout""><i class=""fe fe-sun""></i></span>
                                </a>
                            </d");
            WriteLiteral(@"iv>
                            <!-- Theme-Layout -->
                            <div class=""dropdown d-md-flex"">
                                <a class=""nav-link icon full-screen-link nav-link-bg"">
                                    <i class=""fe fe-minimize fullscreen-button"" id=""myvideo""></i>
                                </a>
                            </div>
                            <!-- FULL-SCREEN -->
                            <div class=""dropdown d-md-flex notifications"">
                                <a class=""nav-link icon"" data-bs-toggle=""dropdown"">
                                    <i class=""fe fe-bell""></i><span class="" pulse""></span>
                                </a>
                                <div class=""dropdown-menu dropdown-menu-end dropdown-menu-arrow "">
                                    <div class=""drop-heading border-bottom"">
                                        <div class=""d-flex"">
                                            <h6 class=""mt-1 mb-0");
            WriteLiteral(@" fs-16 fw-semibold"">You have Notification</h6>
                                            <div class=""ms-auto"">
                                                <span class=""badge bg-success rounded-pill"">3</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""notifications-menu"">
                                        <a class=""dropdown-item d-flex"" href=""chat.html"">
                                            <div class=""me-3 notifyimg  bg-primary-gradient brround box-shadow-primary"">
                                                <i class=""fe fe-message-square""></i>
                                            </div>
                                            <div class=""mt-1 wd-80p"">
                                                <h5 class=""notification-label mb-1"">New review received</h5>
                                                <span class=""");
            WriteLiteral(@"notification-subtext"">2 hours ago</span>
                                            </div>
                                        </a>
                                        <a class=""dropdown-item d-flex"" href=""chat.html"">
                                            <div class=""me-3 notifyimg  bg-secondary-gradient brround box-shadow-primary"">
                                                <i class=""fe fe-mail""></i>
                                            </div>
                                            <div class=""mt-1 wd-80p"">
                                                <h5 class=""notification-label mb-1"">New Mails Received</h5>
                                                <span class=""notification-subtext"">1 week ago</span>
                                            </div>
                                        </a>
                                        <a class=""dropdown-item d-flex"" href=""cart.html"">
                                            <div class=""me-3 notifyimg");
            WriteLiteral(@"  bg-success-gradient brround box-shadow-primary"">
                                                <i class=""fe fe-shopping-cart""></i>
                                            </div>
                                            <div class=""mt-1 wd-80p"">
                                                <h5 class=""notification-label mb-1"">New Order Received</h5>
                                                <span class=""notification-subtext"">1 day ago</span>
                                            </div>
                                        </a>
                                    </div>
                                    <div class=""dropdown-divider m-0""></div>
                                    <a href=""javascript:void(0);"" class=""dropdown-item text-center p-3 text-muted"">View all Notification</a>
                                </div>
                            </div>
                            <!-- NOTIFICATIONS -->
                            <div class=""dropdown d-md-flex messa");
            WriteLiteral(@"ge"">
                                <a class=""nav-link icon text-center"" data-bs-toggle=""dropdown"">
                                    <i class=""fe fe-message-square""></i><span class="" pulse-danger""></span>
                                </a>
                                <div class=""dropdown-menu dropdown-menu-end dropdown-menu-arrow"">
                                    <div class=""drop-heading border-bottom"">
                                        <div class=""d-flex"">
                                            <h6 class=""mt-1 mb-0 fs-16 fw-semibold"">You have Messages</h6>
                                            <div class=""ms-auto"">
                                                <span class=""badge bg-danger rounded-pill"">4</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=""message-menu"">
                                        <a class=""d");
            WriteLiteral(@"ropdown-item d-flex"" href=""chat.html"">
                                            <span class=""avatar avatar-md brround me-3 align-self-center cover-image"" data-bs-image-src=""../assets/images/users/1.jpg""></span>
                                            <div class=""wd-90p"">
                                                <div class=""d-flex"">
                                                    <h5 class=""mb-1"">Madeleine</h5>
                                                    <small class=""text-muted ms-auto text-end"">
                                                        3 hours ago
                                                    </small>
                                                </div>
                                                <span>Hey! there I' am available....</span>
                                            </div>
                                        </a>
                                        <a class=""dropdown-item d-flex"" href=""chat.html"">
                     ");
            WriteLiteral(@"                       <span class=""avatar avatar-md brround me-3 align-self-center cover-image"" data-bs-image-src=""../assets/images/users/12.jpg""></span>
                                            <div class=""wd-90p"">
                                                <div class=""d-flex"">
                                                    <h5 class=""mb-1"">Anthony</h5>
                                                    <small class=""text-muted ms-auto text-end"">
                                                        5 hour ago
                                                    </small>
                                                </div>
                                                <span>New product Launching...</span>
                                            </div>
                                        </a>
                                        <a class=""dropdown-item d-flex"" href=""chat.html"">
                                            <span class=""avatar avatar-md brround me-3 ali");
            WriteLiteral(@"gn-self-center cover-image"" data-bs-image-src=""../assets/images/users/4.jpg""></span>
                                            <div class=""wd-90p"">
                                                <div class=""d-flex"">
                                                    <h5 class=""mb-1"">Olivia</h5>
                                                    <small class=""text-muted ms-auto text-end"">
                                                        45 mintues ago
                                                    </small>
                                                </div>
                                                <span>New Schedule Realease......</span>
                                            </div>
                                        </a>
                                        <a class=""dropdown-item d-flex"" href=""chat.html"">
                                            <span class=""avatar avatar-md brround me-3 align-self-center cover-image"" data-bs-image-src=""../assets/images/");
            WriteLiteral(@"users/15.jpg""></span>
                                            <div class=""wd-90p"">
                                                <div class=""d-flex"">
                                                    <h5 class=""mb-1"">Sanderson</h5>
                                                    <small class=""text-muted ms-auto text-end"">
                                                        2 days ago
                                                    </small>
                                                </div>
                                                <span>New Schedule Realease......</span>
                                            </div>
                                        </a>
                                    </div>
                                    <div class=""dropdown-divider m-0""></div>
                                    <a href=""javascript:void(0);"" class=""dropdown-item text-center p-3 text-muted"">See all Messages</a>
                                </div>
          ");
            WriteLiteral(@"                  </div>
                            <!-- MESSAGE-BOX -->
                            <div class=""dropdown d-md-flex profile-1"">
                                <a href=""javascript:void(0);"" data-bs-toggle=""dropdown"" class=""nav-link leading-none d-flex px-1"">
                                    <span>
                                        <img");
            BeginWriteAttribute("src", " src=\"", 13217, "\"", 13337, 1);
#nullable restore
#line 182 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
WriteAttributeValue("", 13223, string.IsNullOrEmpty(loginResponse.AppUser.Avatar)? "../assets/images/users/8.jpg":loginResponse.AppUser.Avatar, 13223, 114, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"profile-user\" class=\"nav-link icon profile-user brround cover-image\" style=\"padding: 0px !important;\" />\r\n");
            WriteLiteral(@"                                    </span>
                                </a>
                                <div class=""dropdown-menu dropdown-menu-end dropdown-menu-arrow"">
                                    <div class=""drop-heading"">
                                        <div class=""text-center"">
                                            <h5 class=""text-dark mb-0"">");
#nullable restore
#line 189 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
                                                                  Write(loginResponse.AppUser.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 189 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
                                                                                                   Write(loginResponse.AppUser.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                            <small class=\"text-muted\">");
#nullable restore
#line 190 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
                                                                 Write(loginResponse.AppUser.Role);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                                        </div>
                                    </div>
                                    <div class=""dropdown-divider m-0""></div>
                                    <a class=""dropdown-item"" href=""profile.html"">
                                        <i class=""dropdown-icon fe fe-user""></i> Profile
                                    </a>
                                    <a class=""dropdown-item"" href=""email.html"">
                                        <i class=""dropdown-icon fe fe-mail""></i> Inbox
                                        <span class=""badge bg-secondary float-end"">3</span>
                                    </a>
                                    <a class=""dropdown-item"" href=""emailservices.html"">
                                        <i class=""dropdown-icon fe fe-settings""></i> Settings
                                    </a>
                                    <a class=""dropdown-item"" href=""faq.html"">
                    ");
            WriteLiteral("                    <i class=\"dropdown-icon fe fe-alert-triangle\"></i> Need help?\r\n                                    </a>\r\n                                    <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 15451, "\"", 15487, 1);
#nullable restore
#line 207 "C:\Users\phung\source\repos\CARTERWEB\CARTER.App\Views\Shared\_LayoutAdminHeader.cshtml"
WriteAttributeValue("", 15458, Url.Action("Logout","Login"), 15458, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                        <i class=""dropdown-icon fe fe-alert-circle""></i> Sign out
                                    </a>
                                </div>
                            </div>
                            <div class=""dropdown d-md-flex header-settings"">
                                <a href=""javascript:void(0);"" class=""nav-link icon "" data-bs-toggle=""sidebar-right"" data-target="".sidebar-right"">
                                    <i class=""fe fe-menu""></i>
                                </a>
                            </div>
                            <!-- SIDE-MENU -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- /app-Header -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor httpContextAccessor { get; private set; }
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
