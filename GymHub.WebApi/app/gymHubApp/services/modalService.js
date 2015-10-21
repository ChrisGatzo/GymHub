(function () {

    var injectParams = ["$uibModal"];

    var modalService = function ($uibModal) {
        var viewBase = "/app/gymHubApp/partials/";

        this.getInactiveAthletes = function () {
            var modalInstance = $uibModal.open({
                templateUrl: viewBase + "inactiveAthletes.html",
                controller: "InactiveAthletesController",
                controllerAs: "vm",
                size: "lg"
            });

            return modalInstance;
        };

    };

    modalService.$inject = injectParams;

    angular.module("gymHubApp").service("modalService", modalService);

}());