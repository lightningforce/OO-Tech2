<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FruitStoreSystem2.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="col-md-offset-6 col-md-6">
            <%--<form>--%>
            <div class="form-group">
                <!--<input type="text" class="form-control search-width" placeholder="Search">-->
                <asp:TextBox ID="txtSearch" CssClass="form-control search-width" runat="server"></asp:TextBox>
                <asp:LinkButton ID="btnSearch" runat="server"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
            </div>
            <%--</form>--%>
        </div>
        <asp:GridView ID="gvFruit" runat="server" CssClass="table" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" />
                <asp:BoundField DataField="Lastname" HeaderText="Lastname" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" />            
            </Columns>
        </asp:GridView>

    </div>

    <asp:GridView ID="gvReserveOrder" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="reserveID" OnRowDataBound="gvReserveOrder_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%--<asp:ImageButton ID="imgShow" runat="server" OnClick="imgShow_Click" ImageUrl="~/image/plus.png" CommandArgument="Show" />--%>
                    <img alt="" style="cursor: pointer" src="image/plus.png" />
                    <asp:Panel ID="pnlReserveItem" runat="server" Style="display: none">
                        <asp:GridView ID="gvReserveItem" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="150px" HeaderText="ลำดับที่">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField ItemStyle-Width="150px" DataField="fruitType" HeaderText="ชนิดผลไม้" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="fruitSeed" HeaderText="พันธุ์" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="grade" HeaderText="เกรด" />
                                <asp:BoundField ItemStyle-Width="150px" DataField="quantity" HeaderText="จำนวน" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="reserveID" HeaderText="เลขที่การจอง" />
            <asp:BoundField DataField="cus_fullname" HeaderText="ชื่อสกุลลูกค้า" />
            <asp:BoundField DataField="reserveDate" HeaderText="วันที่จองผลไม้" />
            <asp:BoundField DataField="receiveDate" HeaderText="วันที่รับผลไม้" />
            <asp:BoundField DataField="status" HeaderText="สถานะ" />
        </Columns>
    </asp:GridView>
   
</asp:Content>
