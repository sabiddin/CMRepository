using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CM.Web.Models;
using CM.Web.DI;
using CM.Application.Interfaces;
using StructureMap.Attributes;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net;

namespace CM.Web.Account
{
    public partial class Login : BasePageWithIoC
    {
        [SetterProperty]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                //var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                bool isPersistent = false;
                var user = UserService.GetUserByUsername(Username.Text);
                if (user!=null && user.Password ==Password.Text)
                {
                    string userData = "ApplicationSpecific data for this user.";
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                      user.Username,
                                      DateTime.Now,
                                      DateTime.Now.AddMinutes(30),
                                      isPersistent,
                                      userData,
                                      FormsAuthentication.FormsCookiePath);

                    // Encrypt the ticket.
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    // Create the cookie.
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    // Redirect back to original URL.
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(user.Username, isPersistent));

                    FormsAuthentication.SetAuthCookie(user.Username, true);

                    //FormsAuthentication.RedirectFromLoginPage(FormsAuthentication.DefaultUrl,false);                                        
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    //Response.Redirect("~/ClientMaintenance/SearchClient.aspx");
                }
                else
                {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }
                //var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);



                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //        break;
                //    case SignInStatus.LockedOut:
                //        Response.Redirect("/Account/Lockout");
                //        break;
                //    case SignInStatus.RequiresVerification:
                //        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                //                                        Request.QueryString["ReturnUrl"],
                //                                        RememberMe.Checked),
                //                          true);
                //        break;
                //    case SignInStatus.Failure:
                //    default:
                //        FailureText.Text = "Invalid login attempt";
                //        ErrorMessage.Visible = true;
                //        break;
                //}
            }
        }
    }
}