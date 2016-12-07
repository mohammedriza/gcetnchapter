$(function () {
    $('#divContactUsPage').fadeIn(1000);

    //-- Update Selected Link Style to "Contact Us" link (Underline) --//
    $('#LnkHome').removeClass('menuitemSelected');
    $('#LnkAboutUs').removeClass('menuitemSelected');
    $('#LnkGallery').removeClass('menuitemSelected');
    $('#LnkEvents').removeClass('menuitemSelected');
    $('#LnkNews').removeClass('menuitemSelected');
    $('#LnkMembers').removeClass('menuitemSelected');
    $('#LnkContactUs').addClass('menuitemSelected');
})