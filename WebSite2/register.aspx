<%@ Page Title="Kayıt Ol" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">




    <meta name="keywords" content="simhi,sancak,simhisancak,metin2,ejder,el,alıstırma,svside" />
    <meta name="description" content="Ejder El Alıştırma" />
    <div class="register">
        <asp:Label CssClass="lbl1" ID="Label1" runat="server" Text=""></asp:Label>
       
        <asp:Label CssClass="lbl2" ID="Label2" runat="server" Text=""></asp:Label>
        <asp:TextBox CssClass="txtuser" ID="txtuser" TextMode="SingleLine" placeholder="Kullanıcı Adı" runat="server" OnTextChanged="txtuser_TextChanged" ></asp:TextBox>
        <asp:TextBox CssClass="txtpsw" ID="txtpsw" TextMode="Password" placeholder="Şifre" runat="server" OnTextChanged="txtpsw_TextChanged" ></asp:TextBox>
      <asp:TextBox CssClass="txtmail" ID="txtmail" TextMode="Email" placeholder="Mail" runat="server" OnTextChanged="txtmail_TextChanged" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
        ControlToValidate="txtmail" ErrorMessage="Email gereklidir" CssClass="mailcontrol"
        SetFocusOnError="True" ></asp:RequiredFieldValidator>

 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="mailcontrol"
             ErrorMessage="Geçersi
     
  z E-Posta" ControlToValidate="txtmail"
             SetFocusOnError="True"
             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
</asp:RegularExpressionValidator>
        
        <asp:Button CssClass="btnlogin" ID="Button2" runat="server" OnClick="Button1_Click" Text="Kayıt Ol" />




        <!-- Adsense -->

        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({
                google_ad_client: "ca-pub-5648822624229645",
                enable_page_level_ads: true
            });
        </script>

    </div>

</asp:Content>
