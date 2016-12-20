//**************************************************************************************************************************************************************************//
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
    $("#divAddEventExpenseDetails").load("/Events/GetEventExpenseDetailByID/",
        { ExpenseDetailID: expenseDetailID, EventID: eventID },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divAddEventExpenseDetail and hide the others --//
                showAddEventExpenseDetail();
                if (paymentCollectionID > 0) {
                    $("#BtnSaveEventExpenseDetail_EED").val("Edit Expense Detail");
                    $("#LblExpenseDetailHeader").text("Edit Expense Detail");
                }
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.");
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
                if (data == "True") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Expense Detail ID " + expenseDetailID + " and its details are deleted successfully.", "green");
                    GetAllEventExpenseDetails();
                }
                else if (data == "False")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected Expense Detail item. Please try again later.", "red");
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

    if ((expenseDetail).length > 100) {
        GeneralWarningsAndErrorDialog("Expense Details too long...", "Expense Detail should not exceed 100 characters.", "red");
    }
    else if (expenseDate == "") {
        GeneralWarningsAndErrorDialog("Invalid Expense Date...", "Please enter a valid Expense Date.", "red");
    }
    else if (Math.round(amount) == 0) {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Amount should be more than zero.", "red");
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


//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//%%%%%%%%%%%%%%%%%%% MANAGE EVENT EXPENSE DETAILS %%%%%%%%%%%%%%%%%%%//

//--- Function triggers when "Save" Button in AddEventExpenseDetail Page is clicked ---//
$(document).on("click", "#BtnSaveEventExpenseDetail_EED", function () {
    AddEventExpenseDetail();
});

//--- Function triggers when "Add New Payment Collection" Link in ViewEventPaymentCollection Page is clicked ---//
//$(document).on("click", "#LnkAddNewEventPayment_EPC", function () {
//    showAddEventPaymentCollection();
//    $("#BtnSaveEventPaymentCollection_EPC").val("Add Payment Collection");
//    $("#LblPaymentCollectionHeader").text("Add Payment Collection");
//});

//--- Function triggers when "Back to All Events" Link in AddEventExpenseDetail Page is clicked ---//
$(document).on("click", "#BtnCancelAddUpdate_EED", function () {
    showViewEventExpenseDetail();
});



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PAGES *********************************************************************//
//**************************************************************************************************************************************************************************//

//%%%%%%%%%%%%%%%%%%% MANAGE EVENT EXPENSE DETAILS %%%%%%%%%%%%%%%%%%%//

//--- This function shows and hides each partial view based on the sub menu selected by the user ---//
function showViewEventExpenseDetail() {
    $("#divViewEventExpenseDetail").fadeIn(1000);
    $("#divAddEventExpenseDetail").hide();
    $("#TblViewEventExpenseDetails_EED").DataTable();
}

function showAddEventExpenseDetail() {
    $("#divViewEventExpenseDetails").hide();
    $("#divAddEventExpenseDetail").fadeIn(1000);
    //GetEventPaymentCollectionByID(0);
}






