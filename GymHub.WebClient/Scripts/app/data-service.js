var gymHub = gymHub || {};

gymHub.dataService = function () {
    var baseUrl = $("body").data("route-url");

    var getRequest = "GET";
    var postRequest = "POST";
    var editStatisticsUrl = "Statistics/AthleteStatistics";
    var saveStatisticsUrl = editStatisticsUrl;
    var logErrorUrl = "Error/LogJavaScriptError";
    var editDietUrl = "Diet/AthleteDiet";
    var getInactiveAthletesUrl = "WorkoutOfTheDay/InactiveAthletes";
    var checkinAthleteUrl = "api/CheckIn";

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

    var editStatistics = function (athleteId, callback) {
        performAjaxRequest(getRequest, editStatisticsUrl, { athleteId: athleteId }, callback);
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

    var editDiet = function (athleteId, callback) {
        performAjaxRequest(getRequest, editDietUrl, { athleteId: athleteId }, callback);
    };

    var uploadDiet = function ($dietUploadForm, uploadOptions) {
        $dietUploadForm.ajaxSubmit(uploadOptions);
    };

    var getInactiveAthletes = function (callback) {
        performAjaxRequest(getRequest, getInactiveAthletesUrl, {}, callback);
    };

    var checkinAthlete = function (athleteId, callback) {
        performAjaxRequest(postRequest, checkinAthleteUrl, { '': athleteId }, callback);
    };


    return {
        editStatistics: editStatistics,
        saveStatistics: saveStatistics,
        logJavascriptError: logJavascriptError,
        editDiet: editDiet,
        uploadDiet: uploadDiet,
        getInactiveAthletes: getInactiveAthletes,
        checkinAthlete: checkinAthlete
    };
}();