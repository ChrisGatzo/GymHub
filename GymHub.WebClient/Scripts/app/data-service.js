var gymHub = gymHub || {};

gymHub.dataService = function () {
    var baseUrl = $('body').data('route-url');

    var getRequest = 'GET';
    var postRequest = 'POST';
    var editStatisticsUrl = 'Statistics/TraineeStatistics';
    var saveStatisticsUrl = editStatisticsUrl;
    var logErrorUrl = 'Error/LogJavaScriptError';
    var editDietUrl = 'Diet/TraineeDiet';

    $.ajaxSetup({ cache: false });

    var performAjaxRequest = function (type, url, data, callback) {
        window.IsAjaxLoaderEnabled = true;
        $.ajax({
            type: type,
            url: baseUrl + url,
            data: data,
            success: function (response) {
                window.IsAjaxLoaderEnabled = false;
                callback(response);
            }
        });
    };

    var editStatistics = function (traineeId, callback) {
        performAjaxRequest(getRequest, editStatisticsUrl, { traineeId: traineeId }, callback);
    };

    var saveStatistics = function (data, callback) {
        performAjaxRequest(postRequest, saveStatisticsUrl, data, callback);
    };

    var logJavascriptError = function (out) {
        $.ajax({
            type: postRequest,
            url: baseUrl + logErrorUrl,
            data: { message: out }
        });
    };

    var editDiet = function (traineeId, callback) {
        performAjaxRequest(getRequest, editDietUrl, { traineeId: traineeId }, callback);
    };

    var uploadDiet = function ($dietUploadForm, uploadOptions) {
        $dietUploadForm.ajaxSubmit(uploadOptions);
    };

    return {
        editStatistics: editStatistics,
        saveStatistics: saveStatistics,
        logJavascriptError: logJavascriptError,
        editDiet: editDiet,
        uploadDiet: uploadDiet
    };
}();