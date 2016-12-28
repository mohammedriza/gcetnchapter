//**************************************************************************************************************************************************************************//
//******************************************************************** FUNCTIONS THAT MAKE BACKEND CALLS *******************************************************************//
//**************************************************************************************************************************************************************************//

//-- Call ViewEventPaymentCollections Partial View Method in Events Controller. This function loads data to the TblViewEventPatments_EPC Table --//
function GetAllEventPaymentCollections() {
    $("#divViewEventPaymentCollection").load("/Events/GetAllEventPaymentCollections/",
        { PaymentCollectionID: 0 },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEventPaymentCollection and hide the others --//
                showViewEventPaymentCollection();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}

//-- Call GetAllEventPaymentCollections Partial View Method in Events Controller --//
function GetEventPaymentCollectionByID(paymentCollectionID, eventID) {
    $("#divAddEventPaymentCollection").load("/Events/GetEventPaymentCollectionByID/",
        { PaymentCollectionID: paymentCollectionID, EventID: eventID },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divAddEventPaymentCollection and hide the others --//
                showAddEventPaymentCollection();
                if (paymentCollectionID > 0) {
                    $("#BtnSaveEventPaymentCollection_EPC").val("Edit Payment Collection");
                    $("#LblPaymentCollectionHeader").text("Edit Payment Collection");
                }
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


//--- Function to Delete Event Payment Collection - Calls DeleteEventPaymentCollection method in Event Controller ---//
function DeleteEventPaymentCollection(paymentCollectionID) {
    if (confirm("Are you sure you want to delete the Payment Collection ID " + paymentCollectionID + "?. Please confirm.")) {
        $.ajax({
            url: "/Events/DeleteEventPaymentCollection",
            type: "POST",
            data: { PaymentCollectionID: paymentCollectionID },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Payment Collection ID " + paymentCollectionID + " and its details are deleted successfully.", "green");
                    GetAllEventPaymentCollections();
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected Payment Collection item. Please try again later.", "red");
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


function GetEventIdByEventName_PaymentCollection(eventName) {
    $.ajax({
        url: "/Events/GetEventIdByEventName/",
        type: "GET",
        data: { EventName: eventName },
        success: function (data) {
            $("#LblEventID_EPC").text(data);
        },
        error: function () {
            $("#LblEventID_EPC").text("Failed to retreive Event ID");
        }
    })
}


//--- Function Add New Event Payment Collection ---//
function AddEventPaymentCollection() {
    var eventID = $.trim($("#LblEventID_EPC").text());
    var paymentCollectionID = $.trim($("#LblPaymentCollectionID_EPC").text());
    var collegeRegNo = $.trim($("#TxtCollegeRegNo_EPC").val());
    var paymentDate = $.trim($("#TxtPaymentDate_EPC").val());
    var amountReceived = $.trim($("#TxtAmountReceived_EPC").val());

    if (eventID == 0 || eventID == "")
    {
        GeneralWarningsAndErrorDialog("Select an Event from the list...", "Please select an Event from the Event Dropdown list.", "red");
    }
    else if ((collegeRegNo).length > 12) {
        GeneralWarningsAndErrorDialog("Invalid College Registration No...", "College Registration No should not be more than 12 characters.", "red");
    }
    else if (paymentDate == "") {
        GeneralWarningsAndErrorDialog("Invalid Payment Date...", "Please enter a valid Payment Date.", "red");
    }
    else if (collegeRegNo == "") {
        GeneralWarningsAndErrorDialog("Invalid College Registration No...", "Please enter a valid College Registration No.", "red");
    }
    else if (Math.round(amountReceived) == 0) {
        GeneralWarningsAndErrorDialog("Incomplete Information...", "Amount Received should be more than zero.", "red");
    }
    else {
        $.ajax({
            url: "/Events/AddEventPaymentCollection",
            type: "POST",
            data: {
                EventID: eventID,
                PaymentCollectionID: paymentCollectionID,
                CollegeRegistrationNo: collegeRegNo,
                PaymentDate: paymentDate,
                AmountReceived: amountReceived
            },
            success: function (data, result) {
                if (data == "True") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Payment Collection updated successfully.", "green");
                    GetAllEventPaymentCollections();
                }
                else if (data == "False")
                    GeneralWarningsAndErrorDialog("Invalid College Registration No.", "Please make sure the College Registration No you entered is valid.", "red");
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

//--- Function triggers when "Save" Button in AddEventPaymentCollection Page is clicked ---//
$(document).on("click", "#BtnSaveEventPaymentCollection_EPC", function () {
    AddEventPaymentCollection();
});

//--- Function triggers when "Add New Payment Collection" Link in ViewEventPaymentCollection Page is clicked ---//
$(document).on("click", "#LnkAddPaymentCollection_EPC", function () {
    showAddEventPaymentCollection();
    GetEventPaymentCollectionByID(0, 0);
    $("#BtnSaveEventPaymentCollection_EPC").val("Add Payment Collection");
    $("#LblPaymentCollectionHeader").text("Add Payment Collection");
});

//--- Function triggers when "Back to All Events" Link in AddEventPaymentCollection Page is clicked ---//
$(document).on("click", "#BtnCancelAddUpdate_EPC", function () {
    showViewEventPaymentCollection();
});

//--- When user selects a value from the EventName dropdown list ---//
$(document).on("change", "#DDLEventName_PaymentCollection", function () {
    var eventName = $.trim($("#DDLEventName_PaymentCollection").val());
    GetEventIdByEventName_PaymentCollection(eventName);
});


//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PAGES *********************************************************************//
//**************************************************************************************************************************************************************************//

//--- This function shows and hides each partial view based on the sub menu selected by the user ---//
function showViewEventPaymentCollection() {
    $("#divViewEventPaymentCollection").fadeIn(1000);
    $("#divAddEventPaymentCollection").hide();
    $("#TblViewEventPatments_EPC").DataTable();
}

function showAddEventPaymentCollection() {
    $("#divViewEventPaymentCollection").hide();
    $("#divAddEventPaymentCollection").fadeIn(1000);
}



