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
    console.log("%cAny malicious scripts ran in the console with the intension of hacking thi site will store all your information including your IP, PC Name, Wireless Provider Details, etc. And necessary action will be taken towards the offender.", "color: red; font-size: 20px;");
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

//--- Show Access Denied Message in Modal Popup ---//
function ShowAccessDeniedMessage()
{
    GeneralWarningsAndErrorDialog("Access Denied...", "Sorry. You do not have access to perform this action. Please contact the systems administrator to request for access.", "red");
}


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