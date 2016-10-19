<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FruitStoreSystem2.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gdvFruit" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="customerName" HeaderText="Customer Name" />
        </Columns>
    </asp:GridView>
</asp:Content>
