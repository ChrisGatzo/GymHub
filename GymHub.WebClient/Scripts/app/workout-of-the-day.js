var gymHub = gymHub || {};

gymHub.workoutOfTheDay = function () {
    var statisticsModal = $("#athlete-statistic-modal");
    var athletesCheckInModal = $("#athletes-checkin-modal");
    var baseUrl = $("body").data("route-url");
    var oTable;

    var initSignalr = function () {
        var clientHub = $.connection.activeAthletesHub;
        clientHub.client.broadcastMessage = function (message) {
            oTable.draw();
        };
        $.connection.hub.start().done();
    };

    var initDataTables = function () {
        oTable = $("#athletes-table").DataTable({
            "processing": true,
            "serverSide": true,
            "ajax": baseUrl + "WorkoutOfTheDay/ActiveAthletesPaging",
            "responsive": true,
            "columnDefs": [
                { "orderable": false, "width": "4%", "targets": 0 }
            ],
            "order": [[1, "asc"]]
        });
    };

    var initTooltips = function () {
        $("[data-toggle=\"tooltip\"]").tooltip();
    };

    var init = function () {
        initDataTables();
        initSignalr();
        initTooltips();
    };

    var editStatisticsCallback = function (response) {
        statisticsModal.html(response);
        statisticsModal.modal("show");
    },
    editStatistics = function ($buttonClicked) {
        var athleteId = $buttonClicked.data("athlete-id");
        gymHub.dataService.editStatistics(athleteId, editStatisticsCallback);
    };

    var saveStatisticsCallback = function (response) {
        if (response.IsValid) {
            toastr.success(response.Message);
            statisticsModal.modal("hide");
        } else if (!response.IsValid) {
            toastr.warning(response.Message);
        }

    },
    saveStatistics = function () {
        var data = $("#athlete-statistics-form").serialize();
        gymHub.dataService.saveStatistics(data, saveStatisticsCallback);
    };

    var getInactiveAthletesCallback = function (response) {
        athletesCheckInModal.html(response);
        athletesCheckInModal.modal("show");
    },
    getInactiveAthletes = function () {
        gymHub.dataService.getInactiveAthletes(getInactiveAthletesCallback);
    };

    return {
        init: init,
        editStatistics: editStatistics,
        saveStatistics: saveStatistics,
        getInactiveAthletes: getInactiveAthletes
    };

}();

$(function () {

    gymHub.workoutOfTheDay.init();

    $("#athletes-table").on("click", ".edit-statistics", function () {
        gymHub.workoutOfTheDay.editStatistics($(this));
    });


    $("#athlete-statistic-modal").on("click", "#save-athlete-statistic", function () {
        gymHub.workoutOfTheDay.saveStatistics();
    });


    $("#athlete-checkin").on("click", function () {
        gymHub.workoutOfTheDay.getInactiveAthletes();
    });

})