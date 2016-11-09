﻿angular.module('fruitStoreApp', [])
  .controller('AddReservingOrderController', function ($scope, $http) {

      // Use x-www-form-urlencoded Content-Type
      $http.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
      var aro = this;    
      var oid = 0;
      var listOfOrder = [];
      aro.objFruit = {
          "customer": "test",
          "date": "",
          "order": []
      }
      //MOCK MASTER DATA.
      aro.fruit = [{
          type: "Banana",
          seeds: ["seed1", "seed2", "seed3"]
      },
      {
          type: "Apple",
          seeds: ["seedA", "seedB", "seedC"]
      }]
      aro.modelDate;
      aro.customer = ["Customer1", "Customer2"];
      aro.fruitType = ["Apple", "Banana"];
      aro.fruitSeed = aro.fruit[0].seeds;
      aro.fruitGrade = ["A", "B", "C"];
      aro.modelCustomer = aro.customer[0];
      $("#datepicker").datepicker().datepicker("setDate", new Date());
      aro.modelDate = $('#datepicker').datepicker({ dateFormat: 'mm-dd-yy' }).val();
      aro.modelType = aro.fruit[0].type;
      aro.modelSeed = aro.fruit[0].seeds[0];
      aro.modelGrade = aro.fruitGrade[0];
      aro.modelAmount;
      console.log(aro.modelType);
      console.log(aro.fruitSeed);

      this.addMoreOrder = function () {
          //THIS FUNCTION ADDED MORE ORDER.
          aro.modelDate = $('#datepicker').datepicker({ dateFormat: 'mm-dd-yy' }).val();
          oid = oid + 1;
          aro.objOrder = {
              type: aro.modelType,
              seed: aro.modelSeed,
              grade: aro.modelGrade,
              amount:aro.modelAmount
          }
          console.log(aro.objOrder)
          aro.objFruit.customer = aro.modelCustomer;
          aro.objFruit.date = aro.modelDate;
          aro.objFruit.order.push(aro.objOrder);
          aro.clearModel();
      }

      this.clearModel = function () {
          aro.modelType = aro.fruit[0].type;
          aro.modelGrade = aro.fruitGrade[0];
          aro.modelSeed = aro.fruit[0].seeds[0];
          aro.modelAmount = '';
      }

      this.submitOrder = function () {
          console.log("Yo", aro.objFruit);
      
          $http.post('/test', aro.objFruit).success(function (res) {
              console.log("beam")
          });           
      }

  });