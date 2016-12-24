
//-- Call GetAllEventGalleryDetails Method in Events Controller. This function loads data to the TblViewEventGallery_EG Table --//
function GetEventGalleryPhotosByEventID() {
    $("#LoginProgressModal").modal();    //--- Show Loading spinner when user selects an event Form the Dropdown LIst ---//

    var eventName = $("#DDLEventName_ViewGallery").val();

    $("#divViewEventGallery").load("/Events/GetEventGalleryPhotosByEventID/",
        { EventName: eventName },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEventGallery and hide the others --//
                showViewEventGallery();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });

    $("#LoginProgressModal").modal("hide");    //--- hide the Loading spinner ---//
}


//-- Call GetAddEventGalleryView Method to load AddImage view with initialized data --//
function GetAddEventGalleryView() {
    $("#divAddEventGallery").load("/Events/GetAddEventGalleryView/",
        {  },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divAddEventGallery and hide the others --//
                showAddEventGallery();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the site in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}

//--- Get Event ID and bind it to Event ID field in AddGallery Page ---//
function GetEventIdByEventName_EventGallery(eventName) {
    $.ajax({
        url: "/Events/GetEventIdByEventName/",
        type: "GET",
        data: { EventName: eventName },
        success: function (data) {
            $("#LblEventID_EG").text(data);
        },
        error: function () {
            $("#LblEventID_EG").text("Failed to retreive Event ID");
        }
    })
}


//--- Function Add Event Photos ---//
function AddEventGallery() {
    var eventID = $.trim($("#LblEventID_EG").text());
    var imageFile1 = $.trim($("#ImageFileUpload1").val());
    var imageFile2 = $.trim($("#ImageFileUpload2").val());
    var imageFile3 = $.trim($("#ImageFileUpload3").val());

    if (eventID == 0 || eventID == "") {
        GeneralWarningsAndErrorDialog("Select an Event from the list...", "Please select an Event from the Event Dropdown list.", "red");
    }
    else if ((imageFile1 == "" && imageFile3 == "" && imageFile3 == "")) {
        GeneralWarningsAndErrorDialog("No Imges Files to upload...", "Please include atleast 1 image file to upload.", "red");
    }
    else {
        $.ajax({
            url: "/Events/AddEventGallery",
            type: "POST",
            data: {
                EventID: eventID,
                Image1: imageFile1,
                Image2: imageFile2,
                Image3: imageFile3,
            },
            success: function (data, result) {
                if (data == "True") {
                    GeneralWarningsAndErrorDialog("SUCCESS...", "Event Photos uploaded successfully.", "green");
                    GetEventGalleryPhotosByEventID(eventID);
                }
                else if (data == "False")
                    GeneralWarningsAndErrorDialog("ERROR...", "Failed to upload event photos. Please try again later.", "red");
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.", "red");
            }
        });
    }
}


//--- Delete Event Photos - Calls DeleteEventPhoto method in Event Controller ---//
function DeleteEventPhoto(imageID) {
    if (confirm("Are you sure you want to delete the selected event photo (ID " + imageID + ")?. Please confirm.")) {
        $.ajax({
            url: "/Events/DeleteEventPhoto",
            type: "POST",
            data: { ImageID: imageID },
            success: function (data, result) {
                if (data == "True") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Selected event photo with ID " + imageID + " deleted successfully.", "green");
                    GetEventGalleryPhotosByEventID();
                }
                else if (data == "False")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected event Photo. Please try again later.", "red");
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.", "red");
            }
        });
    }
}


//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENT GALLERY *****************************************************************//
//**************************************************************************************************************************************************************************//

//--- Function triggers when "Save" Button is clicked ---//
$(document).on("click", "#BtnSaveEventGallery_EG", function () {
    AddEventGallery();
});

//--- Function triggers when "New Photo" Link is clicked ---//
$(document).on("click", "#LnkAddImageGallery_EG", function () {
    showAddEventGallery();
    GetAddEventGalleryView();
});

//--- Function triggers when "Cancel" button is clicked ---//
$(document).on("click", "#BtnCancelAddUpdate_EG", function () {
    showViewEventGallery();
});

//--- When user selects a value from the EventName dropdown list ---//
$(document).on("change", "#DDLEventName_EventGallery", function () {
    var eventName = $.trim($("#DDLEventName_EventGallery").val());
    GetEventIdByEventName_EventGallery(eventName);
});

//--- In ViewGallery page, When user selects an Event, get the Event ID to the Hidden Field ---//
$(document).on("change", "#DDLEventName_ViewGallery", function () {
    GetEventGalleryPhotosByEventID();
});




//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PAGES *********************************************************************//
//**************************************************************************************************************************************************************************//

//--- This function shows and hides each partial view based on the sub menu selected by the user ---//
function showViewEventGallery() {
    $("#divViewEventGallery").fadeIn(1000);
    $("#divAddEventGallery").hide();
    //$("#TblViewEventGallery_EG").DataTable();
}

function showAddEventGallery() {
    $("#divViewEventGallery").hide();
    $("#divAddEventGallery").fadeIn(1000);
}

