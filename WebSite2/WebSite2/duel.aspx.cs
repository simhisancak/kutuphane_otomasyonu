using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class duel : System.Web.UI.Page
{
    public Random rastgele = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] == null)
        {
            Response.Redirect("/");
        }
    }

    protected void counter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int counter_int = counter.SelectedIndex + 1;
        check(counter_int, Request.Cookies["username"].Value.ToString(), Request.Cookies["id"].Value.ToString());

    }
    protected string connectionstring =  WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    private string istek;
    protected void check(int counter_int, string user_name, string id)
    {
        bool durum = true;
        while (durum)
        {
            istek = getMd5Hash(rastgele.Next(100000, 999999).ToString());
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                string query = "select * from duel where str2=@istek ";

                SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);
                sqlcmd2.Parameters.AddWithValue("@istek", istek.Trim());
                SqlDataReader dr = sqlcmd2.ExecuteReader();
                if (dr.Read())
                {
                    durum = true;
                }
                else
                {
                    durum = false;
                    register(counter_int, user_name, id, istek);
                }
                sqlcon.Close();
            }
        }
    }

    protected void register(int counter_int, string user_name, string id, string istek)
    {
        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
        {
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("UserAdd_duel", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@user_name", user_name.Trim());
            sqlcmd.Parameters.AddWithValue("@user_name2", "");
            sqlcmd.Parameters.AddWithValue("@user1_counter1", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter2", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter3", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter4", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter5", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter6", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter7", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter8", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter9", 0);
            sqlcmd.Parameters.AddWithValue("@user1_counter10", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter1", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter2", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter3", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter4", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter5", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter6", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter7", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter8", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter9", 0);
            sqlcmd.Parameters.AddWithValue("@user2_counter10", 0);
            sqlcmd.Parameters.AddWithValue("@user1_id", "");
            sqlcmd.Parameters.AddWithValue("@user2_id", "");
            sqlcmd.Parameters.AddWithValue("@str1", counter_int.ToString());
            sqlcmd.Parameters.AddWithValue("@str2", istek.Trim());
            sqlcmd.Parameters.AddWithValue("@str3", "");
            sqlcmd.Parameters.AddWithValue("@str4", "");
            sqlcmd.Parameters.AddWithValue("@str5", "");
            sqlcmd.Parameters.AddWithValue("@str6", "");
            sqlcmd.Parameters.AddWithValue("@str7", "");
            sqlcmd.Parameters.AddWithValue("@str8", "");

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            Label2.Text = "https://www.simhisancak.xyz/duel2.aspx?duel_id=" + istek;
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