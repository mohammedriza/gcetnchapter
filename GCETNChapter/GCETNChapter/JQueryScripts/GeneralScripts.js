//--- FUNCTION TO SHOW DIALOG BOX FOR GENERAL WARNINGS AND ERRORS ---//
function GeneralWarningsAndErrorDialog(headerText, bodyText, headerTextColor) {
    $('#GeneralWarningAndErrorModal').modal();

    $('#GeneralModalBodyText').text(bodyText);
    $('#GeneralModalHeaderText').text(headerText);

    if (headerTextColor == "green") {
        $('#GeneralModalHeaderText').addClass("text-success");
        $('#GeneralModalHeaderText').removeClass("text-danger");

        $("#ImgSuccess").show();
        $("#ImgError").hide();
    }
    else if (headerTextColor == "red") {
        $('#GeneralModalHeaderText').addClass("text-danger");
        $('#GeneralModalHeaderText').removeClass("text-success");

        $("#ImgSuccess").hide();
        $("#ImgError").show();
    }
}


//--- TOOLTIP FUNCTION ---//
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    console.log("%c>>> STOP...", "color: red; font-size: 50px;");
    console.log("%cAny malicious scripts ran in the console with the intension of hacking this site will store all your information including your IP, PC Name, Wireless Provider Details, etc. And necessary action will be taken towards the offender.", "color: red; font-size: 20px;");
});


//--- CHECK FOR ACCESS AUTHORIZATION STATUS ---//
function CheckForAccessAuthorization(value) {
    var result = "";
    $.ajax({
        url: ("/AccessManager/CheckForAccessAuthorization/"),
        data: {Value: value},
        type: "GET",
        async: false,
        cache: false,
        timeout: 30000,
        error: function () {
            return "False";
        },
        success: function (data) {
            result = data;
        }
    });
    return result;
}

//--- SHOW ACCESS DENIED MESSAGE IN MODAL POPUP ---//
function ShowAccessDeniedMessage()
{
    GeneralWarningsAndErrorDialog("Access Denied...", "Sorry. You do not have access to perform this action. Please contact the systems administrator to request for access.", "red");
}


//************************************************* DATE FORMAT VALIDATION FUNCTIONS ******************************************//
//*****************************************************************************************************************************//

// NOTE: For the Date Textbox, add "dateValue" in the class element. This function will pick the class element and initialize the field

//--- VALIDATE DATE FORMAT ---//
function ValidateDateFormat(dateValue) {
    dateValue = $.trim(dateValue);  // Trim the dateValue and remove all spaces

    if (dateValue.length > 10 || dateValue.length < 1) {
        GeneralWarningsAndErrorDialog("Invalid Date Format used...", "Please enter a valid date in the date field/s. Only MM/DD/YYYY date formats is accepted.", "red");
        return false;
    }
    else {
        var dateSplit = dateValue.split("/");
        var month = dateSplit[0];
        var day = dateSplit[1];
        var year = dateSplit[2];
        var currYear = new Date().getFullYear();

        if (day < 1 || day > 31 || month < 1 || month > 12 || year > currYear || year < 1960) {
            GeneralWarningsAndErrorDialog("Invalid Date Format used...", "Please enter a valid date in the date field/s. Only MM/DD/YYYY date formats is accepted.", "red");
            return false;
        }
        else {
            return true;
        }
    }
}

// FUNCTION THAT INITIALIZES THE DATE TEXTBOX AND TOOLTIP //
function DatePickerAndTooltipInit() {
    $('[data-toggle="tooltip"]').tooltip();

    //--- IF BROWSER IS "IE", THE SHOW JQUERY DATE PICKER ---//
    if (navigator.userAgent.match(/msie/i) || navigator.userAgent.match(/trident/i)) {
        $(".dateValue").datepicker({
            dateFormat: "mm/dd/yy"
        });

        $(".dateValue").attr("placeholder", "MM / DD / YYYY.");
        $(".dateValue").attr("maxlength", "10");
    }
}

//--- Executes the function once an Ajax call is completed ---//
$(document).ajaxComplete(function () {
    DatePickerAndTooltipInit();

    $("#TblAllMembers").DataTable();
});

//--- Executes the function once all elements in the page are loaded ---//
$(function () {
    DatePickerAndTooltipInit();
});

//***************************************************** END ******************************************************************//


//************ COLLEGE REGISTRATION NUMBER LOOKUP MODAL ************//
//******************************************************************//

//-- Call GetLookupForCollegeRegNo Method in Donations Controller to Load LookupCollegeRegNo Modal --//
function GetLookupForCollegeRegNo() {
    $("#divLookupCollegeRegNoModal").load("/Donations/GetLookupForCollegeRegNo/",
        {},
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //--- Do Nothing ---//
            }
            else if (statusTxt == "error") {
                alert(responseTxt);
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}

//--- Get the College Registration No from the Lookup modal and assign it to College Reg Number textbox ---//
function GetLookupValue(CollegeRegNo) {
    $("#TxtCollegeRegNo_Lookup").val(CollegeRegNo);
    $("#CollegeRegNoLookupModal").modal("hide");
}

//-- Show CollegeRegNoLookupModal when user clicks the LnkLookupCollegeRegNo Link
$(document).on("click", "#LnkLookupCollegeRegNo", function () {
    $("#CollegeRegNoLookupModal").modal();
    GetLookupForCollegeRegNo();
});

//************************* END *********************************//



//************ VALIDATE IF THE AMOUNT VIELD CONTAINS NON-NUMERIC VALUES ************//
//**********************************************************************************//

function ValidateIfNumeric(number) {
    if (!$.isNumeric(number)) {        
        alert("Please use only numeric values in the Amount fields, without any comma's, etc.");
        return false;
    }
    else {
        return true;
    }
}


//************************************** END **************************************//


//************ HOME MENU DROPDOWN MENU IN MEMBER HEADER MENU LINKS *****************//
//**********************************************************************************//
$(document).on("mouseover", "#LnkPublicMenuHome", function () {
    $("#PublicMenuDropdown").fadeIn(500);
});

$(document).on("click", this, function () {
    $("#PublicMenuDropdown").fadeOut(500);
});

//************************************** END **************************************//