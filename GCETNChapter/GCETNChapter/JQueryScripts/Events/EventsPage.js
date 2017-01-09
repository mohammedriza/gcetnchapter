//--- Inital Page load FadeIn the body section ---//
$(function () {
    $("#divEventsPage").fadeIn(1000);
    ShowDivManageEvents();         //--- Show DivManageEvents element and hide others ---//
    GetViewEventsPartialView(); //--- Load all events in the table ---//
    ManageEventsSelectorCss();

    //-- Update Selected Link Style to "Events" link (Underline) --//
    $("#LnkEvents").addClass("menuitemSelected");
    $("#LnkDonations").removeClass("menuitemSelected");
    $("#LnkManageAccess").removeClass("menuitemSelected");
    $("#LnkAdvertisements").removeClass("menuitemSelected");
    $("#LnkMyProfile").removeClass("menuitemSelected");
    $("#LnkCMA").removeClass("menuitemSelected");
});


function CheckIfValidCollegeRegNo()
{
    var collegeRegNo = $("#TxtCollegeRegNo_Lookup").val();

    if (collegeRegNo == "")
        GeneralWarningsAndErrorDialog("Invalid College Registration No.", "Please enter a valid College Registration No to validate.", "red");
    else {
        $.ajax({
            url: "/Events/CheckIfValidCollegeRegNo/",
            type: "GET",
            data: { CollegeRegNo: collegeRegNo },
            success: function (data) {
                if (data == "True") {
                    $("#LblValidateCollegeRegNo_EPC").text("The College Reg No is Valid...");
                    $("#LblValidateCollegeRegNo_EPC").addClass("text-success");
                    $("#LblValidateCollegeRegNo_EPC").removeClass("text-danger");                    
                }
                else if (data == "False") {
                    $("#LblValidateCollegeRegNo_EPC").text("The College Reg No is Invalid...");
                    $("#LblValidateCollegeRegNo_EPC").addClass("text-danger");
                    $("#LblValidateCollegeRegNo_EPC").removeClass("text-success");
                }
            },
            error: function (data) {
                GeneralWarningsAndErrorDialog("Unexpedted Error....", "failed to validate College Registration No. Please try again later.", "red");
            }
        });
    }
}


//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//%%%%%%%%%%%%%%%%%%% EVENTS MAIN PAGE NAVIGATION %%%%%%%%%%%%%%%%%%%//

//--- Function triggers when "Manage Events" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEvents_E", function () {
    ShowDivManageEvents();
    GetViewEventsPartialView();
    ManageEventsSelectorCss();
});

//--- Function triggers when "Manage Event Payment Collection" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEventPaymentCollection_E", function () {
    ShowDivManageEventPaymentCollection();
    GetAllEventPaymentCollections();
    ManageEventPaymentCollectionSelectorCss();
});

//--- Function triggers when "Manage Event Expense Details" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEventExpenseDetails_E", function () {
    ShowDivManageEventExpenseDetails();
    GetAllEventExpenseDetails();
    ManageEventExpenseDetailsSelectorCss();
});

//--- Function triggers when "Manage Event Gallery" Link in Events Page is clicked ---//
$(document).on("click", "#LnkManageEventGallery_E", function () {
    ShowDivManageEventGallery();
    GetEventGalleryPhotosByEventID();
    ManageEventGallerySelectorCss();
});


//--- CHANGE SUB HEADING HIGLIGHT COLOR WHEN A PARTICULAR SUB HEADING IS CLICKED ---//
function ManageEventsSelectorCss()
{
    $("#LnkManageEvents_E P").addClass("subHeadingSelector");
    $("#LnkManageEventPaymentCollection_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventExpenseDetails_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventGallery_E P").removeClass("subHeadingSelector");
}

function ManageEventPaymentCollectionSelectorCss() {
    $("#LnkManageEvents_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventPaymentCollection_E P").addClass("subHeadingSelector");
    $("#LnkManageEventExpenseDetails_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventGallery_E P").removeClass("subHeadingSelector");
}

function ManageEventExpenseDetailsSelectorCss() {
    $("#LnkManageEvents_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventPaymentCollection_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventExpenseDetails_E P").addClass("subHeadingSelector");
    $("#LnkManageEventGallery_E P").removeClass("subHeadingSelector");
}

function ManageEventGallerySelectorCss() {
    $("#LnkManageEvents_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventPaymentCollection_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventExpenseDetails_E P").removeClass("subHeadingSelector");
    $("#LnkManageEventGallery_E P").addClass("subHeadingSelector");
}



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PARTIAL PAGES *************************************************************//
//**************************************************************************************************************************************************************************//

function HideAllEventTabs()
{
    $("#divManageEvents").hide();
    $("#divManageEventPaymentCollection").hide();
    $("#divManageEventExpenseDetails").hide();
    $("#divManageEventGallery").hide();
}

function ShowDivManageEvents() {
    $("#divManageEvents").fadeIn(1000);
    $("#divManageEventPaymentCollection").hide();
    $("#divManageEventExpenseDetails").hide();
    $("#divManageEventGallery").hide();
}

function ShowDivManageEventPaymentCollection() {
    $("#divManageEvents").hide();
    $("#divManageEventPaymentCollection").fadeIn(1000);
    $("#divManageEventExpenseDetails").hide();
    $("#divManageEventGallery").hide();
}

function ShowDivManageEventExpenseDetails() {
    $("#divManageEvents").hide();
    $("#divManageEventPaymentCollection").hide();
    $("#divManageEventExpenseDetails").fadeIn(1000);
    $("#divManageEventGallery").hide();
}

function ShowDivManageEventGallery() {
    $("#divManageEvents").hide();
    $("#divManageEventPaymentCollection").hide();
    $("#divManageEventExpenseDetails").hide();
    $("#divManageEventGallery").fadeIn(1000);
}
