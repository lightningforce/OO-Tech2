<%@ Page Title="Add Reserving Order" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addReservingOrder.aspx.cs" Inherits="FruitStoreSystem2.addReservingOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="addReservingOrderContent" ContentPlaceHolderID="Content" runat="server" >
    <div class="container" ng-app="fruitStoreApp" ng-controller="AddReservingOrderController as aro">
        <div class="col-md-12 jumbotron">
            <div class="col-md-12">
                <div class="col-md-12 line-element">
                    <div class="col-md-12 well">
                        <span>ชื่อ-นามสกุล ลูกค้า {{aro.test}}</span> <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    </div>
                 </div>
                <div ng-repeat="order in aro.numberOfOrders">
                    <div class="col-md-12 well">  
                        <div class="col-md-12">
                            <div class="col-md-6">
                             <span>ผลไม้ที่ต้องการจอง</span> 
                             <!--<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>-->
                             <select ng-model="aro.fruitType" ng-options="element for element in aro.type"></select>
                            </div>
                            <div class="col-md-6">
                             <span>พันธุ์</span> <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12 line-element">
                            <div class="col-md-6">
                                <span>เกรด</span> <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                              <span>จำนวน</span> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <span>กก.</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>   
            <button class="btn btn-success" type="button" ng-click="aro.addMoreOrder()">
              <span class="glyphicon glyphicon-plus"></span>
            </button>
            <span>ต้องการจองผลไม้เพิ่ม</span>
            <div class="collapse" id="collapseExample">
              <div class="well">
                <div class="col-md-12">
                    <div class="col-md-offset-3">
                        <div class="col-md-12">

                        </div>
                    </div>
                </div>
              </div>
            </div>
        </div><!--CLOSE JUMBOTRON-->
    </div>
</asp:Content>
