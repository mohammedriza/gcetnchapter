//--- Inital Page load FadeIn the body section ---//
$(function () {
    $('#divEventsPage').fadeIn(1000);
    $('#divViewAllEvents').fadeIn(1000);
});


//-- Call AddEvents Partial View in Events Controller --//
function GetAddEventPartialView() {
    $('#divAddEvent').load('/Events/GetEventPartial/',
        {},
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == 'success') {
                //-- Call method to show Login and Personal Info panel and hide the others --//
                ShowDivAddEvent();
            }
            else if (statusTxt == 'error') {
                GeneralWarningsAndErrorDialog('ERROR', 'Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.');
                //alert('Failed to load data. Please try again later. \n\n Error Description : ' + xhr.status + ': ' + xhr.statusText);
            }
        });
}




//--- This function shows and hides each partial view based on the sub menu selected by the user ---//
function ShowDivAddEvent() {
    $('#divViewAllEvents').fadeOut(100);
    $('#divAddEvent').fadeIn(1000);
    $('#divAddEventPaymentCollection').fadeOut(100);
    $('#divAddEventExpenseDetails').fadeOut(100);
    $('#divManageEventGallery').fadeOut(100);
}


$(document).ready(function () {
    $('#LnkViewAllEvents').click(function () {
        $('#divViewAllEvents').fadeIn(1000);
        $('#divAddEvent').fadeOut(100);
        $('#divAddEventPaymentCollection').fadeOut(100);
        $('#divAddEventExpenseDetails').fadeOut(100);
        $('#divManageEventGallery').fadeOut(100);
    });

    $('#LnkAddEvent').click(function () {
        $('#divViewAllEvents').fadeOut(100);
        $('#divAddEvent').fadeIn(1000);
        $('#divAddEventPaymentCollection').fadeOut(100);
        $('#divAddEventExpenseDetails').fadeOut(100);
        $('#divManageEventGallery').fadeOut(100);
    });

    $('#LnkAddEventPaymentCollection').click(function () {
        $('#divViewAllEvents').fadeOut(100);
        $('#divAddEvent').fadeOut(100);
        $('#divAddEventPaymentCollection').fadeIn(1000);
        $('#divAddEventExpenseDetails').fadeOut(100);
        $('#divManageEventGallery').fadeOut(100);
    });

    $('#LnkAddEventExpenseDetails').click(function () {
        $('#divViewAllEvents').fadeOut(100);
        $('#divAddEvent').fadeOut(100);
        $('#divAddEventPaymentCollection').fadeOut(100);
        $('#divAddEventExpenseDetails').fadeIn(1000);
        $('#divManageEventGallery').fadeOut(100);
    });

    $('#LnkManageEventGallery').click(function () {
        $('#divViewAllEvents').fadeOut(100);
        $('#divAddEvent').fadeOut(100);
        $('#divAddEventPaymentCollection').fadeOut(100);
        $('#divAddEventExpenseDetails').fadeOut(100);
        $('#divManageEventGallery').fadeIn(1000);
    });
});