
(function () {
    var $dietModal = $('#trainee-diet-modal');


    $('#trainees-diet-table').dataTable({
        responsive: true,
        "columnDefs": [{
            "orderable": false, "width": "4%", "targets": 0,

        }],
        "order": [[1, "asc"]]
    });

    $('#trainees-diet-table').on('click', '.edit-diet', function () {
        var $buttonClicked = $(this);
        var traineeId = $buttonClicked.data('trainee-id');

        workoutHall.dataService.editDiet(traineeId, editDietCallback);
    });

    var editDietCallback = function (response) {
        $dietModal.html(response);
        $dietModal.modal('show');
    };

    var uploadOptions = {
        success: function (response) {
            if (response.IsValid) {
                toastr.success(response.Message);
            }
            else if (!response.IsValid) {
                toastr.warning(response.Message);
            }

            $('#attachment-file-input').val('');
            $('#Comment').val('');
        }
    };

    $dietModal.on('click', '#save-diet', function () {
        if ($('#attachment-file-input').val()) {
            var $dietUploadForm = $('#diet-upload-form');
            workoutHall.dataService.uploadDiet($dietUploadForm, uploadOptions);
            return false;
        } else {
            toastr.warning(workoutHall.strings.cannotSubmitEmptyFile);
        }
    });

})();