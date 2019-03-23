using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
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

        if (txtuser.Text.Length > 0 && txtpsw.Text.Length > 0)
        {
            check(txtuser.Text.ToString(), getMd5Hash(txtpsw.Text), txtmail.Text.ToString().ToLower());
        }

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

    protected void check(string usrname, string usrpsw , string usrmail)
    {
        try
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "select * from kitap_users where user_name=@username";

                SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);
                sqlcmd2.Parameters.AddWithValue("@username", usrname.Trim());
                SqlDataReader dr = sqlcmd2.ExecuteReader();
                if (dr.Read())
                {
                    Label1.Text = "Kullanıcı Adı Mevcut";
                    Label2.Text = "";
                    txtpsw.Text = "";
                    txtmail.Text = "";
                }
                else
                {
                    user_register(usrname, usrpsw, usrmail);
                }
                sqlcon.Close();
            }
        }
        catch
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
        }
    }

    protected void user_register(string usrname, string usrpsw , string usrmail)
    {
        try
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("kitap_UserAdd", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@user_name", usrname.Trim());
                sqlcmd.Parameters.AddWithValue("@user_password", usrpsw.Trim());
                sqlcmd.Parameters.AddWithValue("@str1", usrmail.Trim());
                sqlcmd.Parameters.AddWithValue("@str2", "1");

                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                Label1.Text = "";
                Label2.Text = "Başarıyla Kayıt Oldunuz";
                txtuser.Text = "";
                txtpsw.Text = "";
                txtmail.Text = "";
            }
        }
        catch
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
        }


    }

    protected void txtuser_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtpsw_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtmail_TextChanged(object sender, EventArgs e)
    {

    }


}