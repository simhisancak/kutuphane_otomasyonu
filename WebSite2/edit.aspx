<%@ Page Title="Kitap Düzenle" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="edit" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="edit_btn">
        <asp:Button CssClass="btn2" ID="Button2" runat="server" OnClick="Button2_Click" Text="Ara" />
    </div>
    <div class="edit_lbl">
        <asp:Label CssClass="lbl1" ID="Label2" runat="server" Text="Numara →"></asp:Label>
        <asp:Label CssClass="lbl2" ID="Label1" runat="server" Text="Kitap Adı →"></asp:Label>
        <asp:Label CssClass="lbl3" ID="Label3" runat="server" Text="Kitap Yazarı →"></asp:Label>
        <asp:Label CssClass="lbl4" ID="Label4" runat="server" Text="Yayın Evi →"></asp:Label>
        <asp:Label CssClass="lbl5" ID="Label5" runat="server" Text="Kayıt Tarihi →"></asp:Label>
        <asp:Label CssClass="lbl6" ID="Label6" runat="server" Text="Güncel Adet →"></asp:Label>
        <asp:Label CssClass="lbl7" ID="Label7" runat="server" Text="Giriş Tarihi →"></asp:Label>
        <asp:Label CssClass="lbl8" ID="Label8" runat="server" Text="Çıkış Tarihi →"></asp:Label>
        <asp:Label CssClass="lbl9" ID="Label9" runat="server" Text="Alan Kişi →"></asp:Label>
    </div>

    <div class="edit">
        <asp:TextBox CssClass="txt1" ID="TextBox1" autocomplete="off" runat="server" placeholder="Numara" ReadOnly="True"></asp:TextBox>
        <asp:TextBox CssClass="txt2" ID="TextBox2" autocomplete="off" runat="server" placeholder="Kitap Adı"></asp:TextBox>
        <asp:TextBox CssClass="txt3" ID="TextBox3" autocomplete="off" runat="server" placeholder="Kitap Yazarı"></asp:TextBox>
        <asp:TextBox CssClass="txt4" ID="TextBox4" autocomplete="off" runat="server" placeholder="Yayın Evi"></asp:TextBox>
        <asp:TextBox CssClass="txt5" ID="TextBox5" autocomplete="off" runat="server" placeholder="Kayıt Tarihi"></asp:TextBox>
        <asp:TextBox CssClass="txt6" ID="TextBox6" autocomplete="off" runat="server" placeholder="Güncel Adet"></asp:TextBox>
        <asp:TextBox CssClass="txt7" ID="TextBox7" autocomplete="off" runat="server" placeholder="Giriş Tarihi"></asp:TextBox>
        <asp:TextBox CssClass="txt8" ID="TextBox8" autocomplete="off" runat="server" placeholder="Çıkış Tarihi"></asp:TextBox>
        <asp:TextBox CssClass="txt9" ID="TextBox9" autocomplete="off" runat="server" placeholder="Alan Kişi"></asp:TextBox>
        <asp:Button CssClass="btn1" ID="Button1" runat="server" OnClick="Button1_Click" Text="Güncelle" />
        <asp:Button CssClass="btn3" ID="Button3" runat="server" OnClick="Button3_Click" Text="Sil" />
    </div>

    <div class=" grid">
        <asp:GridView ID="GridView1" CssClass="data"
            PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="Numara" SortExpression="id" />
                <asp:BoundField DataField="kitap_ad" HeaderText="Kitap Adı" SortExpression="kitap_ad" />
                <asp:BoundField DataField="kitap_yazar" HeaderText="Kitap Yazarı" SortExpression="kitap_yazar" />
                <asp:BoundField DataField="str5" HeaderText="Yayın Evi" SortExpression="str5" />
                <asp:BoundField DataField="tarih1" HeaderText="Kayıt Tarihi" SortExpression="tarih1" />
                <asp:BoundField DataField="int1" HeaderText="Güncel Adet" SortExpression="int1" />
                <asp:BoundField DataField="tarih2" HeaderText="Giriş Tarihi" SortExpression="tarih2" />
                <asp:BoundField DataField="tarih3" HeaderText="Çıkış Tarihi" SortExpression="tarih3" />
                <asp:BoundField DataField="str4" HeaderText="Alan Kişi" SortExpression="str4" />
            </Columns>

            <PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>

      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [kitap_yazar], [kitap_tarih], [kitap_ad], [str4], [int1], [int2], [tarih1], [tarih2], [tarih3], [id], [str5] FROM [kitap_db] "></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [kitap_yazar], [kitap_tarih], [kitap_ad], [str4], [int1], [int2], [tarih1], [tarih2], [tarih3], [id], [str5] FROM [kitap_db] WHERE ([kitap_ad] = @kitap_ad)">
            <selectparameters>
            <asp:ControlParameter ControlID="TextBox2" Name="kitap_ad" PropertyName="Text" Type="String" />
        </selectparameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="DELETE FROM [kitap_db]  WHERE ([id] = @id)">
            <selectparameters>
            <asp:ControlParameter ControlID="TextBox1" Name="id" PropertyName="Text" Type="string" />
        </selectparameters>
        </asp:SqlDataSource>
</asp:Content>
