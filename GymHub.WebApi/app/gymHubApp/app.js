(function () {

    var app = angular.module("gymHubApp",
        ["ngRoute", "ui.bootstrap", "ui.bootstrap.modal", "ui.bootstrap.tpls"]);

    app.config(["$routeProvider", function ($routeProvider) {
        var viewBase = "/app/gymHubApp/views/";

        $routeProvider
            .when("/workoutoftheday", {
                controller: "WorkoutOfTheDayController",
                templateUrl: viewBase + "workoutOfTheDay/workoutOfTheDay.html",
                controllerAs: "vm"
            })
            .when("/statistics", {
                controller: "StatisticsController",
                templateUrl: viewBase + "statistics/statitics.html",
                controllerAs: "vm"
            })
            .when("/diet", {
                controller: "DietController",
                templateUrl: viewBase + "diet/diet.html",
                controllerAs: "vm"
            })
            .otherwise({ redirectTo: "/workoutoftheday" });

    }]);

    //app.run(["$rootScope", "$location", "authService",
    //    function ($rootScope, $location, authService) {

    //        //Client-side security. Server-side framework MUST add it's 
    //        //own security as well since client-based security is easily hacked
    //        $rootScope.$on("$routeChangeStart", function (event, next, current) {
    //            if (next && next.$$route && next.$$route.secure) {
    //                if (!authService.user.isAuthenticated) {
    //                    $rootScope.$evalAsync(function () {
    //                        authService.redirectToLogin();
    //                    });
    //                }
    //            }
    //        });

    //    }]);

}());
