﻿//**************************************************************************************************************************************************************************//
//******************************************************************** FUNCTIONS THAT MAKE BACKEND CALLS *******************************************************************//
//**************************************************************************************************************************************************************************//

//-- Call GetAllEventExpenseDetails Method in Events Controller. This function loads data to the TblViewExpenseDetails_EPC Table --//
function GetAllEventExpenseDetails() {
    $("#divViewEventExpenseDetails").load("/Events/GetAllEventExpenseDetails/",
        { ExpenseDetailID: 0 },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEventExpenseDetail and hide the others --//
                showViewEventExpenseDetail();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}

//-- Call GetAllEventExpenseDetails Partial View Method in Events Controller --//
function GetEventExpenseDetailByID(expenseDetailID, eventID) {
    $("#divAddEventExpenseDetail").load("/Events/GetEventExpenseDetailByID/",
        { ExpenseDetailID: expenseDetailID, EventID: eventID },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divAddEventExpenseDetail and hide the others --//
                showAddEventExpenseDetail();
                if (expenseDetailID > 0) {
                    //$("#BtnSaveEventExpenseDetail_EED").val("Edit Expense Detail");
                    $("#LblExpenseDetailHeader").text("Edit Expense Detail");
                }
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


//--- Function to Delete Event Expense Detail - Calls DeleteEventExpenseDetail method in Event Controller ---//
function DeleteEventExpenseDetail(expenseDetailID) {
    if (confirm("Are you sure you want to delete the Expense Detail ID " + expenseDetailID + "?. Please confirm.")) {
        $.ajax({
            url: "/Events/DeleteEventExpenseDetail",
            type: "POST",
            data: { ExpenseDetailID: expenseDetailID },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Expense Detail ID " + expenseDetailID + " and its details are deleted successfully.", "green");
                    GetAllEventExpenseDetails();
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected Expense Detail item. Please try again later.", "red");
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


//--- Function Add New Event Expense Detail ---//
function AddEventExpenseDetail() {
    var eventID = $.trim($("#LblEventID_EED").text());
    var expenseDetailID = $.trim($("#LblExpenseDetailID_EED").text());
    var expenseDetail = $.trim($("#TxtExpenseDetail_EED").val());
    var expenseDate = $.trim($("#TxtExpenseDate_EED").val());
    var amount = $.trim($("#TxtAmount_EED").val());

    var DateValidation = ValidateDateFormat(expenseDate);
    var amountValidation = ValidateIfNumeric(amount);

    if (DateValidation == true && amountValidation == true) {

        if (eventID == 0 || eventID == "") {
            GeneralWarningsAndErrorDialog("Select an Event from the list...", "Please select an Event from the Event Dropdown list.", "red");
        }
        else if ((expenseDetail == "")) {
            GeneralWarningsAndErrorDialog("Invalid Expense Detail...", "Please enter a valid Expense Detail.", "red");
        }
        else if ((expenseDetail).length > 100) {
            GeneralWarningsAndErrorDialog("Expense Details too long...", "Expense Detail should not exceed 100 characters.", "red");
        }
        else if (expenseDate == "") {
            GeneralWarningsAndErrorDialog("Invalid Expense Date...", "Please enter a valid Expense Date.", "red");
        }
        else if (Math.round(amount) == 0) {
            GeneralWarningsAndErrorDialog("Incomplete Information...", "Amount should be more than zero.", "red");
        }
        else if (amount.length > 16) {
            GeneralWarningsAndErrorDialog("Numeric Values are too long...", "Amount should be less than or equal to 16 digits.", "red");
        }
        else {
            $.ajax({
                url: "/Events/AddEventExpenseDetail",
                type: "POST",
                data: {
                    EventID: eventID,
                    ExpenseDetailID: expenseDetailID,
                    ExpenseDetail: expenseDetail,
                    ExpenseDate: expenseDate,
                    Amount: amount
                },
                success: function (data, result) {
                    if (data == "True") {
                        GeneralWarningsAndErrorDialog("SUCCESS...", "Expense Detail updated successfully.", "green");
                        GetAllEventExpenseDetails();
                    }
                    else if (data == "False")
                        GeneralWarningsAndErrorDialog("ERROR...", "Failed to update selected Expense Detail item. Please try again later.", "red");
                },
                error: function (xhr, status, error) {
                    GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.", "red");
                }
            });
        }
    }
}


function GetEventIdByEventName_ExpenseDetails(eventName) {
    $.ajax({
        url: "/Events/GetEventIdByEventName/",
        type: "GET",
        data: { EventName: eventName },
        success: function (data) {
            $("#LblEventID_EED").text(data);
        },
        error: function () {
            $("#LblEventID_EED").text("Failed to retreive Event ID");
        }
    })
}


//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//--- Function triggers when "Save" Button in AddEventExpenseDetail Page is clicked ---//
$(document).on("click", "#BtnSaveEventExpenseDetail_EED", function () {
    AddEventExpenseDetail();
});

//--- Function triggers when "Add New Expense Detail" Link in ViewEventExpenseDetails Page is clicked ---//
$(document).on("click", "#LnkAddExpenseDetails_EED", function () {
    showAddEventExpenseDetail();
    GetEventExpenseDetailByID(0, 0);
    //$("#BtnSaveEventExpenseDetail_EED").val("Add Expense Details");
    $("#LblExpenseDetailsHeader").text("Add Expense Details");
});

//--- Function triggers when "Back to All Events" Link in AddEventExpenseDetail Page is clicked ---//
$(document).on("click", "#BtnCancelAddUpdate_EED", function () {
    showViewEventExpenseDetail();
});

//--- When user selects a value from the EventName dropdown list ---//
$(document).on("change", "#DDLEventName_ExpenseDetails", function () {
    var eventName = $.trim($("#DDLEventName_ExpenseDetails").val());
    GetEventIdByEventName_ExpenseDetails(eventName);
});



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PAGES *********************************************************************//
//**************************************************************************************************************************************************************************//

//--- This function shows and hides each partial view based on the sub menu selected by the user ---//
function showViewEventExpenseDetail() {
    $("#divViewEventExpenseDetails").fadeIn(1000);
    $("#divAddEventExpenseDetail").hide();
    $("#TblViewEventExpenseDetails_EED").DataTable();
}

function showAddEventExpenseDetail() {
    $("#divViewEventExpenseDetails").hide();
    $("#divAddEventExpenseDetail").fadeIn(1000);
}






