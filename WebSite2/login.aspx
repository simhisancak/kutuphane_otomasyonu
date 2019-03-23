<%@ Page Title="Giriş Yap" Debug="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <meta name="keywords" content="simhi,sancak,simhisancak,metin2,ejder,el,alıstırma,svside" />
    <meta name="description" content="Ejder El Alıştırma" />
    <div class="login">
        <asp:Label CssClass="lbl1" ID="Label1" runat="server" Text=""></asp:Label>
        <asp:TextBox CssClass="txtuser" ID="txtuser" TextMode="SingleLine" placeholder="Kullanıcı Adı" runat="server"></asp:TextBox>
        <asp:TextBox CssClass="txtpsw" ID="txtpsw" TextMode="Password" placeholder="Şifre" runat="server"></asp:TextBox>
        <asp:Button CssClass="btnlogin" ID="Button2" runat="server" OnClick="Button1_Click" Text="Giriş Yap" />
        <asp:Button CssClass="recovery" ID="recovery" runat="server" OnClick="recovery_Click" Text="Şifremi Unuttum" />



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
