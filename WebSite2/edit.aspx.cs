using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["username"] == null)
        {
            Response.Redirect("/");
        }
        else
        {
            if (Request.Cookies["role"].Value != "2")
            {
                Response.Redirect("/");
            }
        }
        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        update();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text.Length > 0)
        {
            try
            {
                GridView1.DataSourceID = "SqlDataSource2";
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
            }
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length > 0)
        {
            try
            {

                GridView1.DataSourceID = "SqlDataSource3";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başarılı", "<script>alert('Başarıyla Silme İşlemi Yapıldı Sayfayı Yenileyin');</script>");
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
            }
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowIndex == GridView1.SelectedIndex)
            {
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                row.ToolTip = string.Empty;

                TextBox1.Text = row.Cells[1].Text;
                TextBox2.Text = row.Cells[2].Text;
                TextBox3.Text = row.Cells[3].Text;
                TextBox4.Text = row.Cells[4].Text;
                TextBox5.Text = row.Cells[5].Text;
                TextBox6.Text = row.Cells[6].Text;
                TextBox7.Text = row.Cells[7].Text;
                TextBox8.Text = row.Cells[8].Text;
                TextBox9.Text = row.Cells[9].Text;


            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                row.ToolTip = "Click to select this row.";
            }
        }
    }

    protected void update()
    {
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {

            using (SqlConnection baglanti = new SqlConnection(conString))
            {
                baglanti.Open();
                string kayit = "update kitap_db set kitap_ad=@kitap_ad,kitap_yazar=@kitap_yazar,tarih1=@tarih1,int1=@int1,tarih2=@tarih2, tarih3=@tarih3, str4=@str4 , str5=@str5 where id=@id";
                // müşteriler tablomuzun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@id", TextBox1.Text);
                komut.Parameters.AddWithValue("@kitap_ad", TextBox2.Text);
                komut.Parameters.AddWithValue("@kitap_yazar", TextBox3.Text);
                komut.Parameters.AddWithValue("@str5", TextBox4.Text);
                komut.Parameters.AddWithValue("@tarih1", TextBox5.Text);
                komut.Parameters.AddWithValue("@int1", TextBox6.Text);
                komut.Parameters.AddWithValue("@tarih2", TextBox7.Text);
                komut.Parameters.AddWithValue("@tarih3", TextBox8.Text);
                komut.Parameters.AddWithValue("@str4", TextBox9.Text);

                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglanti.Close();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başarılı", "<script>alert('Başarıyla Güncelleme Yapıldı');</script>");
                Response.Redirect("/edit");
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
        }
    }

    protected void kitap_ekle()
    {
        try
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("kitap_kitapadd", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@kitap_ad", TextBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@kitap_yazar", TextBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@str5", TextBox4.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@tarih1", TextBox5.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@int1", TextBox6.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@tarih2", TextBox7.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@tarih3", TextBox8.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@str4", TextBox9.Text.Trim());

                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Başarıyla Eklendi');</script>");
                Response.Redirect("/edit");
            }
        }
        catch(Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
           
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        kitap_ekle();
    }
}