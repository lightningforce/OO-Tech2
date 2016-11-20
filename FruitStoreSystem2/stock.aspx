<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="stock.aspx.cs" Inherits="FruitStoreSystem2.stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="container">
        <div class="row">


            <div class="col-md-4 well">
                <div class="col-md-12">
                    <p align="center">รับผลไม้จากสวน</p>
                </div>
                <div class="col-md-12 margintop">
                    <div class="col-md-2">
                        <p>รับ:</p>
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnDataBound="DropDownList1_DataBound" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12 margintop">
                    <div class="col-md-2">
                        <p>พันธุ์:</p>
                    </div>
                    <div class="col-md-10">
                        <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12 margintop form-group">
                    <div class="col-md-2 top">
                        <p>จำนวน</p>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                    </div>
                    <div class="col-md-3 top">
                        <p>กก.</p>
                    </div>
                </div>
                <div class="col-md-12 wrapper margintop">
                    <asp:Button ID="InputConfirmButton" CssClass="btn btn-default" runat="server" Text="ยืนยัน" OnClick="InputConfirmButton_Click" />
                </div>
            </div>

            <div class="col-md-7 well col-md-offset-1">
                <div class="col-md-12">
                    <p align="center">บันทึกเกรดผลไม้</p>
                </div>
                <div class="col-md-12 margintop">
                    <div class="col-md-2">
                        <p>ชนิดผลไม้</p>
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" OnDataBound="DropDownList3_DataBound" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <p>พันธุ์</p>
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12 margintop">
                    <div class="col-md-5 top">
                        <p align="right">เป็นเกรด A จำนวน</p>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                    </div>
                    <div class="col-md-1 top">
                        <p>กก.</p>
                    </div>
                </div>
                <div class="col-md-12 margintop">
                    <div class="col-md-5 top">
                        <p align="right">เป็นเกรด B จำนวน</p>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                    </div>
                    <div class="col-md-1 top">
                        <p>กก.</p>
                    </div>
                </div>
                <div class="col-md-12 margintop">
                    <div class="col-md-5 top">
                        <p align="right">เป็นเกรด C จำนวน</p>
                    </div>
                    <div class="col-md-6">
                        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" Text="0"></asp:TextBox>
                    </div>
                    <div class="col-md-1 top">
                        <p>กก.</p>
                    </div>
                </div>
                <div class="col-md-12 wrapper margintop">
                    <asp:Button ID="SepConfirmButton" CssClass="btn btn-default" runat="server" Text="ยืนยัน" OnClick="SepConfirmButton_Click" />
                </div>

            </div>

            <div class="col-md-12 well">
                <div class="col-md-12">
                    <p align="center">จำนวนผลไม้ที่ร้านมี</p>
                </div>
                <div class="col-md-12"></div>
                <div class="col-md-4">
                    <p align="center">ยังไม่ได้คัดเกรด</p>
                    <asp:GridView ID="showUncatStock" CssClass="table table-hover" runat="server" AutoGenerateColumns="false" GridLines="none">
                        <Columns>
                            <asp:BoundField DataField="fruitType" HeaderText="ชนิดผลไม้" />
                            <asp:BoundField DataField="fruitSeed" HeaderText="พันธุ์ผลไม้" />
                            <asp:BoundField DataField="uncatAmount" HeaderText="จำนวน" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-7 col-md-offset-1">
                    <p align="center">คัดเกรดแล้ว</p>
                    <asp:GridView ID="showGradedStock" runat="server" CssClass="table table-condensed" AutoGenerateColumns="false" GridLines="none">
                        <Columns>
                            <asp:BoundField DataField="fruitType" HeaderText="ชนิดผลไม้" />
                            <asp:BoundField DataField="fruitSeed" HeaderText="พันธุ์ผลไม้" />
                            <asp:BoundField DataField="grade" HeaderText="เกรด" />
                            <asp:BoundField DataField="amount" HeaderText="จำนวน" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </div>


    </div>
</asp:Content>
