
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
                $("#BtnAddNewuser").val("Modify User");

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
                if (data == "User Exist")
                    GeneralWarningsAndErrorDialog("ERROR", "The Username you entered already exist. Please use a different Username.", "red");
                else if (data == "CollegeRegNo Exist")
                    GeneralWarningsAndErrorDialog("ERROR", "The College Registration No you entered already exist. Please use a different College Registration No.", "red");
                else if (data == "Error")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to Add/Update User Account Details. Please try again later.", "red");
                else if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "User Account Details successfully Saved.", "green");
                    alert("NOTE: New Account creations with 'PENDING' Account Status, will always go through the approval process. Please approve the user so that the user can login to the member portal.");
                    GetAllUserAccountDetails();
                }
            },
            error: function () {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
            }
        });
    }
}


//--- Delete Existing User Account ---//
function DeleteUserAccount(v_username) {
    var username = v_username;

    if (username == "")
        GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
    else {
        $.ajax({
            url: "/MemberProfile/DeleteUserAccount/",
            type: "POST",
            data: { Username: username },
            success: function (data) {
                if (data == "ChildRecordsFound")
                    GeneralWarningsAndErrorDialog("ERROR", "The Username you entered already has child records created and cannot be deleted. Please change the Account Status to INACTIVE, to Deactivate this User Account.", "red");
                else if (data == "Error")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to the User Account Details. Please try again later.", "red");
                else if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "User Account Details successfully deleted.", "green");
                    GetAllUserAccountDetails();
                }
                else
                {
                    GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
                }
            },
            error: function () {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR", "An Expected Error had occured. Please try again later.", "red");
            }
        });
    }
}

//--- Modify User Profile Details ---//
function ModifyUserProfile(username)
{
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






//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//
//--- Show Add/UpdateUser View ---//
$(document).on("click", "#LnkCreateNewUser", function () {
    ShowAddUpdateUserView();
    $("#TxtUsername_Add").prop("disabled", false);  //--- Enable the Username Textbox when Adding a new user, else disable it ---//
    $("#BtnResetPassword_Add").addClass("hidden");  //--- Hide the Reset Password button when Adding a new User ---//
    $("#BtnAddNewuser").val("Create User");         //--- Set the button Vlaue to "Create User"
    $("#LblTransType").val("ADD");                  //--- Set Transcation Type to ADD when creating new User ---//
});

//--- Edit User Account Details ---//


//--- Cancel Add/UpdateUser View and return to ViewUserLIst View ---//
$(document).on("click", "#BtnCancel_Add", function () {
    ShowViewUserListView();
});

//--- Add/UpdateUser ---//
$(document).on("click", "#BtnAddNewuser", function () {
    CreateUpdateUserDetails();
});



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PARTIAL PAGES *************************************************************//
//**************************************************************************************************************************************************************************//
function ShowViewUserListView()
{
    $("#divViewUserList").fadeIn(1000);
    $("#TblViewUserList").DataTable();
    $("#divAddUpdateUser").hide();
}

function ShowAddUpdateUserView() {
    $("#divAddUpdateUser").fadeIn(1000);
    $("#divViewUserList").hide();
    //InitializeAddUpdateUserView();
}