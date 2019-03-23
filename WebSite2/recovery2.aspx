<%@ Page Title="Şifre Sıfırlama" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="recovery2.aspx.cs" Inherits="recovery2" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="recovery2">


        
        <br />
        <br />
        <br />
        <br />
        <br />


        
        <asp:TextBox CssClass="txtpsw" ID="txtpsw" TextMode="Password" placeholder="Şifre" runat="server"></asp:TextBox>
         <asp:Label CssClass="lblmail" ID="Label1" runat ="server" Text="" />
                <asp:Button CssClass="btnsend" ID="Button2" runat="server" OnClick="Button1_Click" Text="Sıfırla" />
       
        <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
        <script>
            (adsbygoogle = window.adsbygoogle || []).push({
                google_ad_client: "ca-pub-5648822624229645",
                enable_page_level_ads: true
            });
        </script>

    </div>

</asp:Content>
