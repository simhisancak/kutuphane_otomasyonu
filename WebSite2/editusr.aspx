<%@ Page Title="Kullanıcı  Düzenle" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="editusr.aspx.cs" Inherits="editusr" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="usr_btn">
        <asp:Button CssClass="btn2" ID="Button2" runat="server" OnClick="Button2_Click" Text="Ara" />
    </div>
    <div class ="usr_txt">
          <asp:TextBox CssClass="txt1" ID="TextBox1" autocomplete="off" runat="server" placeholder="ID" ReadOnly="True"></asp:TextBox>
         <asp:TextBox CssClass="txt2" ID="TextBox2" autocomplete="off" runat="server" placeholder="Kullanıcı Adı"></asp:TextBox>
        <asp:TextBox CssClass="txt3" ID="TextBox3" autocomplete="off" runat="server" placeholder="Şifre"></asp:TextBox>
        <asp:TextBox CssClass="txt4" ID="TextBox4" autocomplete="off" runat="server" placeholder="Yetki"></asp:TextBox>
                <asp:Button CssClass="btn1" ID="Button1" runat="server" OnClick="Button1_Click" Text="Güncelle" />
        <asp:Button CssClass="btn3" ID="Button3" runat="server" OnClick="Button3_Click" Text="Sil" />
    </div>
    <div class="usr_lbl">
        <asp:Label CssClass="lbl1" ID="Label2" runat="server" Text="ID →"></asp:Label>
        <asp:Label CssClass="lbl2" ID="Label1" runat="server" Text="Kullanıcı Adı →"></asp:Label>
        <asp:Label CssClass="lbl3" ID="Label3" runat="server" Text="Şifre →"></asp:Label>
        <asp:Label CssClass="lbl4" ID="Label4" runat="server" Text="Yetki →"></asp:Label>
        </div>
        <div class=" gridusr">
        <asp:GridView ID="GridView1" CssClass="data"
            PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" DataKeyNames="id">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="user_name" HeaderText="Kullanıcı İsmi" SortExpression="user_name" />
                <asp:BoundField DataField="user_password" HeaderText="Şifre" SortExpression="user_password" />
                <asp:BoundField DataField="str2" HeaderText="Yetki" SortExpression="str2" />
            </Columns>

            <PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>

          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [user_name], [user_password], [str2], [id] FROM [kitap_users]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [user_name], [user_password], [str2], [id] FROM [kitap_users] WHERE ([user_name] = @user_name)">
            <selectparameters>
            <asp:ControlParameter ControlID="TextBox2" Name="user_name" PropertyName="Text" Type="String" />
        </selectparameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="DELETE FROM [kitap_users]  WHERE ([id] = @id)">
            <selectparameters>
            <asp:ControlParameter ControlID="TextBox1" Name="id" PropertyName="Text" Type="string" />
        </selectparameters>
        </asp:SqlDataSource>
    </asp:Content>