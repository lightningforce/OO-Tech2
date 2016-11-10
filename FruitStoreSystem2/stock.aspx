<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="stock.aspx.cs" Inherits="FruitStoreSystem2.stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12 well">
                <label>จำนวนผลไม้ที่ร้านมี</label>
            </div>

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
                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3 top">
                        <p>กก.</p>
                    </div>
                </div>
                <div class="col-md-12 wrapper margintop">
                    <asp:Button ID="InputConfirmButton" CssClass="btn btn-default" runat="server" Text="ยืนยัน" />
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
                        <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" onDataBound="DropDownList3_DataBound" AutoPostBack="true"></asp:DropDownList>
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
                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-1 top">
                        <p>กก.</p>
                    </div>
                </div>
                <div class="col-md-12 wrapper margintop">
                    <asp:Button ID="SepConfirmButton" CssClass="btn btn-default" runat="server" Text="ยืนยัน" />
                </div>

            </div>
        </div>

    </div>
</asp:Content>
