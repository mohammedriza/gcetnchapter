//--- Inital Page load FadeIn the body section ---//
$(function () {
    $("#divEventsPage").fadeIn(1000);
    GetViewEventsPartialView(); //--- Load all events in the table ---//
});


//**************************************************************************************************************************************************************************//
//******************************************************************** FUNCTIONS THAT MAKE BACKEND CALLS *******************************************************************//
//**************************************************************************************************************************************************************************//

//-- Call AddEvents Partial View Method in Events Controller --//
function GetViewEventsPartialView() {
    $("#divTableViewEvents").load("/Events/ViewEvents/",
        {},
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show Login and Personal Info panel and hide the others --//
                showViewEventsTable();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.");
            }
        });
}

//-- Call ViewEvents Partial View Method in Events Controller --//
function GetAddEventPartialView(eventID) {
    $("#divAddEvent").load("/Events/AddEvent/",
        { EventID: eventID },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show Login and Personal Info panel and hide the others --//
                showDivAddEvent();
                if (eventID > 0) {
                    $("#btnSaveAddEvent_AE").val("Update Event");
                    $("#LblDonatoinsHeaderText_AE").text("Update Event Details");
                }
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.");
            }
        });
}


//--- Function to Delete Event - Calls DeleteEvent method in Event Controller ---//
function DeleteEvent(eventID)
{
    //-- write code to delete event
}


//--- Function Add New Event ---//
function AddNewEvent()
{
    var eventID = $.trim($("#LblEventID").text());
    var eventName = $.trim($("#TxtEventName").val());
    var startDate = $.trim($("#TxtStartDate").val());
    var endDate = $.trim($("#TxtEndDate").val());
    var totalCollectedAmount = $.trim($("#TxtTotalCollectedAmount").val());
    var totalExpenseAmount = $.trim($("#TxtTotalExpenseAmount").val());
    
    if((eventName).length > 100)
    {
        GeneralWarningsAndErrorDialog("Event Name is too long...", "Event Name should not be more than 100 characters.");
    }
    else if(eventName == "" || startDate == "" || endDate == "" || totalCollectedAmount == "" || totalExpenseAmount == "")
    {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Please make sure all information are entered before the event is created.");
    }
    else if (Math.round(totalCollectedAmount) == 0 || Math.round(totalExpenseAmount) == 0)
    {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Total Collection Amount or Total Expense Amount should not contain zeros.");
    }
    else if(startDate > endDate)
    {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Start Date should be before the End Date.");
    }
    else
    {
        $.ajax({
            url: "/Events/AddEvents",
            type: "POST",
            data: {
                EventID: eventID,
                EventName: eventName,
                StartDate: startDate,
                EndDate: endDate,
                TotalCollectedAmount: totalCollectedAmount,
                TotalExpenseAmount: totalExpenseAmount
            },
            success: function (data, result) {
                if (data == "True") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Event created successfully.");
                    GetViewEventsPartialView();
                }
                else if (data == "False")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to created the event. Please try again later.");
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.");
            }
        });
    }
}


//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//--- Function triggers when "Manage Events" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEvents_E", function () {
    GetViewEventsPartialView();
});

//--- Function triggers when "Manage Event Payment Collection" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEventPaymentCollection_E", function () {
    ShowDivEventPaymentCollection();
});

//--- Function triggers when "Manage Event Expense Details" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEventExpenseDetails_E", function () {
    ShowDivEventExpenseDetails();
});

//--- Function triggers when "Manage Event Gallery" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEventGallery_E", function () {
    ShowDivEventGallery();
});


//--- Function triggers when "Save" Button in AddEvents Page is clicked ---//
$(document).on("click", "#btnSaveAddEvent_AE", function () {
    AddNewEvent();
});

//--- Function triggers when "Add New Event" Link in ViewEvent Page is clicked ---//
$(document).on("click", "#LnkAddNewEvent_VE", function () {
    showDivAddEvent();
    GetAddEventPartialView();
});

//--- Function triggers when "Back to All Events" Link in AddEvent Page is clicked ---//
$(document).on("click", "#LnkBackToALlEvents_AE", function () {
    showViewEventsTable();
});



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PAGES *********************************************************************//
//**************************************************************************************************************************************************************************//

//--- This function shows and hides each partial view based on the sub menu selected by the user ---//
function showViewEventsTable() {
    ShowDivManageEvents();
    $("#TblViewEvents").DataTable();
}

function showDivAddEvent() {
    $("#divTableViewEvents").hide();
    $("#divAddEvent").fadeIn(1000);
}

function ShowDivManageEvents() {
    $("#divAddEvent").hide();
    $("#divTableViewEvents").fadeIn(1000);

    $("#divTableEventPaymentCollection").hide();
    $("#divAddEventPaymentCollection").hide();

    $("#divAddEventExpenseDetails").hide();
    $("#divManageEventGallery").hide();
}

function ShowDivEventPaymentCollection()
{
    $("#divTableEventPaymentCollection").fadeIn(1000);
    $("#divAddEventPaymentCollection").hide();

    
    $("#divTableViewEvents").hide();
    $("#divAddEvent").hide();
    
    $("#divAddEventExpenseDetails").hide();
    $("#divManageEventGallery").hide();
}

function ShowDivEventExpenseDetails() {
    $("#divAddEventExpenseDetails").fadeIn(1000);

    $("#divTableViewEvents").hide();
    $("#divAddEvent").hide();

    $("#divTableEventPaymentCollection").hide();
    $("#divAddEventPaymentCollection").hide();

    $("#divManageEventGallery").hide();
}

function ShowDivEventGallery() {
    $("#divManageEventGallery").fadeIn(1000);

    $("#divTableViewEvents").hide();
    $("#divAddEvent").hide();

    $("#divTableEventPaymentCollection").hide();
    $("#divAddEventPaymentCollection").hide();

    $("#divAddEventExpenseDetails").hide();
}

