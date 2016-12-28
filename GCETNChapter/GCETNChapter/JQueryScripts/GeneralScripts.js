//--- FUNCTION TO SHOW DIALOG BOX FOR GENERAL WARNINGS AND ERRORS ---//
function GeneralWarningsAndErrorDialog(headerText, bodyText, headerTextColor) {
    $('#GeneralWarningAndErrorModal').modal();

    $('#GeneralModalBodyText').text(bodyText);
    $('#GeneralModalHeaderText').text(headerText);

    if (headerTextColor == "green") {
        $('#GeneralModalHeaderText').addClass("text-success");
        $('#GeneralModalHeaderText').removeClass("text-danger");

        $("#ImgSuccess").show();
        $("#ImgError").hide();
    }
    else if (headerTextColor == "red") {
        $('#GeneralModalHeaderText').addClass("text-danger");
        $('#GeneralModalHeaderText').removeClass("text-success");

        $("#ImgSuccess").hide();
        $("#ImgError").show();
    }
}


//--- TOOLTIP FUNCTION ---//
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});


//--- CHECK FOR ACCESS AUTHORIZATION STATUS ---//
function CheckForAccessAuthorization(value) {
    var result = "";
    $.ajax({
        url: ("/AccessManager/CheckForAccessAuthorization/"),
        data: {Value: value},
        type: "GET",
        async: false,
        cache: false,
        timeout: 30000,
        error: function () {
            return "False";
        },
        success: function (data) {
            result = data;            
        }
    });
    return result;
}

//--- Show Access Denied Message in Modal Popup ---//
function ShowAccessDeniedMessage()
{
    GeneralWarningsAndErrorDialog("Access Denied...", "Sorry. You do not have access to perform this action. Please contact the systems administrator to request for access.", "red");
}