using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    protected void Page_Init(object sender, EventArgs e)
    {
        // Aşağıdaki kod XSRF saldırılarına karşı korunmanıza yardımcı olur
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Tanımlama bilgisindeki Anti-XSRF belirtecini kullan
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Yeni bir Anti-XSRF belirteci oluştur ve tanımlama bilgisine kaydet
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    protected void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Anti-XSRF belirteci ayarla
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Anti-XSRF belirtecini doğrula
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Anti-XSRF belirteci doğrulanamadı.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] != null)
        {
            //HttpCookie oku = Request.Cookies["login"];
            if (Request.Cookies["username"] != null)
            {
                {

                    Label1.Text = ("Hoşgeldin: " + Request.Cookies["username"].Value);
                    top_login.Visible = false;
                    top_register.Visible = false;
                    Label1.Visible = true;
                    top_logout.Visible = true;
                }
            }
            else
            {
                top_logout.Visible = false;
                Label1.Visible = false;
                top_login.Visible = true;
                top_register.Visible = true;

            }
        }
        else
        {
            top_logout.Visible = false;
            Label1.Visible = false;
            top_login.Visible = true;
            top_register.Visible = true;
        }
        if (Request.Cookies["version"] != null)
        {
            if (Request.Cookies["version"].Value != version)
            {
                Response.Redirect("logout.aspx");
            }

        }
        if (Request.Cookies["version"] == null && Request.Cookies["username"] != null)
        {
            Response.Redirect("logout.aspx");
        }
    }
    string version = "0.1.2";
    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
    }
}