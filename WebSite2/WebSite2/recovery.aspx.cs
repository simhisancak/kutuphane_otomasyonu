using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recovery : System.Web.UI.Page
{
    public Random rastgele = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        mail_recovery(txtmail.Text.ToString().ToLower());
    }

    protected string connectionstring = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    protected void mail_recovery(string mail)
    {

        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
        {
            sqlcon.Open();
            string query = "select * from users where  str1=@mail";

            SqlCommand sqlcmd2 = new SqlCommand(query, sqlcon);
            sqlcmd2.Parameters.AddWithValue("@mail", mail.Trim());
            SqlDataReader dr = sqlcmd2.ExecuteReader();
            string id, username, istek;
            if (dr.Read())
            {
                id = dr["id"].ToString();
                username = dr["user_name"].ToString();
                istek = getMd5Hash(rastgele.Next(100000, 999999).ToString());
                sqlcon.Close();
                update(id, username, istek);
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Mail Bulunamadı";
            }


        }
    }

    void update(string id, string username, string istek)
    {

        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
        {
            sqlcon.Open();
            string update = "UPDATE users SET str2 = @recovery Where id = @id";
            SqlCommand sqlcmd = new SqlCommand(update, sqlcon);
            sqlcmd.Parameters.AddWithValue("@id", id);
            sqlcmd.Parameters.AddWithValue("@recovery", istek);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            string link = "https://www.simhisancak.xyz/recovery2.aspx?recovery=" + istek;
            string eposta = txtmail.Text;
            string msj = "Birisi aşağıdaki hesap için parola sıfırlama talebinde bulundu:&gt;  ";
            string eposta_metin = "Kullanıcı adı:" + username + "  ";
            string hata_mesajı = "Eğer bir hata sonucu bu e-postayı aldıysanız, göz ardı edin. Hiç bir şey olmayacaktır.  ";
            string mail_text = msj + hata_mesajı + eposta_metin + "Sıfırlama Linkiniz: " + link;
            MailMessage Mesaj = new MailMessage();
            Mesaj.From = new MailAddress("info@simhisancak.xyz");// mailleri gönderen adres
            Mesaj.To.Add(eposta);// maillerin geleceği adres
            Mesaj.Subject = "Şifremi Hatırlat";
            Mesaj.IsBodyHtml = true;
            Mesaj.Body = mail_text;
            SmtpClient smtp = new SmtpClient("info@simhisancak.xyz", 587);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("info@simhisancak.xyz", "mail şifren");//kim gönderiyor?
            smtp.Host = "mail.simhisancak.xyz";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = SMTPUserInfo;
            smtp.Send(Mesaj);
            Label1.Visible = true;
            Label1.Text = "Şifre Sıfırlama İsteğiniz Mailinize Gönderildi!";
            txtmail.Text = "";
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