$(function () {
    $("#divAdvertisementPage").fadeIn(1000);
    GetAllAdvertisements();

    //-- Update Selected Link Style to "Donations" link (Underline) --//
    $("#LnkAdvertisements").addClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkDonations").removeClass("menuitemSelected");
    $("#LnkManageAccess").removeClass("menuitemSelected");
    $("#LnkMyProfile").removeClass("menuitemSelected");
})


function GetAllAdvertisements()
{
    $("#divViewAdvertisements").load("/Advertisement/GetAllAdvertisements/",
    { AdID: 0 },
    function (responseTxt, statusTxt, xhr) {
        if (statusTxt == "success") {
            ShowViewAdvertisementSection();
        }
        else if (statusTxt == "error") {
            GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
        }
    });
}


function GetAdvertisementByID(AdID) {
    $("#divAddAdvertisement").load("/Advertisement/GetAllAdvertisements/",
    { AdID: AdID },
    function (responseTxt, statusTxt, xhr) {
        if (statusTxt == "success") {
            ShowAddAdvertisementSection();
            ShowEditAdvertisementContent();
            $.trim($("#LblHiddenAdID").val(AdID));
        }
        else if (statusTxt == "error") {
            GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
        }
    });
}


//--- Delete Advertisement - Calls DeleteAdvertisement method in Event Controller ---//
function DeleteAdvertisement(AdID) {
    if (confirm("Are you sure you want to delete the selected Advertisement?. Please confirm.")) {
        $.ajax({
            url: "/Advertisement/DeleteAdvertisement",
            type: "POST",
            data: { AdID: AdID },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "The selected Advertisement is deleted successfully.", "green");
                    GetAllAdvertisements();
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected Advertisement. Please try again later.", "red");
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


function AddEditAdvertisements() {
    var AdID = $.trim($("#LblHiddenAdID").val());
    var Title = $.trim($("#TxtTitle").val());
    var Description = $.trim($("#TxtDescription").val());
    var Footer = $.trim($("#TxtFooter").val());
    var ImageFile = $.trim($("#ImgImageFile").val());
    var StartDate = $.trim($("#TxtStartDate").val());
    var ExpiryDate = $.trim($("#TxtExpiryDate").val());

    //var filename = ImageFile.split('\\').pop()

    if (Title == "" || Description == "" || ImageFile == "") {
        GeneralWarningsAndErrorDialog("ERROR...", "Title, Description and Image are mandatory. Please fill them to continue.", "red");
    }
    else if (StartDate > ExpiryDate) {
        GeneralWarningsAndErrorDialog("ERROR...", "Start Date should be prior to Expiry Date. Please enter a valid Start Date to continue.", "red");
    }
    else {
        var xhr = new XMLHttpRequest();
        var fd = new FormData();
        fd.append("AdvertisementID", AdID);
        fd.append("Title", Title);
        fd.append("Description", Description);
        fd.append("Footer", Footer);
        fd.append("StartDate", StartDate);
        fd.append("ExpiryDate", ExpiryDate);
        fd.append("file", document.getElementById('ImgImageFile').files[0]);

        xhr.open("POST", "/Advertisement/AddUpdateAdvertisements/", true);
        xhr.send(fd);
        xhr.addEventListener("load", function (event) {
            if (event.target.response != "Error" || event.target.response != "NoFiles") {
                GeneralWarningsAndErrorDialog("SUCCESS...", "Advertisement created successfully. See the preview for the full advertisement.", "green");
                InitializeAddAdvertisement();

                //--- Add the uploaded Image to Advertisement Preview section ---//
                $("#ImgAdvertisementImage").prop("src", "/_ImageUploads/Advertisements/" + event.target.response);
            }
            else if (event.target.response == "InvalidDate") {
                GeneralWarningsAndErrorDialog("ERROR...", "Start Date should be prior to Expiry Date. Please enter a valid Start Date to continue.", "red");
            }
            else if (event.target.response == "Error") {
                GeneralWarningsAndErrorDialog("ERROR...", "Failed to create Advertisement. Please try again later.", "red");
            }
            else if (event.target.response == "NoFiles") {
                GeneralWarningsAndErrorDialog("ERROR...", "Please select an Image to continue...", "red");
            }
        },
        false);
    }
}


function InitializeAddAdvertisement() {
    $.trim($("#TxtTitle").val(""));
    $.trim($("#TxtDescription").val(""));
    $.trim($("#TxtFooter").val(""));
    $.trim($("#ImgImageFile").val(""));
    $.trim($("#TxtStartDate").val(""));
    $.trim($("#TxtExpiryDate").val(""));
}


//--- Show Header Text in Preview Sectoin when typing ---//
$(document).on("input", "#TxtTitle", function () {
    var Title = $("#TxtTitle").val();
    $("#LblAdvertisementTitle").text(Title);
});

//--- Show Description Text in Preview Sectoin when typing ---//
$(document).on("input", "#TxtDescription", function () {
    var Description = $("#TxtDescription").val();
    $("#LblAdDescription").text(Description);
});

//--- Show All Advertisement Page ---//
$(document).on("click", "#LnkBackToAllAds", function () {
    GetAllAdvertisements();
});

//--- Show Add Advertisement Section ---//
$(document).on("click", "#LnkAddNewAdvertisement", function () {
    ShowAddAdvertisementSection();
});



//--- Upload Image to temp folder and Show in Preview Sectoin  ---//
$(document).on("change", "#ImgImageFile", function () {
    var ImageFile = $.trim($("#ImgImageFile").val());
    var filename = ImageFile.split('\\').pop()

    var xhr = new XMLHttpRequest();
    var fd = new FormData();
    fd.append("file", document.getElementById('ImgImageFile').files[0]);

    xhr.open("POST", "/Advertisement/UploadAdImageTempForPreview/", true);
    xhr.send(fd);
    xhr.addEventListener("load", function (event) {
        if (event.target.response != "Error" || event.target.response != "NoFiles") {

            //--- Add the uploaded Image to Advertisement Preview section ---//
            $("#ImgAdvertisementImage").prop("src", "/_ImageUploads/Temp/" + filename);
        }
        else if (event.target.response == "Error") {
            GeneralWarningsAndErrorDialog("ERROR...", "We're unable to preview the selected image at this moment. Please continue with the rest of the form to submit the advertisement.", "red");
        }
        else if (event.target.response == "NoFiles") {
            GeneralWarningsAndErrorDialog("ERROR...", "Please select an Image to continue...", "red");
        }
    },
    false);
});


//--- Show Footer Text in Preview Sectoin when typing ---//
$(document).on("input", "#TxtFooter", function () {
    var Footer = $("#TxtFooter").val();
    $("#LblAdvertisementFooter").text(Footer);
});


//--- Save Advertisement when user click on Save Button ---//
$(document).on("click", "#BtnSaveAdvertisement", function () {
    AddEditAdvertisements();
});


function ShowAddAdvertisementSection()
{
    $("#divAddAdvertisementSection").fadeIn(1000);
    $("#divViewAdvertisements").hide();
}

function ShowViewAdvertisementSection() {
    $("#divViewAdvertisements").fadeIn(1000);
    $("#divAddAdvertisementSection").hide();
    $("#TblAdvertisements").DataTable();
}

function ShowEditAdvertisementContent()
{
    //var AdID = $.trim($("#LblHiddenAdID").val());
    var Title = $.trim($("#TxtTitle").val());
    var Description = $.trim($("#TxtDescription").val());
    var Footer = $.trim($("#TxtFooter").val());
    var ImageFile = $.trim($("#LblHiddenImageFileName").val());
    var StartDate = $.trim($("#TxtStartDate").val());
    var ExpiryDate = $.trim($("#TxtExpiryDate").val());

    $("#LblAdvertisementFooter").text(Footer);
    $("#LblAdvertisementTitle").text(Title);
    $("#LblAdDescription").text(Description);
    $("#ImgImageFile").val();
    $("#ImgAdvertisementImage").prop("src", "/_ImageUploads/Advertisements/" + ImageFile);
    
}


