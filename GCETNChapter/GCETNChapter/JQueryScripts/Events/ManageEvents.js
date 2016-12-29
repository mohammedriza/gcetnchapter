//**************************************************************************************************************************************************************************//
//******************************************************************** FUNCTIONS THAT MAKE BACKEND CALLS *******************************************************************//
//**************************************************************************************************************************************************************************//

//-- Call ViewEvents Partial View Method in Events Controller. This function loads data to the ViewEvents Table --//
function GetViewEventsPartialView() {
    $("#divViewEvents").load("/Events/ViewEvents/",
        {},
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEvents and hide the others --//
                showViewEventsTable();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}

//-- Call GetEventDetailsByEventID Partial View Method in Events Controller. This Loads data to the AddEvent view with Initialized data --//
function GetEventDetailsByEventID(eventID) {
    $("#divAddEvent").load("/Events/GetEventDetailsByEventID/",
        { EventID: eventID },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divAddEvents and hide the others --//
                showDivAddEvent();
                if (eventID > 0) {
                    //$("#BtnSaveAddEvent_AE").val("Edit Event");
                    $("#LblManageEventsHeader_AE").text("Edit Event Details");
                }
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


//--- Function to Delete Event - Calls DeleteEvent method in Event Controller ---//
function DeleteEvent(eventID)
{
    if (confirm("Are you sure you want to delete the Event ID " + eventID + "?. Please confirm. \n\nNOTE: Deleting an Event will delete all its details from the below tables too. \n\n - Event Payment Collection \n - Event Expense Details \n - Event Gallery")) {
        $.ajax({
            url: "/Events/DeleteEvent",
            type: "POST",
            data: { EventID: eventID },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Event ID " + eventID + " and all its details are deleted successfully.", "green");
                    GetViewEventsPartialView();
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the event. Please try again later.", "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.", "red");
            }
        });
    }
}


//--- Function Add New Event ---//
function AddNewEvent() {
    var eventID = $.trim($("#LblEventID").text());
    var eventName = $.trim($("#TxtEventName").val());
    var startDate = $.trim($("#TxtStartDate").val());
    var endDate = $.trim($("#TxtEndDate").val());
    var totalCollectedAmount = $.trim($("#TxtTotalCollectedAmount").val());
    var totalExpenseAmount = $.trim($("#TxtTotalExpenseAmount").val());

    if ((eventName).length > 100) {
        GeneralWarningsAndErrorDialog("Event Name is too long...", "Event Name should not be more than 100 characters.", "red");
    }
    else if (eventName == "" || startDate == "" || endDate == "" || totalCollectedAmount == "" || totalExpenseAmount == "") {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Please make sure all information are entered before the event is created.", "red");
    }
    else if (Math.round(totalCollectedAmount) == 0 || Math.round(totalExpenseAmount) == 0) {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Total Collection Amount or Total Expense Amount should be more than zeros.", "red");
    }
    else if (totalCollectedAmount.length > 16 || totalExpenseAmount.length > 16) {
        GeneralWarningsAndErrorDialog("Numeric Values are too long...", "Total Collection Amount or Total Expense Amount should be less than or equal to 16 digits.", "red");
    }
    else if (startDate > endDate) {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Start Date should be before the End Date.", "red");
    }
    else {
        $.ajax({
            url: "/Events/AddNewEvent",
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
                    GeneralWarningsAndErrorDialog("SUCCESS", "Event details updated successfully.", "green");
                    GetViewEventsPartialView();
                }
                else if (data == "False")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to create the event. Please try again later.", "red");
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.", "red");
            }
        });
    }
}


//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//--- Function triggers when "Save" Button in AddEvents Page is clicked ---//
$(document).on("click", "#BtnSaveAddEvent_AE", function () {
    AddNewEvent();
});

//--- Function triggers when "Add New Event" Link in ViewEvent Page is clicked ---//
$(document).on("click", "#LnkAddNewEvent_VE", function () {
    showDivAddEvent();
    GetEventDetailsByEventID();
});

//--- Function triggers when "Back to All Events" Link in AddEvent Page is clicked ---//
$(document).on("click", "#BtnCancelAddEvent_AE", function () {
    showViewEventsTable();
});



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PAGES *********************************************************************//
//**************************************************************************************************************************************************************************//

//--- This function shows and hides each partial view based on the sub menu selected by the user ---//
function showViewEventsTable() {
    //GetViewEventsPartialView();         //--- Load the Events Table with Data
    $("#divAddEvent").hide();
    $("#divViewEvents").fadeIn(1000);
    $("#TblViewEvents").DataTable();    //--- Convert the table to a Data Table    
}

function showDivAddEvent() {
    $("#divViewEvents").hide();
    $("#divAddEvent").fadeIn(1000);
}


