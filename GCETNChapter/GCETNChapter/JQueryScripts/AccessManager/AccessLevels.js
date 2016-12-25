//--- Inital Page load FadeIn the body section ---//
$(function () {
    $("#divManageAccessPage").fadeIn(1000);
    //ShowDivManageEvents();         //--- Show DivManageEvents element and hide others ---//
    //GetViewEventsPartialView(); //--- Load all events in the table ---//

    //-- Update Selected Link Style to "Manage Access" link (Underline) --//
    $("#LnkManageAccess").addClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkDonations").removeClass("menuitemSelected");    
    $("#LnkAdvertisements").removeClass("menuitemSelected");
    $("#LnkMyProfile").removeClass("menuitemSelected");
});


//-- Get Access Levels by User Role selected by the User --//
function GetAccessLevelsByUserRole() {
    var accessRole = $("#DDLAccessRoleList").val();

    $("#divManageAccessLevels").load("/AccessManager/GetAccessLevelsByUserRole/",
        { AccessRole: accessRole },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEventExpenseDetail and hide the others --//
                //showViewEventExpenseDetail();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//--- Get All Access Levels and load partial view when a User Role is selected from the dropdown ---//
$(document).on("change", "#DDLAccessRoleList", function () {
    GetAccessLevelsByUserRole();
});

$(document).on("click", "#LnkAddNewAccessRole", function () {
    $("#AddNewAccessRoleModal").modal();;
});

$(document).on("click", "#BtnCancel", function () {
    $("#AddNewAccessRoleModal").modal("hide");;
});

