using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class rank : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.Sort("speed1", SortDirection.Ascending);
            GridView2.Sort("speed2", SortDirection.Ascending);
            GridView3.Sort("speed3", SortDirection.Ascending);
            //  GridView1.Rows.Count = 5;
        }
    }
    string command = @"SELECT TOP 10|percent speed1 FROM users WHERE condition";

    protected string connectionstring = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;




}