
//-- Get user Account Details By Username --//
function GetUserAccountDetailsByUsername(username) {

    $("#divAddUpdateUser").load("/MemberProfile/GetUserAccountDetailsByUsername/",
        { Username: username },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewEventExpenseDetail and hide the others --//
                ShowAddUpdateUserView();
                $("#TxtUsername_Add").prop("disabled", true);       //--- Disable the Username Textbox when Updating user ---//
                $("#BtnResetPassword_Add").removeClass("hidden");   //--- Hide the Reset Password button when Adding a new User ---//
                $("#BtnAddNewuser").val("Update User");

                $("#TxtCollegeRegNo_Add").prop("disabled", true);   //-- Disable the Username Textbox when Updating user ---//
                $("#LblTransType").val("UPDATE");                   //--- Set Transcation Type to UPDATE when updating User ---//
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}

//--- Get ALl User Account Details ---//
function GetAllUserAccountDetails() {

    $("#divViewUserList").load("/MemberProfile/GetAllUserAccountDetails/",
        { },
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

//--- Create New User or Update Existing User ---//
function CreateUpdateUserDetails()
{
    var transType = $("#LblTransType").val();
    var username = $("#TxtUsername_Add").val();
    var password = $("#TxtPassword_Add").val();
    var confirmPass = $("#TxtConfirmPassword_Add").val();
    var collegeRegNo = $("#TxtCollegeRegNo_Add").val();
    var accessRole = $("#DDLAccessRole_Add").val();
    var accountStatus = $("#DDAccountStatus_Add").val();

    if(username == "" && transType == "ADD")
        GeneralWarningsAndErrorDialog("Invalid Username...", "Please enter a valid Username.", "red");
    else if(password == "" || confirmPass == "")
        GeneralWarningsAndErrorDialog("Invalid Password...", "Please enter a valid Password and/or Confirm Password.", "red");
    else if(password != confirmPass)
        GeneralWarningsAndErrorDialog("Password and Confirm Password does not match.", "Please make sure the Password and Confirm Password match.", "red");
    else if (collegeRegNo == "" && transType == "ADD")
        GeneralWarningsAndErrorDialog("Invalid College Registration No...", "Please enter a valid College Registration No.", "red");
    else if (accessRole == "-- Select Access Role --" || accountStatus == "-- Select Account Status --")
        GeneralWarningsAndErrorDialog("Invalid Access Role or Account Status", "Please select a Valid Access Role and Account Status.", "red");
    else
    {
        $.ajax({
            url: "/MemberProfile/CreateUpdateUserDetails/",
            type: "POST",
            data: {
                Username: username,
                Password: password,
                CollegeRegistrationNo: collegeRegNo,
                AccessRole: accessRole,
                AccountStatus: accountStatus,
                TransType: transType
            },
            success: function (data) {
                if (data == "User Exist") {
                    GeneralWarningsAndErrorDialog("ERROR", "The Username you entered already exist. Please use a different Username.", "red");
                }
                else if (data == "CollegeRegNo Exist") {
                    GeneralWarningsAndErrorDialog("ERROR", "The College Registration No you entered already exist. Please use a different College Registration No.", "red");
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to Add/Update User Account Details. Please try again later.", "red");
                }
                else if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "User Account Details successfully Saved.", "green");
                    alert("NOTE: New Account creations with 'PENDING' Account Status, will always go through the approval process. Please approve the user so that the user can login to the member portal.");
                    GetAllUserAccountDetails();
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function () {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
            }
        });
    }
}


//--- Delete Existing User Account ---//
function DeleteUserAccount(username) {
    if (username == "")
        GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
    else {
        if (confirm("Are you sure you want to delete the User " + username + "?. Please confirm.")) {
            $.ajax({
                url: "/MemberProfile/DeleteUserAccount/",
                type: "POST",
                data: { Username: username },
                success: function (data) {
                    if (data == "ChildRecordsFound") {
                        GeneralWarningsAndErrorDialog("ERROR", "The Username you entered already has child records created and cannot be deleted. Please change the Account Status to INACTIVE, to Deactivate this User Account.", "red");
                    }
                    else if (data == "Error") {
                        GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the User Account Details. Please try again later.", "red");
                    }
                    else if (data == "Success") {
                        GeneralWarningsAndErrorDialog("SUCCESS", "User Account Details successfully deleted.", "green");
                        GetAllUserAccountDetails();
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
}

//--- Modify User Profile Details ---//
function ModifyUserProfile(username) {
    $.get("/MemberProfile/ManageProfile/", { RequestUser: username },
        function (data, status) {
            if (status == "success") {
                ShowMyProfile();
                $("#LblProfileHeaderText").text("Manage Profile - ");
                $("#LblProfileOwnerUsername").text(username);
            }
            else if (status == "error") {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
            }
        });
}


//--- Reset Password by Admin ---//
function ResetPasswordByAdmin()
{
    var username = $("#TxtUsername_Add").val();

    $.ajax({
        url: "/MemberProfile/ResetPassword/",
        data: { Username: username },
        success: function (data) {
            if (data == "Success") {
                GeneralWarningsAndErrorDialog("SUCCESS", "Password reset to 'password123'. Please request the user to reset the password through the Member page at his/her first login.", "green");
                $("#TxtPassword_Add").val("password123");
                $("#TxtConfirmPassword_Add").val("password123");
            }
            else if (data == "NoUsername") {
                GeneralWarningsAndErrorDialog("WARNING", "Please enter a valid Username.", "red");
            }
            else
                GeneralWarningsAndErrorDialog("ERROR", "Failed to reset password at this moment. Please try again later.", "red");
        },
        error: function () {
            GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
        }
    });
}



//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//
//--- Show Add/UpdateUser View ---//
$(document).on("click", "#LnkCreateNewUser", function () {
    var returnVal = CheckForAccessAuthorization(119);
    if (returnVal == "True") {
        ShowAddUpdateUserView();
        $("#TxtUsername_Add").prop("disabled", false);  //--- Enable the Username Textbox when Adding a new user, else disable it ---//
        $("#TxtCollegeRegNo_Add").prop("disabled", false);  //--- Enable the Username Textbox when Adding a new user, else disable it ---//
        $("#BtnResetPassword_Add").addClass("hidden");  //--- Hide the Reset Password button when Adding a new User ---//
        $("#BtnAddNewuser").val("Create User");         //--- Set the button Value to "Create User"
        $("#LblTransType").val("ADD");                  //--- Set Transcation Type to ADD when creating new User ---//

        InitializeAddUserView();                        //--- Initialize the Add User View and clear all textboxes and set to default ---//
    }
    else if (returnVal == "False") {
        ShowAccessDeniedMessage();
    }
});

//--- Cancel Add/UpdateUser View and return to ViewUserLIst View ---//
$(document).on("click", "#BtnCancel_Add", function () {
    ShowViewUserListView();
});

//--- Add/UpdateUser ---//
$(document).on("click", "#BtnAddNewuser", function () {
    CreateUpdateUserDetails();
});

//--- Reset Password by Admin  ---//
$(document).on("click", "#BtnResetPassword_Add", function () {
    ResetPasswordByAdmin();
});



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PARTIAL PAGES *************************************************************//
//**************************************************************************************************************************************************************************//
function ShowViewUserListView()
{
    $("#divViewUserList").fadeIn(1000);
    $("#TblViewUserList").DataTable();
    $("#TblAllMembers").DataTable();
    $("#divAddUpdateUser").hide();

}

function ShowAddUpdateUserView() {
    $("#divAddUpdateUser").fadeIn(1000);
    $("#divViewUserList").hide();
    $("#divViewAllMembers").hide();
}

function InitializeAddUserView()
{
    $("#TxtUsername_Add").val("");
    $("#TxtPassword_Add").val("");
    $("#TxtConfirmPassword_Add").val("");
    $("#TxtCollegeRegNo_Add").val("");
    $("#DDLAccessRole_Add").val("-- Select Access Role --");
    $("#DDAccountStatus_Add").val("-- Select Account Status --");
}