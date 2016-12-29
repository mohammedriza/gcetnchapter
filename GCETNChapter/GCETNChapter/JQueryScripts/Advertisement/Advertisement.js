$(function () {
    $("#divAdvertisementsPage").fadeIn(1000);

    //-- Update Selected Link Style to "Donations" link (Underline) --//
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkDonations").removeClass("menuitemSelected");
    $("#LnkManageAccess").removeClass("menuitemSelected");
    $("#LnkAdvertisements").addClass("menuitemSelected");
    $("#LnkMyProfile").removeClass("menuitemSelected");
})