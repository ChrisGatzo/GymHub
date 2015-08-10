(function () {

    $(document).ajaxStart(function () {
        if (window.IsAjaxLoaderEnabled) {
            $('body').append('<div id="loader" class="ajax-loader-container">' +
                '<div class="ajax-loader">' +
                '</div>' +
                '</div>');
            $("body").css("overflow", "hidden");
        }
    });

    $(document).ajaxStop(function () {
        $('.ajax-loader-container').remove();
        $("body").css("overflow", "auto");
    });

    $(document).ajaxError(function (event, jqxhr, settings, exception) {
        if (jqxhr.responseJSON.error) {
            toastr.error(jqxhr.responseJSON.message);
            return;
        }

        //if (jqxhr.responseJSON == '_Logoff_' && jqxhr.status == "302") {
        //    top.document.location = '../Account/Logoff';
        //    return;
        //}

    });

})()