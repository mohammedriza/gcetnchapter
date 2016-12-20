//--- FUNCTION TO SHOW DIALOG BOX FOR GENERAL WARNINGS AND ERRORS ---//
function GeneralWarningsAndErrorDialog(headerText, bodyText, headerTextColor) {
    $('#GeneralWarningAndErrorModal').modal();

    $('#GeneralModalBodyText').text(bodyText);
    $('#GeneralModalHeaderText').text(headerText);

    if (headerTextColor == "green") {
        $('#GeneralModalHeaderText').addClass("text-success");
        $('#GeneralModalHeaderText').removeClass("text-danger");
    }
    else if (headerTextColor == "red") {
        $('#GeneralModalHeaderText').addClass("text-danger");
        $('#GeneralModalHeaderText').removeClass("text-success");
    }
}


//--- TOOLTIP FUNCTION ---//
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
});
