
//--- Get ALl User Account Details ---//
function GetAllMemberDetails() {

    $("#divViewAllMembers").load("/MemberProfile/GetAllMembers/",
        {},
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEventExpenseDetail and hide the others --//
                showViewAllMembersView();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


//--- View All Members ---//
$(document).on("click", "#LnkViewAllMembeers", function () {
    GetAllMemberDetails();
});

function showViewAllMembersView()
{
    $("#divManageProfile").hide();
    $("#divManageUsers").fadeIn(1000);

    $("#divViewUserList").hide();
    $("#divAddUpdateUser").hide();
    $("#divViewAllMembers").fadeIn(1000);

    $("#LblProfileHeaderText").text("View All Members");
    $("#LblProfileOwnerUsername").text("");

    ViewAllMembersSelectorCss();
    $("#TblAllMembers").DataTable();
}

$(function () {
    $("#TblAllMembers").DataTable();
});