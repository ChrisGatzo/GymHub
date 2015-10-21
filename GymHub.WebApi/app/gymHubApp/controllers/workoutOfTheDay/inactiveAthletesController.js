(function () {

    var injectParams = ["dataService", "$modalInstance"];

    var inactiveAthletesController = function (dataService, $modalInstance) {
        var vm = this;

        vm.selectedAthlete = -1;
        vm.inactiveAthletes = {};

        vm.cancel = function () {
            $modalInstance.dismiss("cancel");
        };

        vm.selectAthlete = function (id) {
            if (vm.selectedAthlete == id) {
                vm.selectedAthlete = -1;
                return;
            }

            vm.selectedAthlete = id;
        };

        vm.checkInAthlete = function () {
            if (vm.selectedAthlete == -1) {
                alert("Please select an athlete to check in");
                return;
            }

            dataService.athleteCheckIn(vm.selectedAthlete).then(function (results) {
                $modalInstance.close();
            });

        };

        function init() {
            dataService.getInactiveAthletes().then(function (results) {
                vm.inactiveAthletes = results;
            });
        };

        init();

    };

    inactiveAthletesController.$inject = injectParams;

    angular.module("gymHubApp").controller("InactiveAthletesController", inactiveAthletesController);

}());