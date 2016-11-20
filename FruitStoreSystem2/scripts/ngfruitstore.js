angular.module('fruitStoreApp', [])
  .controller('AddReservingOrderController', function ($scope, $http) {

      var aro = this;
      aro.showModal = false;
      var oid = 0;
      aro.fruit = [];
      aro.listOfTypes = [];
      $http.get('http://fruitstore.cloudapp.net').then(data=> {
          aro.res = data.data;
          createAROFruit(aro.res).then(success=> {
              console.log("SUCCESS", aro.fruit);
          })
          /*for (i = 0; i < aro.res.length; i++) {
              var index = aro.listOfTypes.indexOf(aro.res[i].fruitType);
              if (index !== -1) {
                  //THIS TYPE EXIST IN FRUIT. (ADD ONLY SEED.)
                  aro.fruit[index].seeds.push(aro.res[i].fruitSeed);
                  console.log("EXIST",aro.res[i].fruitType);
              } else {
                  //NEW TYPE
                  var fruit = {
                      type: aro.res[i].fruitType,
                      seeds:[aro.res[i].fruitSeed]
                  }
                  aro.fruit.push(fruit);
                  console.log("NEW",aro.res[i].fruitType);
                  aro.listOfTypes.push(aro.res[i].fruitType);
              }
                    
          }*/
          console.log("FRUIT", aro.fruit);
      });

      function createAROFruit(data) {
          var prom = new Promise(function(resolve, reject){
              for (i = 0; i < data.length; i++) {
                  var index = aro.listOfTypes.indexOf(data[i].fruitType);
                  if (index !== -1) {
                      //THIS TYPE EXIST IN FRUIT. (ADD ONLY SEED.)
                      aro.fruit[index].seeds.push(data[i].fruitSeed);
                      console.log("EXIST", data[i].fruitType);
                  } else {
                      //NEW TYPE
                      var fruity = {
                          type: data[i].fruitType,
                          seeds: [data[i].fruitSeed]
                      };
                      aro.fruit.push(fruity);
                      aro.listOfTypes.push(data[i].fruitType);
                  }
              }

              //MOCK MASTER DATA.
              aro.fruitType = [];
              for (i = 0; i < aro.fruit.length; i++) {
                  aro.fruitType.push(aro.fruit[i].type);
                  console.log(aro.fruitType);
              }
              console.log("DEBUGING", aro.fruit);
              aro.seeds = [];
              aro.fruitSeed = aro.fruit.seeds;
              aro.modelType = aro.fruit[0].type;
              aro.modelSeed = aro.fruit[0].seeds[0];
          });
          return prom;
      }
      //DETECT CHANGE IN SELECT.
      $scope.$watch('aro.modelType', function (newVal) {
          console.log(newVal);
          for (i = 0; i < aro.fruit.length; i++) {
              if (aro.fruit[i].type === newVal) {
                  aro.fruitSeed = aro.fruit[i].seeds;
              }
          }
          console.log(aro.modelSeed);
      });
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
      };

      aro.showObjFruit = aro.objFruit;

      console.log("A-1",aro.showObjFruit);
      aro.objFruit = JSON.stringify(aro.objFruit);
      console.log(aro.objFruit);

      //MOCK MASTER DATA.
      aro.modelDate;
      aro.customer = ["Customer1", "Customer2"];
      aro.fruitGrade = ["A", "B", "C"];
      aro.modelCustomer = aro.customer[0];
      $("#datepicker").datepicker().datepicker("setDate", new Date());
      aro.modelDate = $('#datepicker').datepicker({ dateFormat: 'mm-dd-yy' }).val();
      aro.modelGrade = aro.fruitGrade[0];
      aro.modelAmount;

      this.addMoreOrder = function () {
          //THIS FUNCTION ADDED MORE ORDER.

          aro.objFruit = JSON.parse(aro.objFruit);
          console.log("DEBUG01",aro.objFruit);
          aro.modelDate = $('#datepicker').datepicker({ dateFormat: 'mm-dd-yy' }).val();
          oid = oid + 1;
          aro.objOrder = {
              type: aro.modelType,
              seed: aro.modelSeed,
              grade: aro.modelGrade,
              amount:aro.modelAmount
          }
          aro.objFruit.customer = aro.modelCustomer;
          aro.objFruit.date = aro.modelDate;
          aro.objFruit.order.push(aro.objOrder);

          aro.showObjFruit = aro.objFruit;
          aro.clearModel();

          aro.objFruit = JSON.stringify(aro.objFruit);
          console.log("DEBUG02", aro.objFruit);
          console.log("DEBUG03", aro.showObjFruit);
      }

      this.clearModel = function () {
          aro.modelType = aro.fruit[0].type;
          aro.modelGrade = aro.fruitGrade[0];
          aro.modelSeed = aro.fruit[0].seeds[0];
          aro.modelAmount = '';
      }

      this.submitOrder = function () {   
          aro.objFruit = JSON.stringify(aro.objFruit);
          console.log(aro.objFruit);
          jQuery("#hiddenbtn").click();
      }

      this.cancelOrder = function () {
          aro.objFruit.order = [];
      }

  });