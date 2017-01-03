$(function () {
    $("#divAdvertisementPage").fadeIn(1000);

    //-- Update Selected Link Style to "Donations" link (Underline) --//
    $("#LnkAdvertisements").addClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkDonations").removeClass("menuitemSelected");
    $("#LnkManageAccess").removeClass("menuitemSelected");
    $("#LnkMyProfile").removeClass("menuitemSelected");
})


function AddEditAdvertisements() {
    var Title = $.trim($("#TxtTitle").val());
    var Body = $.trim($("#TxtBody").val());
    var Footer = $.trim($("#TxtFooter").val());
    var ImageFile = $.trim($("#ImgImageFile").val());

    var filename = ImageFile.split('\\').pop()

    if (Title == "" || Body == "" || ImageFile == "") {
        GeneralWarningsAndErrorDialog("ERROR...", "Title, Body and Image are mandatory. Please fill them to continue.", "red");
    }
    else {
        var xhr = new XMLHttpRequest();
        var fd = new FormData();
        fd.append("Title", Title);
        fd.append("Body", Body);
        fd.append("Footer", Footer);
        fd.append("file", document.getElementById('ImgImageFile').files[0]);

        xhr.open("POST", "/Advertisement/AddUpdateAdvertisements/", true);
        xhr.send(fd);
        xhr.addEventListener("load", function (event) {
            if (event.target.response != "Error" || event.target.response != "NoFiles") {
                GeneralWarningsAndErrorDialog("SUCCESS...", "Advertisement created successfully. See the preview for the full advertisement.", "green");

                //--- Add the uploaded Image to Advertisement Preview section ---//
                $("#ImgAdvertisementImage").prop("src", "/_ImageUploads/Advertisements/" + event.target.response);
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

//--- Show Header Text in Preview Sectoin when typing ---//
$(document).on("input", "#TxtTitle", function () {
    var Title = $("#TxtTitle").val();
    $("#LblAdvertisementTitle").text(Title);
});

//--- Show Body Text in Preview Sectoin when typing ---//
$(document).on("input", "#TxtBody", function () {
    var Body = $("#TxtBody").val();
    $("#LblAdvertisementBody").text(Body);
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
