var oTable;

(function () {
    var statisticsModal = $('#trainee-statistic-modal');
    var baseUrl = $('body').data('route-url');

    $('#trainees-table tfoot th').each(function () {
        var title = $('#example thead th').eq($(this).index()).text();
        //  $(this).html('<input type="text" placeholder="Search ' + title + '" />');
        $(this).html('<select><option value="1">First</option><option value="2">Second</option><option value="3">Third</option></select>');
    });

    oTable = $('#trainees-table').DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": baseUrl + "WorkoutOfTheDay/ActiveTraineesPaging",
        responsive: true,
        "columnDefs": [
            { "orderable": false, "width": "4%", "targets": 0 }
        ],
        "order": [[1, "asc"]]
    });


    //// Apply the search
    //oTable.columns().eq(0).each(function (colIdx) {
    //    $('input', oTable.column(colIdx).footer()).on('keyup change', function () {
    //        oTable
    //            .column(colIdx)
    //            .search(this.value)
    //            .draw();
    //    });
    //});

    $('#filter').on('click', function () {
        oTable.columns().eq(0).each(function (colIdx) {
            var $filterValue = $('select', oTable.column(colIdx).footer());
            oTable
                .column(colIdx)
                .search($filterValue.val());
        });

        oTable.draw();
    });

    // Signalr Init
    // Reference the auto-generated proxy for the hub.
    var clientHub = $.connection.activeTraineesHub;
    // Create a function that the hub can call back to display messages.
    clientHub.client.broadcastMessage = function (message) {
        oTable.fnDraw();
    };
    $.connection.hub.start().done();


    $('#trainees-table').on('click', '.edit-statistics', function () {
        var $buttonClicked = $(this);
        var traineeId = $buttonClicked.data('trainee-id');

        workoutHall.dataService.editStatistics(traineeId, editStatisticsCallback);
    });

    var editStatisticsCallback = function (response) {
        statisticsModal.html(response);
        statisticsModal.modal('show');
    };

    $('#trainee-statistic-modal').on('click', '#save-trainee-statistic', function () {
        var data = $('#trainee-statistics-form').serialize();
        workoutHall.dataService.saveStatistics(data, saveStatisticsCallback);
    });

    var saveStatisticsCallback = function (response) {
        if (response.IsValid) {
            toastr.success(response.Message);
            statisticsModal.modal('hide');
        } else if (!response.IsValid) {
            toastr.warning(response.Message);
        }

    };

})();