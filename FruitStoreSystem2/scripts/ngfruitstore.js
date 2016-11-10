angular.module('fruitStoreApp', [])
  .controller('AddReservingOrderController', function ($scope, $http) {

      var aro = this;    
      var oid = 0;
      var listOfOrder = [];
      aro.pathname = window.location.pathname;
      if (aro.pathname === "/addReservingOrder.aspx") {
          aro.addReservingOrderPage = "active";
      } else if (aro.pathname === "/Home.aspx") {
          aro.Home = "active";
      }
      aro.objFruit = {
          "customer": "exampleCustomer",
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
          aro.objFruit = JSON.stringify(aro.objFruit);          
      }

      this.cancelOrder = function () {
          aro.objFruit.order = [];
      }

  });