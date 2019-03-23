<%@ Page Title="Şifremi Unuttum" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="recovery.aspx.cs" Inherits="recovery" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="recovery">


        <asp:TextBox CssClass="txtmail" ID="txtmail" TextMode="Email" placeholder="Mail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mailcontrol"
            ControlToValidate="txtmail" ErrorMessage="Email gereklidir"
            SetFocusOnError="True"></asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="mailcontrol"
            ErrorMessage="Geçersiz E-Posta" ControlToValidate="txtmail"
            SetFocusOnError="True"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
        </asp:RegularExpressionValidator>
        <asp:Button CssClass="btnsend" ID="Button2" runat="server" OnClick="Button1_Click" Text="Gönder" />
        <asp:Label CssClass="lblmail" ID="Label1" runat ="server" Text="" />
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
