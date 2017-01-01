
//--- Get ALl User Account Details ---//
function GetAllMemberDetails() {

    $("#divViewUserList").load("/MemberProfile/GetAllMembers/",
        {},
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEventExpenseDetail and hide the others --//
                ShowViewUserListView();
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

$(function () {
    $("#TblAllMembers").DataTable();
});