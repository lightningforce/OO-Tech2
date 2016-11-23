<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FruitStoreSystem2.Home" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">


    <div class="container">
        <div class="col-md-12 well well-inverse2 f-cloud">
            <div class="col-md-offset-5 col-md-7">
                <%--<form>--%>
                <div class="form-group pull-right">
                    <asp:Label ID="Label1" runat="server" Text="รายการจองผลไม้"></asp:Label>
                    <!--<input type="text" class="form-control search-width" placeholder="Search">-->
                    <asp:TextBox ID="txtSearch" CssClass="form-control search-width" runat="server" placeholder="ชื่อลูกค้า"></asp:TextBox>
                    <asp:LinkButton ID="btnSearch" runat="server" OnClick="btnSearch_Click"><button class="btn btn-default glyphicon glyphicon-search top"></button></asp:LinkButton>
                </div>
                <%--</form>--%>
            </div>
            <div>
                <asp:GridView ID="gvReserveOrder" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="reserveID" AllowPaging="True" OnRowDataBound="gvReserveOrder_RowDataBound" OnPageIndexChanging="gvReserveOrder_PageIndexChanging" OnRowCommand="gvReserveOrder_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="imgShow" runat="server" OnClick="imgShow_Click" ImageUrl="~/image/plus.png" CommandArgument="Show" />--%>
                                <img alt="" style="cursor: pointer" src="image/plus.png" />
                                <asp:Panel ID="pnlReserveItem" runat="server" Style="display: none">
                                    <asp:GridView ID="gvReserveItem" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover f-black">
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
                        <asp:BoundField DataField="reserveDate" HeaderText="วันที่จองผลไม้" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="receiveDate" HeaderText="วันที่รับผลไม้" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="status" HeaderText="สถานะ" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <!--<button type="button" id="btnShowPopup" class="btn btn-default" data-toggle="modal" data-target="#myModal">Sell</button>-->
                                <asp:Button ID="btnSell" runat="server" Text="Sell" CommandName="Sell" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btn btn-default"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="col-md-12 well well well-inverse2 f-cloud">
            <div class="col-md-offset-5 col-md-7">
                <%--<form>--%>
                <div class="form-group pull-right">
                    <asp:Label ID="Label2" runat="server" Text="รายการผลไม้ที่ขายแล้ว"></asp:Label>
                    <!--<input type="text" class="form-control search-width" placeholder="Search">-->
                    <asp:TextBox ID="txtSearchSell" CssClass="form-control search-width" runat="server" placeholder="รายการผลไม้ที่ขายแล้ว"></asp:TextBox>
                    <asp:LinkButton ID="btnSearchSell" runat="server" OnClick="btnSearchSell_Click"><button class="btn btn-default glyphicon glyphicon-search top"></button></asp:LinkButton>
                </div>
                <%--</form>--%>
            </div>
            <div>
                <asp:GridView ID="gvSellOrder" runat="server" CssClass="table" AutoGenerateColumns="False" DataKeyNames="reserveID" PageSize="10" AllowPaging="true" OnPageIndexChanging="gvSellOrder_PageIndexChanging" OnRowDataBound="gvSellOrder_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%--<asp:ImageButton ID="imgShow" runat="server" OnClick="imgShow_Click" ImageUrl="~/image/plus.png" CommandArgument="Show" />--%>
                                <img alt="" style="cursor: pointer" src="image/plus.png" />
                                <asp:Panel ID="pnlSellItem" runat="server" Style="display: none">
                                    <asp:GridView ID="gvSellItem" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover f-black">
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
                        <asp:BoundField DataField="reserveDate" HeaderText="วันที่จองผลไม้" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="sellDate" HeaderText="วันที่ขาย" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField DataField="status" HeaderText="สถานะ" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function doClick(buttonName, e) {
            //the purpose of this function is to allow the enter key to 
            //point to the correct button to click.
            var key;

            if (window.event)
                key = window.event.keyCode;     //IE
            else
                key = e.which;     //firefox

            if (key == 13) {
                //Get the button the user wants to have clicked
                var btn = document.getElementById(buttonName);
                if (btn != null) { //If we find the button click it
                    btn.click();
                    event.keyCode = 0
                }
            }
        }
    </script>
</asp:Content>

