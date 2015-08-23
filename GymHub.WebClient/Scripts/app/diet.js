var gymHub = gymHub || {};

gymHub.diet = function () {
    var $dietModal = $("#athlete-diet-modal");

    var initDataTables = function () {
        $("#athletes-diet-table").dataTable({
            "responsive": true,
            "columnDefs": [
                {
                    "orderable": false,
                    "width": "4%",
                    "targets": 0
                }
            ],
            "order": [[1, "asc"]]
        });
    };

    var init = function () {
        initDataTables();
    };

    var editDietCallback = function (response) {
        $dietModal.html(response);
        $dietModal.modal("show");
    },
    editDiet = function ($buttonClicked) {
        var athleteId = $buttonClicked.data("athlete-id");
        gymHub.dataService.editDiet(athleteId, editDietCallback);
    };

    var uploadOptions = {
        success: function (response) {
            if (response.IsValid) {
                toastr.success(response.Message);
            }
            else if (!response.IsValid) {
                toastr.warning(response.Message);
            }

            $("#attachment-file-input").val("");
            $("#Comment").val("");
        }
    };

    var saveDiet = function () {
        if ($("#attachment-file-input").val()) {
            var $dietUploadForm = $("#diet-upload-form");
            gymHub.dataService.uploadDiet($dietUploadForm, uploadOptions);
            return false;
        } else {
            toastr.warning(window.dictionary["cannotSubmitEmptyFile"]);
        }
    };

    return {
        init: init,
        saveDiet: saveDiet,
        editDiet: editDiet
    };

}();


$(function () {

    gymHub.diet.init();

    $("#athletes-diet-table").on("click", ".edit-diet", function () {
        gymHub.diet.editDiet($(this));
    });


    $("#athlete-diet-modal").on("click", "#save-diet", function () {
        gymHub.diet.saveDiet();
    });

});