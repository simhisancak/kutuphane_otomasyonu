﻿<%@ Page Title="Mat Yazmalı" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="matyazma.aspx.cs" Inherits="matyazma" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


<meta name="keywords" content="simhi,sancak,simhisancak,metin2,ejder,el,alıstırma,svside" />
    <meta name="description" content="Ejder El Alıştırma" />   
 <div class="mat-yazmali">
        <asp:Label CssClass="lbl1" ID="Label1" runat="server" Text="       "></asp:Label>
        
     



        <asp:TextBox CssClass="txt1" ID="TextBox1" autocomplete="off" runat="server"  OnTextChanged="TextBox1_TextChanged1"></asp:TextBox>

        <asp:Button CssClass="btn1" ID="Button1" runat="server" OnClick="Button1_Click1" Text="Başla" />
      <asp:Label CssClass="lbl2" ID="Label2" runat="server"  Text="    " ></asp:Label>
             <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
     <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<script>
     (adsbygoogle = window.adsbygoogle || []).push({
          google_ad_client: "ca-pub-5648822624229645",
          enable_page_level_ads: true
     });
</script>


    </div>
</asp:Content>
