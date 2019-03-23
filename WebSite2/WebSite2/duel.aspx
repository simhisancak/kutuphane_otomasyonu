<%@ Page Title="Düello" Debug="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="duel.aspx.cs" Inherits="duel" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="duel">
         <asp:Label CssClass="lbl1" ID="Label1" runat="server" Text="Kaç Kere Yazılacak?"></asp:Label>
        <asp:DropDownList ID="counter" runat="server" OnSelectedIndexChanged="counter_SelectedIndexChanged" CssClass="counter">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
        <asp:Button CssClass="btnok" ID="Button2" runat="server" OnClick="Button1_Click" Text="Oluştur" />
         <asp:Label CssClass="lbl2" ID="Label2" runat="server" Text=""></asp:Label>

    </div>




</asp:Content>
