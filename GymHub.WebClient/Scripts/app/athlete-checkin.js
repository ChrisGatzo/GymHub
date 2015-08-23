var gymHub = gymHub || {};

gymHub.checkin = function () {
    var $selectedRow;
    var athletesCheckInModal = $("#athletes-checkin-modal");

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

    var selectAthlete = function ($rowSelected) {
        var isSelected = toggleSelection($rowSelected);

        if (isSelected) {
            $selectedRow = $rowSelected;
        }
    };    

    var checkinAthleteCallback = function (response) {
        toastr.success(response);
        athletesCheckInModal.modal("hide");
    },
    checkinAthlete = function () {
        var athleteId = $selectedRow.data("athlete-id");

        gymHub.dataService.checkinAthlete(athleteId, checkinAthleteCallback);
    };

    return {
        selectAthlete: selectAthlete,
        checkinAthlete: checkinAthlete
    };
}();


$(function () {

    $("#athletes-checkin-modal").on("click", "tr", function () {
        gymHub.checkin.selectAthlete($(this));
    });

    $("#athletes-checkin-modal").on("click", "#checkin-athlete-btn", function () {
        gymHub.checkin.checkinAthlete($(this));
    });

});