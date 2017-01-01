$(function () {
    $("#divAboutUsPage").fadeIn(1000);
    $("#divGceTnTrust").fadeIn(1000);

    //-- Update Selected Link Style to "About Us" link (Underline) --//
    $("#LnkHome").removeClass("menuitemSelected");
    $("#LnkAboutUs").addClass("menuitemSelected");
    $("#LnkGallery").removeClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkNews").removeClass("menuitemSelected");
    $("#LnkMembers").removeClass("menuitemSelected");
    $("#LnkContactUs").removeClass("menuitemSelected");
})


$(document).ready(function () {
    $("#LnkAboutUsGceTnTrust").click(function () {
        $("#divGceTnTrust").fadeIn(1000);
        $("#divFounderMessage").hide();
        $("#divTheBoardMembers").hide();
    });

    $("#LnkAboutUsFounderMessage").click(function () {
        $("#divGceTnTrust").hide();
        $("#divFounderMessage").fadeIn(1000);
        $("#divTheBoardMembers").hide();
    });

    $("#LnkAboutUsTheBoardMembers").click(function () {
        $("#divGceTnTrust").hide();
        $("#divFounderMessage").hide();
        $("#divTheBoardMembers").fadeIn(1000);
    });
});