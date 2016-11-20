<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="sales.aspx.cs" Inherits="FruitStoreSystem2.sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!--<div class="col-md-offset-3 col-md-6" style="background-color:red;" >tt</div>-->
    <div class="container">
        <div class="jumbotron col-md-offset-2 col-md-8" style="background-color: lightgray;">
            <div class="col-md-12">
                <p align="center">รายการขายสินค้า</p>
            </div>
            <div class="col-md-6">
                <div class="col-md-4">
                    <h4>
                    รหัสจอง
                </div>
                <div class="col-md-8">
                    <h4>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </h4>
                </div>
            </div>
            <div class="col-md-6">
                <div class="col-md-4">
                    <h4>จองวันที่</h4>
                </div>
                <div class="col-md-8">
                    <h4>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </h4>
                </div>

            </div>
            <div class="col-md-6">
                <div class="col-md-4">
                    <h4>โดย</h4>
                </div>
                <div class="col-md-8">
                    <h4>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h4>
                </div>
            </div>
            <div class="col-md-12"></div>
            <div class="col-md-12">
                <div class="col-md-4">
                    <h4>ทำการขายผลไม้วันที่</h4>
                </div>
                <div class="col-md-8">
                    <h4>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></h4>
                </div>
            </div>

            <div class="col-md-6">
                <div class="col-md-6">
                    <h4>ตามรายการ</h4>
                </div>
            </div>
            <div class="col-md-12"></div>
            
            <div class="col-md-12"></div>
            <div class="col-md-12 padding5per">
            <asp:GridView ID="showSale" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover">
                <Columns>
                    <asp:BoundField DataField="fruitType" HeaderText="ชนิดผลไม้"/>
                    <asp:BoundField DataField="fruitSeed" HeaderText="พันธุ์ผลไม้" />
                    <asp:BoundField DataField="grade" HeaderText="เกรด" />
                    <asp:BoundField DataField="quantity" HeaderText="จำนวน" />
                </Columns>
            </asp:GridView>
            </div>
            <br>
            <br>
                <div class="col-md-12 margintop">
                    <div class ="col-md-offset-4">
                    <button type="button" class="btn btn-success">ยืนยันการขาย</button>
                    <button type="button" class="btn btn-danger ">ยกเลิก</button>
                    </div>
                </div>
            </div>
            
            
            
          
        
        
        </div>
    
</asp:Content>
