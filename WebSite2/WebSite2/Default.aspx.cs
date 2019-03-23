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

public partial class _Default : Page
{
    static NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

    string img_loc = Path.Combine("~/Images", GetIP() + "-yazma.jpg");//live
    int sayi;
    public Random rastgele = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["text"] != null)
        {
            Image1.ImageUrl = img_loc;
            draw_img(Session["text"].ToString());
        }
        else
        {
            mod = 3;
            num();

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
    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {
        try
        {


            if (TextBox1.Text == Session["sayi"].ToString())
            {
                Label2.Text = "Doğru Süre: " + ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["ilk"])) - 650);
                int b = ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["ilk"])) - 650);
                if (Request.Cookies["username"] != null)
                {
                   
                    var str_id = Convert.FromBase64String(Request.Cookies["id"].Value);
                    var dec_id = MachineKey.Unprotect(str_id, "Protected");
                    bool durum = false;
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {

                        sqlcon.Open();
                        string query = "SELECT speed1 FROM users WHERE id=@id";
                        SqlCommand sqlcmd1 = new SqlCommand(query, sqlcon);

                        sqlcmd1.Parameters.AddWithValue("@id", Encoding.UTF8.GetString(dec_id));
                        // SqlDataReader dr = sqlcmd1.ExecuteReader();

                        using (SqlDataReader dr = sqlcmd1.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                a = dr["speed1"].ToString();
                            }

                        }


                        if (b > 300 && b < Convert.ToInt32(a))
                        {
                            durum = true;

                        }
                        sqlcon.Close();
                    }
                    if (durum)
                    {
                        using (SqlConnection sqlcon2 = new SqlConnection(connectionstring))
                        {

                            string update = "UPDATE users SET speed1 = @speed1 Where id = @id";
                            SqlCommand sqlcmd = new SqlCommand(update, sqlcon2);
                            sqlcmd.Parameters.AddWithValue("@id", Encoding.UTF8.GetString(dec_id));
                            sqlcmd.Parameters.AddWithValue("@speed1", b.ToString());
                            sqlcon2.Open();
                            sqlcmd.ExecuteNonQuery();
                            sqlcon2.Close();
                        }
                    }



                }
            }
            else
            {
                Label2.Text = "Yanlış  Süre: " + ((((DateTime.Now.Second * 1000) + DateTime.Now.Millisecond) - Convert.ToInt32(Session["ilk"])) - 500);
            }

            num();

        }
        catch
        {

        }
    }


    protected void num()
    {
        Session["ilk"] = null;
        TextBox1.Focus();
        // Label1.Text = "";
        Session["text"] = "";
        TextBox1.Text = "";
        sayi = rastgele.Next(100000, 999999);
        int süre = rastgele.Next(1000, 2000);
        char[] _chars = sayi.ToString().ToCharArray();
        int sayac = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k <= 1; k++)
            {
                Session["text"] += Convert.ToString(_chars[sayac]);
                sayac = sayac + 1;
            }
            Session["text"] += " ";
        }

        sayac = 0;

        Image1.ImageUrl = img_loc;
        draw_img(Session["text"].ToString());
        Session["ilk"] = (DateTime.Now.Second * 1000) + DateTime.Now.Millisecond;
        Session["sayi"] = sayi.ToString();
    }
    int mod = 0;
    protected void Button1_Click(object sender, EventArgs e)
    {
        mod = 3;
        num();
    }
}