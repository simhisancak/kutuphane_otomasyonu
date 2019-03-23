<%@ Page Title="Sıralama" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="rank.aspx.cs" Inherits="rank" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="rank1">
          <asp:Label CssClass="lbl1" ID="Label1" runat="server" Text="Yazmalı"></asp:Label>
        <asp:GridView ID="GridView1" CssClass="data"
            PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" PageSize="5">
            <Columns>
                <asp:BoundField DataField="user_name" HeaderText="İsim" SortExpression="user_name" />

                <asp:BoundField DataField="speed1" HeaderText="Süre (ms)" SortExpression="speed1" />

            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>
    <div class="rank2">
          <asp:Label CssClass="lbl1" ID="Label2" runat="server" Text="Seçmeli"></asp:Label>
        <asp:GridView ID="GridView2" CssClass="data"
            PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" PageSize="5">
            <Columns>
                <asp:BoundField DataField="user_name" HeaderText="İsim" SortExpression="user_name" />
                <asp:BoundField DataField="speed2" HeaderText="Süre (ms)" SortExpression="speed2" />

            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>

        <div class="rank3">
          <asp:Label CssClass="lbl1" ID="Label3" runat="server" Text="Mat Yazmalı"></asp:Label>
        <asp:GridView ID="GridView3" CssClass="data"
            PagerStyle-CssClass="pgr" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" PageSize="5">
            <Columns>
                <asp:BoundField DataField="user_name" HeaderText="İsim" SortExpression="user_name" />
                <asp:BoundField DataField="speed3" HeaderText="Süre (ms)" SortExpression="speed3" />

            </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
        </asp:GridView>
    </div>



    <div class ="bilgi">
         <asp:Label CssClass="lbl1" ID="Label4" runat="server" Text="Sizde Kayıt Olarak Sıralamaya Girebilirsiniz"></asp:Label>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand=";with degerler as (SELECT *, ROW_NUMBER() OVER( ORDER BY speed1) AS users FROM users)select top 15 * from degerler "></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand=";with degerler as (SELECT *, ROW_NUMBER() OVER( ORDER BY speed2) AS users FROM users)select top 15 * from degerler "></asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand=";with degerler as (SELECT *, ROW_NUMBER() OVER( ORDER BY speed3) AS users FROM users)select top 15 * from degerler "></asp:SqlDataSource>
</asp:Content>
