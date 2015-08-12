
(function () {

    $('#trainees-statistics-table').dataTable({
        responsive: true,
        "columnDefs": [{
            "orderable": false, "width": "4%", "targets": 0,

        }],
        "order": [[1, "asc"]]
    });
})();