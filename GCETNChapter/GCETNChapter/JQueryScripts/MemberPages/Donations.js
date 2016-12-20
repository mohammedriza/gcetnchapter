$(function () {
    $("#divDonationDetailsPage").fadeIn(1000);
    GetAllDonatoinDetails();
    
    //-- Update Selected Link Style to "Donations" link (Underline) --//
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkDonations").addClass("menuitemSelected");
    $("#LnkManageAccess").removeClass("menuitemSelected");
    $("#LnkAdvertisements").removeClass("menuitemSelected");
    $("#LnkMyProfile").removeClass("menuitemSelected");
})


//-- Call GetAllDonatoinDetails Method in Donations Controller to Load View Donatoins Table --//
function GetAllDonatoinDetails() {
    $("#divViewAllDonations").load("/Donations/GetAllDonatoinDetails/",
        { },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divViewDonations and hide AddDonations --//
                ShowDivViewDonations();
            }
            else if (statusTxt == "error") {
                alert(responseTxt);
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


//-- Call GetAllDonatoinDetails Method in Donations Controller to Load View Donatoins Table --//
function GetDonatoinDetailsByDonationID(donationID) {
    $("#divAddDonations").load("/Donations/GetDonatoinDetailsByDonationID/",
        { DonationID: donationID },
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                //-- Call method to show divAddDonations and hide ViewDonations --//
                ShowDivAddDonations();
                $("#LblDonationsHeaderText").text("Edit Donation Details")
            }
            else if (statusTxt == "error") {
                alert(responseTxt);
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


//--- Function to Delete Donations - Calls DeleteDonations method in Donations Controller ---//
function DeleteDonations(donationID) {
    if (confirm("Are you sure you want to delete the selected Donation (ID: " + donationID + ")?. Please confirm.")) {
        $.ajax({
            url: "/Donations/DeleteDonations",
            type: "POST",
            data: { DonationID: donationID },
            success: function (data, result) {
                if (data == "True") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "Donation ID " + donationID + " and all its details are deleted successfully.", "green");
                    GetAllDonatoinDetails();
                }
                else if (data == "False")
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected Donation. Please try again later.", "red");
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.", "red");
            }
        });
    }
}



//**************************************************************************************************************************************************************************//
//************************************************************************ BUTTON/LINK CLICK EVENTS ************************************************************************//
//**************************************************************************************************************************************************************************//

//--- Show AddDontaionts section when "Add Donation" link is clicked ---//
$(document).on("click", "#LnkAddNewDonation", function () {
    ShowDivAddDonations();
    InitializeAdd();
});

//-- Show ViewDonations section when user cancels AddDonations view
$(document).on("click", "#LnkCancelAddNewDonation", function () {
    ShowDivViewDonations();
});



//**************************************************************************************************************************************************************************//
//********************************************************************** SHOW / HIDE DIV ELEMENT PAGES *********************************************************************//
//**************************************************************************************************************************************************************************//

function ShowDivViewDonations()
{
    $("#divViewAllDonations").fadeIn(1000);
    $("#TblViewDonations").DataTable();
    $("#divAddDonations").hide();
}

function ShowDivAddDonations()
{
    $("#divViewAllDonations").hide();
    $("#divAddDonations").fadeIn(1000);
}

function InitializeAdd()
{
    $("#LblDonationsHeaderText").text("Add Donation Details")

    $("#LblDonationID").text("New");
    $("#TxtCollegeRegNo").val("");
    $("#TxtPaymentReason").val("");
    $("#TxtPaymentDate").val("");
    $("#TxtPaymentStartDate").val("");
    $("#TxtPaymentEndDate").val("");
    $("#TxtAmount").val("");
}