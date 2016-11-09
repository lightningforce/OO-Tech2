﻿<%@ Page Title="Add Reserving Order" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addReservingOrder.aspx.cs" Inherits="FruitStoreSystem2.addReservingOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="addReservingOrderContent" ContentPlaceHolderID="Content" runat="server" >
    <div class="container" ng-app="fruitStoreApp" ng-controller="AddReservingOrderController as aro">
        <div class="col-md-12 jumbotron">
            <div class="col-md-12">
                <div class="col-md-12 line-element">
                    <div class="col-md-12 well">
                        <div class="col-md-6">
                            <span>ชื่อ-นามสกุล ลูกค้า </span> <select ng-model="aro.modelCustomer" ng-options="element for element in aro.customer"></select>
                        </div>
                        <div class="col-md-6">
                            Date: <input ng-model="aro.modelDate" type="text" id="datepicker">
                        </div>
                    </div>
                 </div>
                <div class="col-md-12">       
                        <table class="table table-hover"  ng-hide="!aro.objFruit.order[0]">
                            <thead>
                                <tr>                               
                                    <th>ชนิดผลไม้</th>
                                    <th>พันธุ์</th>
                                    <th>เกรด</th>
                                    <th>จำนวน</th>
                                </tr>
                            </thead>
                            <tbody ng-repeat="ordered in aro.objFruit.order">
                                <tr>                                  
                                    <th>{{ordered.type}}</th>
                                    <th>{{ordered.seed}}</th>
                                    <th>{{ordered.grade}}</th>
                                    <th>{{ordered.amount}}</th>
                                </tr>
                            </tbody>
                        </table>
                <div>     
                    <div class="col-md-12 well">  
                        <div class="col-md-12">
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
                    </div>
            </div>   
            <button class="btn btn-success" ng-disabled="!aro.modelAmount" type="button" ng-click="aro.addMoreOrder()">
              <span class="glyphicon glyphicon-plus"></span>
            </button>
            <div ng-hide="aro.modelAmount&&aro.modelDate" class="label label-warning">กรุณากรอกข้อมูลให้ครบถ้วน ก่อนเพิ่มรายการจองผลไม้</div>
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
            <div class="col-md-offset-8 col-md-4">
                <button type="button" class="btn btn-success" ng-click="aro.submitOrder()">ยืนยัน</button>
                <button type="button" class="btn btn-danger">ยกเลิก</button>
            </div>
        </button><!--CLOSE JUMBOTRON-->
    </div>
</asp:Content>
