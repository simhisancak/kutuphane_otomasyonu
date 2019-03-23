using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class matyazma : System.Web.UI.Page
{
    int sayi;
    public Random rastgele = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["text-mat"] != null)
        {
            Label1.Text = Session["text-mat"].ToString();
        }
        else{
            mod = 3;
            num();
        }

    }
    string a;
    protected string connectionstring = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {
        try
        {


            if (TextBox1.Text == Session["sonuc"].ToString())
            {
                Label2.Text = "Doğru Süre: " + ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["ilk-mat"])) - 500);
                int b = ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["ilk-mat"])) - 500);
                if (Request.Cookies["username"] != null)
                {
                  
                    var str_id = Convert.FromBase64String(Request.Cookies["id"].Value);
                    var dec_id = MachineKey.Unprotect(str_id, "Protected");
                    bool durum = false;
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        sqlcon.Open();
                        string query = "SELECT speed3 FROM users WHERE id=@id";
                        SqlCommand sqlcmd1 = new SqlCommand(query, sqlcon);
                        sqlcmd1.Parameters.AddWithValue("@id", Encoding.UTF8.GetString(dec_id));

                        using (SqlDataReader dr = sqlcmd1.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                a = dr["speed3"].ToString();
                            }

                        }


                        if (b > 100 && b < Convert.ToInt32(a))
                        {
                            durum = true;

                        }
                        sqlcon.Close();
                    }
                    if (durum)
                    {
                        using (SqlConnection sqlcon2 = new SqlConnection(connectionstring))
                        {
                            
                            string update = "UPDATE users SET speed3 = @speed3 Where id = @id";
                            SqlCommand sqlcmd = new SqlCommand(update, sqlcon2);
                            sqlcmd.Parameters.AddWithValue("@id", Encoding.UTF8.GetString(dec_id));
                            sqlcmd.Parameters.AddWithValue("@speed3", b.ToString());
                            sqlcon2.Open();
                            sqlcmd.ExecuteNonQuery();
                            sqlcon2.Close();
                        }
                    }



                }

            }
            else
            {
                Label2.Text = "Yanlış  Süre: " + ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["ilk-mat"])) - 500);
            }

            num();

        }
        catch
        {

        }
    }


    protected void num()
    {
        Session["ilk-mat"] = null;
        TextBox1.Focus();
        Session["text-mat"] = "";
        TextBox1.Text = "";
        Label1.Visible = false;
        sayi = rastgele.Next(100000, 999999);
        int süre = rastgele.Next(1000, 2000);
        char[] _chars = sayi.ToString().ToCharArray();

        int sayi1 = rastgele.Next(1, 4);
        int sayi2 = rastgele.Next(1, 4);
        int sayi3 = rastgele.Next(1, 4);
        int sayi4 = rastgele.Next(1, 4);
        int sayi5 = rastgele.Next(1, 4);
        int sayi6 = rastgele.Next(1, 4);
        int sayi7 = rastgele.Next(1, 4);
        int sayi8 = rastgele.Next(1, 4);
        int ss = rastgele.Next(0, 10);
        int sss = rastgele.Next(0, 10);
        int ssss = rastgele.Next(0, 10);
        int sssss = rastgele.Next(0, 10);
        string ara1, ara2, ara3, ara4;

        if (ss < 4)
        {
            ara1 = Convert.ToString(sayi1) + "*" + Convert.ToString(sayi2);
            Session["sonuc1"] = sayi1 * sayi2;
        }
        else if (ss >= 4 && ss <= 6)
        {
            if (sayi1 - sayi2 >= 0)
            {
                Session["sonuc1"] = sayi1 - sayi2;
            }
            else
            {
                sayi1 = 4;
                Session["sonuc1"] = sayi1 - sayi2;
            }

            ara1 = Convert.ToString(sayi1) + "-" + Convert.ToString(sayi2);
        }
        else
        {
            ara1 = Convert.ToString(sayi1) + "+" + Convert.ToString(sayi2);
            Session["sonuc1"] = sayi1 + sayi2;

        }

        //-----------------------------------------------------------------------


        if (sss < 4)
        {
            ara2 = Convert.ToString(sayi3) + "*" + Convert.ToString(sayi4);
            Session["sonuc2"] = sayi3 * sayi4;
        }
        else if (sss >= 4 && sss <= 6)
        {
            if (sayi3 - sayi4 >= 0)
            {
                Session["sonuc2"] = sayi3 - sayi4;
            }
            else
            {
                sayi1 = 4;
                Session["sonuc2"] = sayi3 - sayi4;
            }

            ara2 = Convert.ToString(sayi3) + "-" + Convert.ToString(sayi4);
        }
        else
        {
            ara2 = Convert.ToString(sayi3) + "+" + Convert.ToString(sayi4);
            Session["sonuc2"] = sayi3 + sayi4;

        }
        //-----------------------------------------------------------------------

        if (ssss < 4)
        {
            ara3 = Convert.ToString(sayi5) + "*" + Convert.ToString(sayi6);
            Session["sonuc3"] = sayi5 * sayi6;
        }
        else if (ssss >= 4 && ssss <= 6)
        {
            if (sayi5 - sayi2 >= 0)
            {
                Session["sonuc3"] = sayi5 - sayi6;
            }
            else
            {
                sayi1 = 4;
                Session["sonuc3"] = sayi5 - sayi6;
            }

            ara3 = Convert.ToString(sayi5) + "-" + Convert.ToString(sayi6);
        }
        else
        {
            ara3 = Convert.ToString(sayi5) + "+" + Convert.ToString(sayi6);
            Session["sonuc3"] = sayi5 + sayi6;

        }


        //-----------------------------------------------------------------------


        if (sssss < 4)
        {
            ara4 = Convert.ToString(sayi7) + "*" + Convert.ToString(sayi8);
            Session["sonuc4"] = sayi7 * sayi8;
        }
        else if (ss >= 4 && ss <= 6)
        {
            if (sayi7 - sayi8 >= 0)
            {
                Session["sonuc4"] = sayi7 - sayi8;
            }
            else
            {
                sayi1 = 4;
                Session["sonuc4"] = sayi7 - sayi8;
            }

            ara4 = Convert.ToString(sayi7) + "-" + Convert.ToString(sayi8);
        }
        else
        {
            ara4 = Convert.ToString(sayi7) + "+" + Convert.ToString(sayi8);
            Session["sonuc4"] = sayi7 + sayi8;

        }


        Session["sonuc"] = Convert.ToString(Session["sonuc1"]) + Convert.ToString(Session["sonuc2"]) + Convert.ToString(Session["sonuc3"]) + Convert.ToString(Session["sonuc4"]);
        Session["text-mat"] = ara1 + "     " + ara2 + "     " + ara3 + "     " + ara4;
        Label1.Visible = true;
        if (Session["text-mat"] != null)
        {
            Label1.Text = Session["text-mat"].ToString();
        }
        Session["ilk-mat"] = (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
    }
    int mod = 0;
    protected void Button1_Click1(object sender, EventArgs e)
    {
        mod = 3;
        num();
    }
}