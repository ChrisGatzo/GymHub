(function () {

    var injectParameters = ["$http", "$q"];

    var dataService = function ($http, $q) {
        var serviceBase = "/api/",
            factory = {};

        factory.getActiveAthletes = function () {
            return $http.get(serviceBase + "workoutOfTheDay/ActiveAthletes").then(
                function (results) {
                    return results.data;
                });
        };

        factory.getInactiveAthletes = function () {
            return $http.get(serviceBase + "workoutOfTheDay/InactiveAthletes").then(
                function (results) {
                    return results.data;
                });
        }

        factory.athleteCheckIn = function (athleteId) {
            return $http.post(serviceBase + "workoutOfTheDay", athleteId).then(
                function (results) {
                    return results.data;
                });
        }

        return factory;
    }

    dataService.$inject = injectParameters;

    angular.module("gymHubApp").factory("dataService", dataService);

}());