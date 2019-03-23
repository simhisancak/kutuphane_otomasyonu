using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class editusr : System.Web.UI.Page
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


            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                row.ToolTip = "Click to select this row.";
            }

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        update();
    }
    protected void Button2_Click(object sender, EventArgs e)
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
    protected void Button4_Click(object sender, EventArgs e)
    {
    }



    protected void update()
    {
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        try
        {

            using (SqlConnection baglanti = new SqlConnection(conString))
            {
                baglanti.Open();
                string kayit = "update kitap_users set user_name=@user_name,user_password=@user_password,str2=@str2 where id=@id";
                // müşteriler tablomuzun ilgili alanlarını değiştirecek olan güncelleme sorgusu.
                SqlCommand komut = new SqlCommand(kayit, baglanti);
                //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
                komut.Parameters.AddWithValue("@id", TextBox1.Text);
                komut.Parameters.AddWithValue("@user_name", TextBox2.Text);
                komut.Parameters.AddWithValue("@user_password", TextBox3.Text);
                komut.Parameters.AddWithValue("@str2", TextBox4.Text);

                //Parametrelerimize Form üzerinde ki kontrollerden girilen verileri aktarıyoruz.
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglanti.Close();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başarılı", "<script>alert('Başarıyla Güncelleme Yapıldı');</script>");
                Response.Redirect("/editusr");
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Lütfen Tekrar Deneyin');</script>");
        }
    }




}