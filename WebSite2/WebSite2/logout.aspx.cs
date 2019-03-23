using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] != null)
        {
            Response.Cookies["speed1"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed2"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed3"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed4"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed5"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed6"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed7"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed8"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["speed9"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["id"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["version"].Expires = DateTime.Now.AddDays(-1);
            
        }
        Response.Redirect("/");
    }
}