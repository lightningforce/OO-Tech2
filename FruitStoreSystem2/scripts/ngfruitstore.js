angular.module('fruitStoreApp', [])
  .controller('AddReservingOrderController', function () {
      var aro = this;
      aro.numberOfOrders = [{obj:"obj"}];
      var oid = 0;

      //MOCK MASTER DATA.
      this.type = ["Orange", "Apple", "Banana"];
      aro.fruitType = this.type[0];
      this.addMoreOrder = function () {
          //THIS FUNCTION ADDED MORE ORDER.
          console.log(aro.numberOfOrders);
          oid = oid + 1;
          aro.numberOfOrders.push({ id: oid });
      }

      //aro.listOrders =>  [{orderObj1},{orderObj2},...]
      //aro.listOfOrders.push({ type: aro.type, seed: aro.seed, grade: aro.grade, amount: aro.amount })
  });