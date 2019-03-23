using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] != null)
        {
                Response.Redirect("/");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        login(txtuser.Text.ToString(), getMd5Hash(txtpsw.Text));
    }
    protected string connectionstring = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


    public static string getMd5Hash(string input)
    {
        MD5 md5Hasher = MD5.Create();
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }

    protected void login(string usrname, string usrpsw)
    {
        try
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                string query = "select * from kitap_users where user_name=@username and user_password=@pass";
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);

                sqlcmd.Parameters.AddWithValue("@username", usrname.Trim());
                sqlcmd.Parameters.AddWithValue("@pass", usrpsw.Trim());
                SqlDataReader dr = sqlcmd.ExecuteReader();
                if (dr.Read())
                {
                    var txt_id = Encoding.UTF8.GetBytes(dr["id"].ToString());
                    var enc_id = Convert.ToBase64String(MachineKey.Protect(txt_id, "Protected"));

                    var txt_psw = Encoding.UTF8.GetBytes(usrpsw);
                    var enc_psw = Convert.ToBase64String(MachineKey.Protect(txt_psw, "Protected"));
                    Response.Cookies["id"].Value = enc_id.ToString();
                    Response.Cookies["username"].Value = usrname;
                    Response.Cookies["password"].Value = enc_psw.ToString();
                    Response.Cookies["version"].Value = "0.1.2";
                    Response.Cookies["role"].Value = dr["str2"].ToString();

                    Response.Cookies["id"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["username"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["version"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["role"].Expires = DateTime.Now.AddDays(7);
                    // Response.Cookies.Add(user);
                    Label1.Text = "";
                    txtpsw.Text = "";
                    txtuser.Text = "";
                    Response.Redirect("/");

                }
                else
                {
                    txtpsw.Text = "";
                    Label1.Text = "Kullanıcı Adı Veya Şifre Hatalı";
                }
                sqlcon.Close();

            }
        }
        catch
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
        }

    }

    protected void recovery_Click(object sender, EventArgs e)
    {
        Response.Redirect("/recovery.aspx");
    }
}