using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recovery2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string kod = Request.QueryString["recovery"];
        if (kod == null)
        {
            Response.Redirect("/");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
        {
            sqlcon.Open();
            string kod = Request.QueryString["recovery"];
            string query = "select * from kitap_users where  str3=@kod";

            SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);
            sqlcmd2.Parameters.AddWithValue("@kod", kod.Trim());
            SqlDataReader dr = sqlcmd2.ExecuteReader();
            string id;
            if (dr.Read())
            {
                id = dr["id"].ToString();
                sqlcon.Close();
                sıfırla(id, getMd5Hash(txtpsw.Text));
            }
            else
            {
               Label1.Text = "Hata";
            }


        }
    }
    protected string connectionstring = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    void sıfırla(string id, string psw)
    {
        using (SqlConnection sqlcon2 = new SqlConnection(connectionstring))
        {

            string update = "UPDATE kitap_users SET user_password = @psw Where id = @id";
            SqlCommand sqlcmd = new SqlCommand(update, sqlcon2);
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.Parameters.AddWithValue("@psw", psw);
            sqlcon2.Open();
            sqlcmd.ExecuteNonQuery();
            sqlcon2.Close();
        }
        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
        {
            sqlcon.Open();
            string update = "UPDATE kitap_users SET str3 = @recovery Where id = @id";
            SqlCommand sqlcmd = new SqlCommand(update, sqlcon);
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.Parameters.AddWithValue("@recovery", "");
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
              Label1.Text = "Başarıyla Değiştirildi";
        }
        
    }

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
}