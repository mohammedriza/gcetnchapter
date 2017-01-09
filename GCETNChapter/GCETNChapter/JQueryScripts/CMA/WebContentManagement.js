//--- Inital Page load FadeIn the body section ---//
$(function () {
    $("#divCMAPage").fadeIn(1000);


    //-- Update Selected Link Style to "Events" link (Underline) --//
    $("#LnkCMA").addClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkDonations").removeClass("menuitemSelected");
    $("#LnkManageAccess").removeClass("menuitemSelected");
    $("#LnkAdvertisements").removeClass("menuitemSelected");
    $("#LnkMyProfile").removeClass("menuitemSelected");
});