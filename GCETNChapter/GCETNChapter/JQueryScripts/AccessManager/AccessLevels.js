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


function AddNewAccessRole() {
    var accessRole = $("#TxtAccessRole_Add").val();

    if (accessRole == "") {
        GeneralWarningsAndErrorDialog("Invalid Access Role", "Please enter a valid access role to continue.", "red");
    }
    else {
        $.ajax({
            url: "/AccessManager/AddNewAccessRole/",
            type: "POST",
            data: { AccessRole: accessRole },
            success: function (data) {
                if (data == 200) {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Access Role successfully created. Close the modal and refresh the page to see the new Access Role in the dropdown and add required Access Levels.", "green");
                }
                else if (data == 400) {
                    GeneralWarningsAndErrorDialog("Access Role Already Exist...", "The Access Role you entered already exist. Please try again with a different Access Role.", "red");
                }
                else if (data == 401) {
                    ShowAccessDeniedMessage();
                }
                else {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to add the Access Role. Please try again later.", "red");
                }
            },
            error: function () {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
            }
        });
    }
}


//--- Delete Advertisement - Calls DeleteAdvertisement method in Event Controller ---//
function DeleteAccessRole() {
    var AccessRole = $("#DDLAccessRoleList").val();

    if (AccessRole == "-- Select Access Role --") {
        GeneralWarningsAndErrorDialog("WARNING", "Please select a valid Access Role to delete.", "red");
    }
    else {
        if (confirm("Are you sure you want to delete the selected Access Role?. Please confirm.")) {
            $.ajax({
                url: "/AccessManager/DeleteAccessRole",
                type: "POST",
                data: { AccessRole: AccessRole },
                success: function (data, result) {
                    if (data == "Success") {
                        //window.location.replace("/AccessManager/ManageAccess/");
                        GeneralWarningsAndErrorDialog("SUCCESS", "The selected Access Role is deleted successfully. Close the modal and refresh the page to see the updated list of Access Roles in the dropdown", "green");
                    }
                    else if (data == "Error") {
                        GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected Access Role. Please try again later.", "red");
                    }
                    else if(data.indexOf("Exception") >= 0)
                    {
                        GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", data, "red");
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
}


function AddUpdateAccessRights(accessID, grantAccess, accessRole) {

    if (accessRole == "-- Select Access Role --") {
        GeneralWarningsAndErrorDialog("ERROR", "Please select an Access Role from the dropdown to add Access Level.", "red");
    }
    else {
        $.ajax({
            url: "/AccessManager/AddUpdateAccessRights/",
            type: "POST",
            data: {
                AccessRole: accessRole,
                AccessID: accessID,
                GrantAccess: grantAccess
            },
            success: function (data) {
                if (data == "Error")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to add the Access Level to the selected Access Role. Please try again later.", "red");
                else if (data == "Success") {
                    GetAccessLevelsByUserRole();
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
                else {
                    GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
                }
            },
            error: function () {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
            }
        });
    }
}

//--- Get Selected Acceess Level Row and its values to Add AccessRights ---//
function GetSelectedRowAccessLevel() {
    $('#TblAccessLevels').find('tr').click(function () {
        //alert('You clicked row ' + ($(this).index() + 1));

        var accessID = $(this).find("#LblAccessID").text();
        var grantAccess = $(this).find("#ChboxGrantAccess").prop("checked");
        var accessRole = $("#DDLAccessRoleList").val();

        AddUpdateAccessRights(accessID, grantAccess, accessRole);
    });

}

//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//--- Get All Access Levels and load partial view when a User Role is selected from the dropdown ---//
$(document).on("change", "#DDLAccessRoleList", function () {
    GetAccessLevelsByUserRole();
});

//--- Open Add Access Role Modal ---//
$(document).on("click", "#LnkAddNewAccessRole", function () {
    $("#AddNewAccessRoleModal").modal();;
});

//--- Close Add Access Role Modal ---//
$(document).on("click", "#BtnCancel", function () {
    $("#AddNewAccessRoleModal").modal("hide");;
});

//--- Create New Access Role ---//
$(document).on("click", "#BtnCreateAccessRole", function () {
    AddNewAccessRole();
});

//--- Convert AccessRole to UpperCase when user keep typing ---//
$(document).on("change", "#TxtAccessRole_Add", function () {
    var value = $("#TxtAccessRole_Add").val();
    value = value.toUpperCase();
    $("#TxtAccessRole_Add").val(value);
});

//--- Delete New Access Role ---//
$(document).on("click", "#DeleteAccessRole", function () {
    DeleteAccessRole();
});
