//--- FUNCTION TO SHOW DIALOG BOX FOR GENERAL WARNINGS AND ERRORS ---//
function GeneralWarningsAndErrorDialog(headerText, bodyText) {
    $('#GeneralWarningAndErrorModal').modal();

    $('#GeneralModalBodyText').text(bodyText);
    $('#GeneralModalHeaderText').text(headerText);
}
