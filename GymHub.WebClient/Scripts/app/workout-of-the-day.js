var gymHub = gymHub || {};

gymHub.workoutOfTheDay = function () {
    var statisticsModal = $('#trainee-statistic-modal');
    var baseUrl = $('body').data('route-url');
    var oTable;

    var initSignalr = function () {
        var clientHub = $.connection.activeTraineesHub;
        clientHub.client.broadcastMessage = function (message) {
            oTable.fnDraw();
        };
        $.connection.hub.start().done();
    };

    var initDataTables = function () {
        oTable = $('#trainees-table').DataTable({
            "processing": true,
            "serverSide": true,
            "ajax": baseUrl + "WorkoutOfTheDay/ActiveTraineesPaging",
            "responsive": true,
            "columnDefs": [
                { "orderable": false, "width": "4%", "targets": 0 }
            ],
            "order": [[1, "asc"]]
        });
    };

    var init = function () {
        initDataTables();
        initSignalr();
    };


    var editStatistics = function ($buttonClicked) {
        var traineeId = $buttonClicked.data('trainee-id');

        gymHub.dataService.editStatistics(traineeId, editStatisticsCallback);
    },
    editStatisticsCallback = function (response) {
        statisticsModal.html(response);
        statisticsModal.modal('show');
    };

    var saveStatistics = function () {
        var data = $('#trainee-statistics-form').serialize();
        gymHub.dataService.saveStatistics(data, saveStatisticsCallback);
    },
    saveStatisticsCallback = function (response) {
        if (response.IsValid) {
            toastr.success(response.Message);
            statisticsModal.modal('hide');
        } else if (!response.IsValid) {
            toastr.warning(response.Message);
        }

    };

    return {
        init: init,
        editStatistics: editStatistics,
        saveStatistics: saveStatistics
    };

}();

$(function () {

    gymHub.workoutOfTheDay.init();

    $('#trainees-table').on('click', '.edit-statistics', function () {
        gymHub.workoutOfTheDay.editStatistics($(this));
    });


    $('#trainee-statistic-modal').on('click', '#save-trainee-statistic', function () {
        gymHub.workoutOfTheDay.saveStatistics();
    });

})