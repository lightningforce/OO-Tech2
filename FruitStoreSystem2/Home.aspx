<%@ Page Title="Show Reserving List" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FruitStoreSystem2.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="homeContent" ContentPlaceHolderID="Content" runat="server">
   
    
    <div class="container">
        <div class="col-md-offset-6 col-md-6">
          <form>
            <div class="form-group">
              <!--<input type="text" class="form-control search-width" placeholder="Search">-->
                 <asp:TextBox ID="txtSearch" CssClass="form-control search-width" runat="server"></asp:TextBox>
                 <asp:LinkButton ID="btnSearch" CssClass="btn btn-default" runat="server"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
</asp:LinkButton>
            </div>
          </form>
        </div>
        <asp:GridView ID="gvFruit" runat="server" CssClass="table" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />            
            </Columns>
        </asp:GridView>

    </div>
    
</asp:Content>
