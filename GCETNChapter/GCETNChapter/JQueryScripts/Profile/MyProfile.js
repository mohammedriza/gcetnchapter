$(function () {
    $("#divMyProfilePage").fadeIn(1000);

    //-- Update Selected Link Style to "My Profile" link (Underline) --//
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkDonations").removeClass("menuitemSelected");
    $("#LnkManageAccess").removeClass("menuitemSelected");
    $("#LnkAdvertisements").removeClass("menuitemSelected");
    $("#LnkMyProfile").addClass("menuitemSelected");

    MyProfileSelectorCss();
})

//-- Ajax Load Method to pull data from the controller, using the username parsed to the controller, to load the partial view --//
function GetProfileLoginAndPersonalInfo() {
    var requestUser = $("#LblProfileOwnerUsername").text();

    $("#divLoginAndPersonalInfo").load("/MemberProfile/GetProfileLoginAndPersonalInfo/",
        { RequestUser: requestUser },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show Login and Personal Info panel and hide the others --//
                ShowdivLoginAndPersonalInfo();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("ERROR", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
                //alert("Failed to load data. Please try again later. \n\n Error Description : " + xhr.status + ": " + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the username parsed to the controller, to load the partial view --//
function GetProfileContactInformation() {
    var requestUser = $("#LblProfileOwnerUsername").text();

    $("#divContactInfo").load("/MemberProfile/GetProfileContactInformation/",
        { RequestUser: requestUser },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivContactInfo();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("ERROR", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
                //alert("Failed to load data. Please try again later. \n\n Error Description : " + xhr.status + ": " + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the username parsed to the controller, to load the partial view --//
function GetProfileAddressInformation() {
    var requestUser = $("#LblProfileOwnerUsername").text();

    $("#divAddressInfo").load("/MemberProfile/GetProfileAddressInformation/",
        { RequestUser: requestUser },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivAddressInfo();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("ERROR", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
                //alert("Failed to load data. Please try again later. \n\n Error Description : " + xhr.status + ": " + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the username parsed to the controller, to load the partial view --//
function GetProfileCollegeInformation() {
    var requestUser = $("#LblProfileOwnerUsername").text();

    $("#divCollegeInfo").load("/MemberProfile/GetProfileCollegeInformation/",
        { RequestUser: requestUser },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivCollegeInfo();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("ERROR", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
                //alert("Failed to load data. Please try again later. \n\n Error Description : " + xhr.status + ": " + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the username parsed to the controller, to load the partial view --//
function GetProfileWorkplaceAndExpertiseInfo() {
    var requestUser = $("#LblProfileOwnerUsername").text();

    $("#divWorkplaceAndExpertiseInfo").load("/MemberProfile/GetProfileWorkplaceAndExpertiseInfo/",
        { RequestUser: requestUser },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivWorkplaceAndExpertiseInfo();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("ERROR", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
                //alert("Failed to load data. Please try again later. \n\n Error Description : " + xhr.status + ": " + xhr.statusText);
            }
        });
}

//function GetProfileContactInformation() {
//    //-- Call method to show Login and Personal Info panel and hide the others --//
//    ShowdivContactInfo();

//    //-- Ajax call to pull data from the controller, using the session["username"], to load the partial view --//
//    $.ajax({
//        url: "/MemberProfile/GetProfileContactInformation/",
//        type: "GET",
//        success: function (result) {
//            $("#divContactInfo").load("/MemberProfile/GetProfileContactInformation/");
//        },
//        error: function (xhr, status, error) {
//            alert("FAIL \n" + error + "\n" + xhr.responseText);
//        }
//    });
//}


function UpdatePersonalAndLoginInfo() {
    var username = $("#TxtUsername").val();
    var fullName = $("#TxtFullName").val();
    var gender = $("#DDLGender").val();
    var dOB = $("#TxtDOB").val();
    var profileImg = $("#TxtProfileImage").val();
    var password = $("#TxtPassword").val();
    var confirmPassword = $("#TxtConfirmPassword").val();

    if (password != confirmPassword)
        GeneralWarningsAndErrorDialog("ALERT...", "Password and Confirm Password should be match.", "red");
    else if (fullName == "" || dOB == "" || password == "" || confirmPassword == "")
        GeneralWarningsAndErrorDialog("ALERT...", "Please make sure all mandatory fields are filled with data.", "red");
    else if (gender == "-- Select Gender --")
        GeneralWarningsAndErrorDialog("ALERT...", "Please select a valid Gender", "red");
    else {
        $.ajax({
            url: "/MemberProfile/UpdatePersonalAndLoginInfo/",
            type: "POST",
            data: {
                Username: username,
                Password: password,
                FullName: fullName,
                Gender: gender,
                DateOfBirth: dOB,
                ProfileImage: profileImg
            },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Changes successfully saved.", "green");
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to save Changes. Please try again later.", "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("ERROR", "Error Description: " + error + "\n" + xhr.responseText, "red");
            }
        });
    }
}


function UpdateProfileAddressInformation() {
    var requestUser = $("#LblProfileOwnerUsername").text();
    var currentAddress = $("#TxtCurrentAddress").val();
    var currentCountry = $("#DDLCurrentCountry").val();
    var permanentAddress = $("#TxtPermanentAddress").val();
    var permanentCountry = $("#DDLPermanentCountry").val();

    if (currentAddress == "" || permanentAddress == "")
        GeneralWarningsAndErrorDialog("ALERT...", "Please fill in both Current and Permanent Address fields.", "red");
    else if (currentCountry == "-- Select Country --" || permanentCountry == "-- Select Country --")
        GeneralWarningsAndErrorDialog("ALERT...", "Please select a valid Country.", "red");
    else {
        $.ajax({
            url: "/MemberProfile/UpdateProfileAddressInformation/",
            type: "POST",
            data: {
                Username: requestUser,
                CurrentAddress: currentAddress,
                CurrentCountry: currentCountry,
                PermanentAddress: permanentAddress,
                PermanentCountry: permanentCountry
            },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Changes successfully saved.", "green");
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to save Changes. Please try again later.", "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("ERROR", "Error Description: " + error + "\n" + xhr.responseText, "red");
            }
        });
    }
}


function UpdateProfileCollegeInformation() {
    var requestUser = $("#LblProfileOwnerUsername").text();
    var collegeRegNo = $("#TxtCollegeRegNo").val();
    var batch = $("#DDLBatch").val();
    var branch = $("#DDLBranch").val();
    var engDescipline = $("#TxtEngDescipline").val();

    if (collegeRegNo == "")
        GeneralWarningsAndErrorDialog("ALERT...", "Please enter a valid College Registration Number.", "red");
    else if (batch == "-- Select Batch --")
        GeneralWarningsAndErrorDialog("ALERT...", "Please select a valid Batch.", "red");
    else if (branch == "-- Select Branch --")
        GeneralWarningsAndErrorDialog("ALERT...", "Please select a valid Branch.", "red");
    else {
        $.ajax({
            url: "/MemberProfile/UpdateProfileCollegeInformation/",
            type: "POST",
            data: {
                Username: requestUser,
                CollegeRegistrationNo: collegeRegNo,
                Batch: batch,
                Branch: branch,
                EngineeringDescipline: engDescipline
            },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Changes successfully saved.", "green");
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to save Changes. Please try again later.", "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("ERROR", "Error Description: " + error + "\n" + xhr.responseText, "red");
            }
        });
    }
}


function UpdateProfileContactInformation() {
    var requestUser = $("#LblProfileOwnerUsername").text();
    var primaryContactNo = $("#TxtPrimaryContactNo").val();
    var contactNoIndia = $("#TxtContactNoIndia").val();
    var whatsappNumber = $("#TxtWhatsappNumber").val();
    var email = $("#TxtEmail").val();

    if (primaryContactNo == "" || email == "")
        GeneralWarningsAndErrorDialog("ALERT...", "Please make sure all mandatory fields are filled with data.", "red");
    else if (!isValidEmailAddress(email))
        GeneralWarningsAndErrorDialog("ALERT...", "Please enter a valid email address.", "red");
    else {
        $.ajax({
            url: "/MemberProfile/UpdateProfileContactInformation/",
            type: "POST",
            data: {
                Username: requestUser,
                PrimaryContactNo: primaryContactNo,
                ContactNoIndia: contactNoIndia,
                WhatsappNumber: whatsappNumber,
                Email: email
            },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Changes successfully saved.", "green");
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to save Changes. Please try again later.", "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("ERROR", "Error Description: " + error + "\n" + xhr.responseText, "red");
            }
        });
    }
}

function UpdateProfileWorkplaceAndExpertiseInfo() {
    var requestUser = $("#LblProfileOwnerUsername").text();
    var company = $("#TxtCompany").val();
    var occupation = $("#TxtOccupation").val();
    var interests = $("#TxtInterests").val();
    var expertise1 = $("#TxtExpertise1").val();
    var expertise2 = $("#TxtExpertise2").val();
    var expertise3 = $("#TxtExpertise3").val();
    var expertise4 = $("#TxtExpertise4").val();
    var expertise5 = $("#TxtExpertise5").val();

    if (company == "")
        GeneralWarningsAndErrorDialog("ALERT...", "Please enter your Company Name to continue.", "red");
    else {
        $.ajax({
            url: "/MemberProfile/UpdateProfileWorkplaceAndExpertiseInfo/",
            type: "POST",
            data: {
                Username: requestUser,
                Company: company,
                Occupation: occupation,
                Interests: interests,
                Expertise1: expertise1,
                Expertise2: expertise2,
                Expertise3: expertise3,
                Expertise4: expertise4,
                Expertise5: expertise5,
            },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Changes successfully saved.", "green");
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to save Changes. Please try again later.", "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("ERROR", "Error Description: " + error + "\n" + xhr.responseText, "red");
            }
        });
    }
}





function ShowdivLoginAndPersonalInfo()
{
    $("#divLoginAndPersonalInfo").fadeIn(1000);
    $("#divWelcomeMessage").hide();
    $("#divContactInfo").hide();
    $("#divCollegeInfo").hide();
    $("#divAddressInfo").hide();
    $("#divWorkplaceAndExpertiseInfo").hide();
}

function ShowdivContactInfo()
{
    $("#divContactInfo").fadeIn(1000);
    $("#divWelcomeMessage").hide();
    $("#divLoginAndPersonalInfo").hide();
    $("#divCollegeInfo").hide();
    $("#divAddressInfo").hide();
    $("#divWorkplaceAndExpertiseInfo").hide();
}

function ShowdivCollegeInfo() {
    $("#divCollegeInfo").fadeIn(1000);
    $("#divWelcomeMessage").hide();
    $("#divLoginAndPersonalInfo").hide();
    $("#divContactInfo").hide();
    $("#divAddressInfo").hide();
    $("#divWorkplaceAndExpertiseInfo").hide();
}

function ShowdivAddressInfo() {
    $("#divAddressInfo").fadeIn(1000);
    $("#divWelcomeMessage").hide();
    $("#divLoginAndPersonalInfo").hide();
    $("#divContactInfo").hide();
    $("#divCollegeInfo").hide();
    $("#divWorkplaceAndExpertiseInfo").hide();
}

function ShowdivWorkplaceAndExpertiseInfo() {
    $("#divWorkplaceAndExpertiseInfo").fadeIn(1000);
    $("#divContactInfo").hide();
    $("#divWelcomeMessage").hide();
    $("#divLoginAndPersonalInfo").hide();
    $("#divCollegeInfo").hide();
    $("#divAddressInfo").hide();
}


function isValidEmailAddress(emailAddress) {
    var pattern = /^([a-z\d!#$%&"*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&"*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
};


//--- SHOW / HIDE MANAGE PROFILE AND VIEWUSERLIST PARTIAL VIEWS ---//
//*****************************************************************//

$(document).on("click", "#LnkManageMemberProfile", function () {
    $("#divManageProfile").hide();
    $("#divManageUsers").fadeIn(1000);
    $("#LblProfileHeaderText").text("Manage User & Profiles");
    $("#LblProfileOwnerUsername").text("");
    GetAllUserAccountDetails();
    ManageUsersSelectorCss();
});

$(document).on("click", "#LnkMyProfile", function () {
    ShowMyProfile();
    MyProfileSelectorCss();
});

function ShowMyProfile() {
    $("#divManageProfile").fadeIn(1000);
    $("#divManageUsers").hide();
    $("#LblProfileHeaderText").text("My Profile");
    $("#LblProfileOwnerUsername").text("");

    $("#divWelcomeMessage").fadeIn(1000);
    $("#divLoginAndPersonalInfo").hide();    
    $("#divContactInfo").hide();
    $("#divCollegeInfo").hide();
    $("#divAddressInfo").hide();
    $("#divWorkplaceAndExpertiseInfo").hide();
}


//--- CHANGE SUB HEADING HIGLIGHT COLOR WHEN A PARTICULAR SUB HEADING IS CLICKED ---//
function MyProfileSelectorCss() {
    $("#LnkMyProfile P").addClass("subHeadingSelector");
    $("#LnkManageMemberProfile P").removeClass("subHeadingSelector");
}

function ManageUsersSelectorCss() {
    $("#LnkMyProfile P").removeClass("subHeadingSelector");
    $("#LnkManageMemberProfile P").addClass("subHeadingSelector");
}

