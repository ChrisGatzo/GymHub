var gymHub = gymHub || {};

gymHub.statistics = function () {

    var initDataTables = function () {
        $("#trainees-statistics-table").dataTable({
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

    return {
        init: init
    };

}();


$(function () {
    gymHub.statistics.init();
})