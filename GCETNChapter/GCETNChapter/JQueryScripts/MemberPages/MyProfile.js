$(function () {
    $('#divMyProfilePage').fadeIn(1000);
})

//-- Ajax Load Method to pull data from the controller, using the session["username"], to load the partial view --//
function GetProfileLoginAndPersonalInfo() {
    $('#divLoginAndPersonalInfo').load('/MemberProfile/GetProfileLoginAndPersonalInfo/',
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == 'success') {
                //-- Call method to show Login and Personal Info panel and hide the others --//
                ShowdivLoginAndPersonalInfo();
            }
            else if (statusTxt == 'error') {
                alert('Failed to load data. Please try again later. \n\n Error Description : ' + xhr.status + ': ' + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the session["username"], to load the partial view --//
function GetProfileContactInformation() {
    $('#divContactInfo').load('/MemberProfile/GetProfileContactInformation/',
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == 'success') {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivContactInfo();
            }
            else if (statusTxt == 'error') {
                alert('Failed to load data. Please try again later. \n\n Error Description : ' + xhr.status + ': ' + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the session["username"], to load the partial view --//
function GetProfileAddressInformation() {
    $('#divAddressInfo').load('/MemberProfile/GetProfileAddressInformation/',
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == 'success') {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivAddressInfo();
            }
            else if (statusTxt == 'error') {
                alert('Failed to load data. Please try again later. \n\n Error Description : ' + xhr.status + ': ' + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the session["username"], to load the partial view --//
function GetProfileCollegeInformation() {
    $('#divCollegeInfo').load('/MemberProfile/GetProfileCollegeInformation/',
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == 'success') {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivCollegeInfo();
            }
            else if (statusTxt == 'error') {
                alert('Failed to load data. Please try again later. \n\n Error Description : ' + xhr.status + ': ' + xhr.statusText);
            }
        });
}


//-- Ajax Load Method to pull data from the controller, using the session["username"], to load the partial view --//
function GetProfileWorkplaceAndExpertiseInfo() {
    $('#divWorkplaceAndExpertiseInfo').load('/MemberProfile/GetProfileWorkplaceAndExpertiseInfo/',
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == 'success') {
                //-- Call method to show Contact Information panel and hide the others --//
                ShowdivWorkplaceAndExpertiseInfo();
            }
            else if (statusTxt == 'error') {
                alert('Failed to load data. Please try again later. \n\n Error Description : ' + xhr.status + ': ' + xhr.statusText);
            }
        });
}

//function GetProfileContactInformation() {
//    //-- Call method to show Login and Personal Info panel and hide the others --//
//    ShowdivContactInfo();

//    //-- Ajax call to pull data from the controller, using the session["username"], to load the partial view --//
//    $.ajax({
//        url: '/MemberProfile/GetProfileContactInformation/',
//        type: 'GET',
//        success: function (result) {
//            $('#divContactInfo').load('/MemberProfile/GetProfileContactInformation/');
//        },
//        error: function (xhr, status, error) {
//            alert('FAIL \n' + error + '\n' + xhr.responseText);
//        }
//    });
//}


function UpdatePersonalAndLoginInfo() {
    var fullName = $('#TxtFullName').val();
    var gender = $('#DDLGender').val();
    var dOB = $('#TxtDOB').val();
    var profileImg = $('#TxtProfileImage').val();
    var username = $('#TxtUsername').val();
    var password = $('#TxtPassword').val();
    var confirmPassword = $('#TxtConfirmPassword').val();    

    if (password != confirmPassword)
        alert('Password and Confirm Password should be match.');
    else if (fullName == '' || dOB == '' || password == '' || confirmPassword == '')
        alert('Please make sure all mandatory fields are filled with data.');
    else if (gender == '-- Select Gender --')
        alert('Please select a valid Gender');
    else {
        $.ajax({
            url: '/MemberProfile/UpdatePersonalAndLoginInfo/',
            type: 'POST',
            data: {
                Username: username,
                Password: password,
                FullName: fullName,
                Gender: gender,
                DateOfBirth: dOB,
                ProfileImage: profileImg,
                LastModifiedBy: username
            },
            success: function (data, result) {
                if (data == 'True')
                    alert('SUCCESS: Changes successfully saved.');
                else
                    alert('ERROR: Failed to save Changes. Please try again later.');
            },
            error: function (xhr, status, error) {
                alert('FAIL: \n' + error + '\n' + xhr.responseText);
            }
        })
    }
}


function UpdateProfileAddressInformation() {
    var username = $('#TxtUsername').val();
    var currentAddress = $('#TxtCurrentAddress').val();
    var currentCountry = $('#DDLCurrentCountry').val();
    var permanentAddress = $('#TxtPermanentAddress').val();
    var permanentCountry = $('#DDLPermanentCountry').val();

    if (currentAddress == '' || permanentAddress == '')
        alert('Please fill in both Current and Permanent Address fields.');
    else if (currentCountry == '-- Select Country --' || permanentCountry == '-- Select Country --')
        alert('Please select a valid Country');
    else {
        $.ajax({
            url: '/MemberProfile/UpdateProfileAddressInformation/',
            type: 'POST',
            data: {
                Username: username,
                CurrentAddress: currentAddress,
                CurrentCountry: currentCountry,
                PermanentAddress: permanentAddress,
                PermanentCountry: permanentCountry
            },
            success: function (data, result) {
                if (data == 'True')
                    alert('SUCCESS: Changes successfully saved.');
                else
                    alert('ERROR: Failed to save Changes. Please try again later.');
            },
            error: function (xhr, status, error) {
                alert('FAIL: \n' + error + '\n' + xhr.responseText);
            }
        })
    }
}


function UpdateProfileCollegeInformation() {
    var username = $('#TxtUsername').val();
    var collegeRegNo = $('#TxtCollegeRegNo').val();
    var batch = $('#DDLBatch').val();
    var branch = $('#DDLBranch').val();
    var engDescipline = $('#TxtEngDescipline').val();

    if (collegeRegNo == '')
        alert('Please enter a valid College Registration Number.');
    else if (batch == '-- Select Batch --')
        alert('Please select a valid Batch');
    else if (branch == '-- Select Branch --')
        alert('Please select a valid Branch');
    else {
        $.ajax({
            url: '/MemberProfile/UpdateProfileCollegeInformation/',
            type: 'POST',
            data: {
                Username: username,
                CollegeRegistrationNo: collegeRegNo,
                Batch: batch,
                Branch: branch,
                EngineeringDescipline: engDescipline
            },
            success: function (data, result) {
                if (data == 'True')
                    alert('SUCCESS: Changes successfully saved.');
                else
                    alert('ERROR: Failed to save Changes. Please try again later.');
            },
            error: function (xhr, status, error) {
                alert('FAIL: \n' + error + '\n' + xhr.responseText);
            }
        })
    }
}


function UpdateProfileContactInformation() {
    var username = $('#TxtUsername').val();
    var primaryContactNo = $('#TxtPrimaryContactNo').val();
    var contactNoIndia = $('#TxtContactNoIndia').val();
    var whatsappNumber = $('#TxtWhatsappNumber').val();
    var email = $('#TxtEmail').val();

    if (primaryContactNo == '' || email == '')
        alert('Please make sure all mandatory fields are filled with data.');
    else if (!isValidEmailAddress(email))
        alert('Please enter a valid email address.');
    else {
        $.ajax({
            url: '/MemberProfile/UpdateProfileContactInformation/',
            type: 'POST',
            data: {
                Username: username,
                PrimaryContactNo: primaryContactNo,
                ContactNoIndia: contactNoIndia,
                WhatsappNumber: whatsappNumber,
                Email: email
            },
            success: function (data, result) {
                if (data == 'True')
                    alert('SUCCESS: Changes successfully saved.');
                else
                    alert('ERROR: Failed to save Changes. Please try again later.');
            },
            error: function (xhr, status, error) {
                alert('FAIL: \n' + error + '\n' + xhr.responseText);
            }
        })
    }
}

function UpdateProfileWorkplaceAndExpertiseInfo() {
    var username = $('#TxtUsername').val();
    var company = $('#TxtCompany').val();
    var occupation = $('#TxtOccupation').val();
    var interests = $('#TxtInterests').val();
    var expertise1 = $('#TxtExpertise1').val();
    var expertise2 = $('#TxtExpertise2').val();
    var expertise3 = $('#TxtExpertise3').val();
    var expertise4 = $('#TxtExpertise4').val();
    var expertise5 = $('#TxtExpertise5').val();

    if (company == '')
        alert('Please enter your Company Name to continue.');
    else {
        $.ajax({
            url: '/MemberProfile/UpdateProfileWorkplaceAndExpertiseInfo/',
            type: 'POST',
            data: {
                Username: username,
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
                if (data == 'True') {
                    //alert('SUCCESS: Changes successfully saved.');
                    GeneralWarningsAndErrorDialog('SUCCESS', 'Changes successfully saved.');
                }
                else
                    alert('ERROR: Failed to save Changes. Please try again later.');
            },
            error: function (xhr, status, error) {
                alert('FAIL: \n' + error + '\n' + xhr.responseText);
            }
        })
    }

    $('#testModal').modal();
}





function ShowdivLoginAndPersonalInfo()
{
    $('#divLoginAndPersonalInfo').show('clip');
    $('#divWelcomeMessage').hide('clip');
    $('#divContactInfo').hide('clip');
    $('#divCollegeInfo').hide('clip');
    $('#divAddressInfo').hide('clip');
    $('#divWorkplaceAndExpertiseInfo').hide('clip');
}

function ShowdivContactInfo()
{
    $('#divContactInfo').show('clip');
    $('#divWelcomeMessage').hide('clip');
    $('#divLoginAndPersonalInfo').hide('clip');
    $('#divCollegeInfo').hide('clip');
    $('#divAddressInfo').hide('clip');
    $('#divWorkplaceAndExpertiseInfo').hide('clip');
}

function ShowdivCollegeInfo() {
    $('#divCollegeInfo').show('clip');
    $('#divWelcomeMessage').hide('clip');
    $('#divLoginAndPersonalInfo').hide('clip');
    $('#divContactInfo').hide('clip');
    $('#divAddressInfo').hide('clip');
    $('#divWorkplaceAndExpertiseInfo').hide('clip');
}

function ShowdivAddressInfo() {
    $('#divAddressInfo').show('clip');
    $('#divWelcomeMessage').hide('clip');
    $('#divLoginAndPersonalInfo').hide('clip');
    $('#divContactInfo').hide('clip');
    $('#divCollegeInfo').hide('clip');
    $('#divWorkplaceAndExpertiseInfo').hide('clip');
}

function ShowdivWorkplaceAndExpertiseInfo() {
    $('#divWorkplaceAndExpertiseInfo').show('clip');
    $('#divContactInfo').hide('clip');
    $('#divWelcomeMessage').hide('clip');
    $('#divLoginAndPersonalInfo').hide('clip');
    $('#divCollegeInfo').hide('clip');
    $('#divAddressInfo').hide('clip');
}


function isValidEmailAddress(emailAddress) {
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
};