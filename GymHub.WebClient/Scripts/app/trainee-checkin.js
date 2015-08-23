var gymHub = gymHub || {};

gymHub.checkin = function () {
    var $selectedRow;
    var traineesCheckInModal = $("#trainees-checkin-modal");

    var toggleSelection = function ($rowSelected) {
        if ($rowSelected.hasClass("active")) {
            $rowSelected.removeClass("active");
        }
        else {
            $("#inactive-users-table").find("tr").removeClass("active");
            $rowSelected.addClass("active");
            return true;
        }

        return false;
    };

    var selectTrainee = function ($rowSelected) {
        var isSelected = toggleSelection($rowSelected);

        if (isSelected) {
            $selectedRow = $rowSelected;
        }
    };    

    var checkinTraineeCallback = function (response) {
        toastr.success(response);
        traineesCheckInModal.modal("hide");
    },
    checkinTrainee = function () {
        var traineeId = $selectedRow.data("trainee-id");

        gymHub.dataService.checkinTrainee(traineeId, checkinTraineeCallback);
    };

    return {
        selectTrainee: selectTrainee,
        checkinTrainee: checkinTrainee
    };
}();


$(function () {

    $("#trainees-checkin-modal").on("click", "tr", function () {
        gymHub.checkin.selectTrainee($(this));
    });

    $("#trainees-checkin-modal").on("click", "#checkin-trainee-btn", function () {
        gymHub.checkin.checkinTrainee($(this));
    });

});