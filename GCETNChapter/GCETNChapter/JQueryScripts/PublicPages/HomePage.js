
//-- Update Selected Link Style to "Contact Us" link (Underline) --//
$(function () {
    $("#divHomePage").fadeIn(1000);
    GetActiveAdvertisements();

    $("#LnkHome").addClass("menuitemSelected");
    $("#LnkAboutUs").removeClass("menuitemSelected");
    $("#LnkGallery").removeClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkNews").removeClass("menuitemSelected");
    $("#LnkMembers").removeClass("menuitemSelected");
    $("#LnkContactUs").removeClass("menuitemSelected");
})


//--- GET ACTIVE ADVERTISEMENTS AND SCROLL IN THE MARQUEE ---//
function GetActiveAdvertisements() {
    $("#divShowAdvertisements").load("/Home/GetActiveAdvertisements/",
    { },
    function (responseTxt, statusTxt, xhr) {
        if (statusTxt == "success") {
        }
        else if (statusTxt == "error") {
            $("#divShowAdvertisements").text("Failed to load Advertisements. We're currently investigating on this issue. Thank You for your patience.")
        }
    });
}


function LnkGallerySelectedStyle() {
    $("#LnkHome").removeClass("menuitemSelected");
    $("#LnkAboutUs").removeClass("menuitemSelected");
    $("#LnkGallery").addClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkNews").removeClass("menuitemSelected");
    $("#LnkMembers").removeClass("menuitemSelected");
    $("#LnkContactUs").removeClass("menuitemSelected");
}

function LnkEventsSelectedStyle() {
    $("#LnkHome").removeClass("menuitemSelected");
    $("#LnkAboutUs").removeClass("menuitemSelected");
    $("#LnkGallery").removeClass("menuitemSelected");
    $("#LnkEvents").addClass("menuitemSelected");
    $("#LnkNews").removeClass("menuitemSelected");
    $("#LnkMembers").removeClass("menuitemSelected");
    $("#LnkContactUs").removeClass("menuitemSelected");
}

function LnkNewsSelectedStyle() {
    $("#LnkHome").removeClass("menuitemSelected");
    $("#LnkAboutUs").removeClass("menuitemSelected");
    $("#LnkGallery").removeClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkNews").addClass("menuitemSelected");
    $("#LnkMembers").removeClass("menuitemSelected");
    $("#LnkContactUs").removeClass("menuitemSelected");
}

