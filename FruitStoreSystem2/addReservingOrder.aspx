<%@ Page Title="Add Reserving Order" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addReservingOrder.aspx.cs" Inherits="FruitStoreSystem2.addReservingOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="addReservingOrderContent" ContentPlaceHolderID="Content" runat="server">
    <div class="container" ng-app="fruitStoreApp" ng-controller="AddReservingOrderController as aro">
        <div class="col-md-12 jumbotron jumbotron-inverse">
            <div class="col-md-12">
                <div class="col-md-12 line-element">
                    <div class="col-md-12 well well-inverse">
                        <div class="col-md-6">
                            <span class="f-silver">ชื่อ-นามสกุล ลูกค้า </span>
                            <select ng-model="aro.modelCustomer" ng-options="element for element in aro.customer"></select>
                        </div>
                        <div class="col-md-6">
                            <span class="f-silver">Date:</span>
                            <input ng-model="aro.modelDate" type="text" id="datepicker">
                        </div>
                    </div>
                </div>
                <div class="col-md-6 col-md-offset-3">
                    <table class="table f-cloud" ng-hide="!aro.showObjFruit.order[0]">
                        <thead>
                            <tr>
                                <th>ผลไม้ที่ต้องการจอง</th>
                                <th>พันธุ์</th>
                                <th>เกรด</th>
                                <th>จำนวน</th>
                            </tr>
                        </thead>
                        <tbody ng-repeat="ordered in aro.showObjFruit.order">
                            <tr class="table-info f-silver">
                                <td>{{ordered.type}}</td>
                                <td>{{ordered.seed}}</td>
                                <td>{{ordered.grade}}</td>
                                <td>{{ordered.amount}}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="col-md-12 well well-inverse">
                    <table class="table">
                        <thead class="f-silver">
                            <tr>
                                <th>ผลไม้ที่ต้องการจอง</th>
                                <th>พันธุ์</th>
                                <th>เกรด</th>
                                <th>จำนวน</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <select ng-model="aro.modelType" ng-options="element for element in aro.fruitType"></select></td>
                                <td>
                                    <select ng-model="aro.modelSeed" ng-options="seed for seed in aro.fruitSeed"></select></td>
                                <td>
                                    <select ng-model="aro.modelGrade" ng-options="element for element in aro.fruitGrade"></select></td>
                                <td>
                                    <input type="number" ng-model="aro.modelAmount"></input>
                                    <span class="f-cloud">กก.</span></td>
                                <td>
                                    <button class="btn btn-info peter" ng-disabled="!aro.modelAmount" type="button" ng-click="aro.addMoreOrder()">
                                        <span class="glyphicon glyphicon-plus"></span>
                                    </button>
                                    <span class="f-silver">เพิ่มผลไม้ในรายการจอง</span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <!--<div class="col-md-12 well">  
                        <div class="col-md-12">
                            <table class="table table-hover">
                                <thead>
                                    <tr>                               
                                        <th>ผลไม้ที่ต้องการจอง</th>
                                        <th>พันธุ์</th>
                                        <th>เกรด</th>
                                        <th>จำนวน</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>                                  
                                        <th><select ng-model="aro.modelType" ng-options="element for element in aro.fruitType"></select></th>
                                        <th><select ng-model="aro.modelSeed" ng-options="seed for seed in aro.fruitSeed"></select></th>
                                        <th><select ng-model="aro.modelGrade" ng-options="element for element in aro.fruitGrade"></select></th>
                                        <th><input type="number" ng-model="aro.modelAmount"></input> <span>กก.</span></th>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="col-md-6">
                             <span>ผลไม้ที่ต้องการจอง</span> 
                             <select ng-model="aro.modelType" ng-options="element for element in aro.fruitType"></select>
                            </div>
                            <div class="col-md-6">
                             <span>พันธุ์</span> <select ng-model="aro.modelSeed" ng-options="seed for seed in aro.fruitSeed"></select>
                            </div>
                        </div>
                        <div class="col-md-12 line-element">
                            <div class="col-md-6">
                                <span>เกรด</span>  <select ng-model="aro.modelGrade" ng-options="element for element in aro.fruitGrade"></select>
                            </div>
                            <div class="col-md-6">
                              <span>จำนวน</span> <input type="number" ng-model="aro.modelAmount"></input> <span>กก.</span>
                            </div>
                        </div>
                    </div>-->
            </div>   
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
            <div class="col-md-offset-8 col-md-4">
                <asp:Button ID="hiddenbtn" CssClass="btn btn-success" OnClick="Button1_Click" runat="server" Text="ยืนยัน" />
                <!--<button type="button" class="btn btn-success" ng-disabled="!aro.objFruit.order[0]" ng-click="aro.submitOrder()">ยืนยัน</button>-->
                <button type="button" class="btn btn-danger" ng-click="aro.cancelOrder()">ยกเลิก</button>
            </div>
        </button><!--CLOSE JUMBOTRON-->
        <asp:TextBox ID="TextBox1" runat="server" ng-model="aro.objFruit"  ng-hide="aro.objFruit"></asp:TextBox>
       <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>--%>
    </div>
         
</asp:Content>
