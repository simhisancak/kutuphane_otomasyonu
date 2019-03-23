<%@ Page Title="Kitaplar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Kitaplar">

 <div class=" grid">
        <asp:GridView ID="GridView1" CssClass="data"
            PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True">
            <Columns>
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
        <div class="edit_lbl">
        <asp:Label CssClass="lbl2" ID="Label2" runat="server" Text="Kitap Adı →"></asp:Label>
            <</div>
          <div class="home">
        <asp:TextBox CssClass="txt1" ID="TextBox1" autocomplete="off" runat="server" placeholder="Kitap Adı"></asp:TextBox>
               <asp:Button CssClass="btn2" ID="Button2" runat="server" OnClick="Button2_Click" Text="Ara" />
              </div>
      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [kitap_yazar], [kitap_tarih], [kitap_ad], [str4], [int1], [int2], [tarih1], [tarih2], [tarih3], [id], [str5] FROM [kitap_db]"></asp:SqlDataSource>
           <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [kitap_yazar], [kitap_tarih], [kitap_ad], [str4], [int1], [int2], [tarih1], [tarih2], [tarih3], [id], [str5] FROM [kitap_db] WHERE ([kitap_ad] = @kitap_ad)">
            <selectparameters>
            <asp:ControlParameter ControlID="TextBox1" Name="kitap_ad" PropertyName="Text" Type="String" />
        </selectparameters>
        </asp:SqlDataSource>

    </div>
    
</asp:Content>
