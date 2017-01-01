$(function () {
    $("#divNewsPage").fadeIn(1000);

    //-- Update Selected Link Style to "About Us" link (Underline) --//
    $("#LnkHome").removeClass("menuitemSelected");
    $("#LnkAboutUs").removeClass("menuitemSelected");
    $("#LnkGallery").removeClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkNews").addClass("menuitemSelected");
    $("#LnkMembers").removeClass("menuitemSelected");
    $("#LnkContactUs").removeClass("menuitemSelected");
})