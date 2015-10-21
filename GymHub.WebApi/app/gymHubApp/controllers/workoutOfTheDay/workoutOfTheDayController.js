(function () {

    var injectParams = ["dataService", "modalService"];

    var workoutOfTheDayController = function (dataService, modalService) {
        var vm = this;

        function getActiveAthletes() {
            dataService.getActiveAthletes()
          .then(function (data) {
              vm.filteredAthletes = data.filteredAthletes;

              //$timeout(function () {
              //    vm.cardAnimationClass = ""; //Turn off animation since it won't keep up with filtering
              //}, 1000);

          }, function (error) {
              //$window.alert("Sorry, an error occurred: " + error.data.message);
          });
        }

        function getInactiveAthletes() {
            var modalInstance = modalService.getInactiveAthletes();

            modalInstance.opened.then(function() {
                //    $scope.selected = selectedItem;
                //}, function () {
                //    $log.info("Modal dismissed at: " + new Date());
                //});
            });
        };

        function init() {
            getActiveAthletes();
        }

        vm.getInactiveAthletes = function () {
            getInactiveAthletes();
        };

        init();
    };

    workoutOfTheDayController.$inject = injectParams;

    angular.module("gymHubApp").controller("WorkoutOfTheDayController", workoutOfTheDayController);

}());
