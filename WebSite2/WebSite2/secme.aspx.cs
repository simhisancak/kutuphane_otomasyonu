using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Providers.Entities;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class secme : System.Web.UI.Page
{
    static NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
    string img_loc = Path.Combine("~/Images", GetIP() + "-secme.jpg");//live
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["secme"] != null)
        {
            draw_img(Session["secme"].ToString());
            Image1.ImageUrl = img_loc;
        }
        else
        {
            Num1();
        }
        if(Button2.Text.Length <= 1)
        {
            Num1();
        }
    }

    public static String GetIP()
    {
        String ip =
            HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(ip))
        {
            ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        if (ip.Length < 5)
        {
            return "local";
        }
        else
        {

            return getMd5Hash(ip);
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

    protected void draw_img(string text)
    {
        Bitmap bmp = new Bitmap(280, 50);
        Graphics g = Graphics.FromImage(bmp);
        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#1f2833");
        g.Clear(c);

        String stringToDraw = text;
        Font drawFont = new Font("Courier New", 35);
        SolidBrush brush = new SolidBrush(Color.Snow);
        PointF drawPoint = new PointF(20, 5);

        g.DrawString(stringToDraw, drawFont, brush, drawPoint);
        String stringToDraw2 = "/  / /";
        Font drawFont2 = new Font("Courier New", 45);
        SolidBrush brush2 = new SolidBrush(Color.Snow);
        PointF drawPoint2 = new PointF(17, 0);

        g.DrawString(stringToDraw, drawFont, brush, drawPoint);
        g.DrawString(stringToDraw2, drawFont2, brush2, drawPoint2);

        String path = Server.MapPath(img_loc);
        bmp.Save(path, ImageFormat.Jpeg);


        Image1.ImageUrl = img_loc;
        g.Dispose();
        bmp.Dispose();
    }





    string a;
    protected string connectionstring = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected int sayi = 0;
    public Random rastgele = new Random();
    protected void Kontrol(int ss)
    {

        Button2.Text = "";
        Button3.Text = "";
        Button4.Text = "";
        Button5.Text = "";
        Button6.Text = "";
        Button7.Text = "";
        if (ss == Convert.ToInt32(Session["secme_sıra"]))
        {
            Label5.Text = "Doğru Süre: " + ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["secme_ilk"])) - 500);

            int b = ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["secme_ilk"])) - 500);
            if (Request.Cookies["username"] != null)
            {
              
                var str_id = Convert.FromBase64String(Request.Cookies["id"].Value);
                var dec_id = MachineKey.Unprotect(str_id, "Protected");
                bool durum = false;
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {

                    sqlcon.Open();
                    string query = "SELECT speed2 FROM users WHERE id=@id";
                    SqlCommand sqlcmd1 = new SqlCommand(query, sqlcon);
                    sqlcmd1.Parameters.AddWithValue("@id", Encoding.UTF8.GetString(dec_id));
                    // SqlDataReader dr = sqlcmd1.ExecuteReader();

                    using (SqlDataReader dr = sqlcmd1.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            a = dr["speed2"].ToString();
                        }

                    }


                    if (b > 340 && b < Convert.ToInt32(a))
                    {
                        durum = true;

                    }
                    sqlcon.Close();
                }
                if (durum)
                {
                    using (SqlConnection sqlcon2 = new SqlConnection(connectionstring))
                    {
                        string update = "UPDATE users SET speed2 = @speed2 Where id = @id";
                        SqlCommand sqlcmd = new SqlCommand(update, sqlcon2);
                        sqlcmd.Parameters.AddWithValue("@id", Encoding.UTF8.GetString(dec_id));
                        sqlcmd.Parameters.AddWithValue("@speed2", b.ToString());
                        sqlcon2.Open();
                        sqlcmd.ExecuteNonQuery();
                        sqlcon2.Close();
                    }
                }



            }
        }
        else
        {
            Label5.Text = "Yanlış  Süre: " + ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["secme_ilk"])) - 400);
        }
        Num1();
    }
    protected void Num1()
    {
        Session["secme"] = "";
        sayi = rastgele.Next(100000, 999999);
        int süre = rastgele.Next(1000, 2000);
        char[] _chars = sayi.ToString().ToCharArray();
        int sayac = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k <= 1; k++)
            {

                Session["secme"] += Convert.ToString(_chars[sayac]);
                sayac = sayac + 1;
            }
            Session["secme"] += " ";
        }
        draw_img(Session["secme"].ToString());
        Image1.ImageUrl = img_loc;
        sayac = 0;

        Session["secme_ilk"] = (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
        Session["secme_sayi"] = sayi.ToString();
        Session["secme_sıra"] = rastgele.Next(1, 6);
        int sıra = Convert.ToInt32(Session["secme_sıra"]);
        if (sıra == 1)
        {
            Button2.Text = Session["secme_sayi"].ToString();
        }
        else
        {
            Button2.Text = Convert.ToString(rastgele.Next(100000, 999999));
        }


        if (sıra == 2)
        {
            Button3.Text = Session["secme_sayi"].ToString();
        }
        else
        {
            Button3.Text = Convert.ToString(rastgele.Next(100000, 999999));
        }

        if (sıra == 3)
        {
            Button4.Text = Session["secme_sayi"].ToString();
        }
        else
        {
            Button4.Text = Convert.ToString(rastgele.Next(100000, 999999));
        }

        if (sıra == 4)
        {
            Button5.Text = Session["secme_sayi"].ToString();
        }
        else
        {
            Button5.Text = Convert.ToString(rastgele.Next(100000, 999999));
        }

        if (sıra == 5)
        {
            Button6.Text = Session["secme_sayi"].ToString();
        }
        else
        {
            Button6.Text = Convert.ToString(rastgele.Next(100000, 999999));
        }


        if (sıra == 6)
        {
            Button7.Text = Session["secme_sayi"].ToString();
        }
        else
        {
            Button7.Text = Convert.ToString(rastgele.Next(100000, 999999));
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Kontrol(1);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Kontrol(2);
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Kontrol(3);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Kontrol(4);
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Kontrol(5);
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Kontrol(6);
    }






}