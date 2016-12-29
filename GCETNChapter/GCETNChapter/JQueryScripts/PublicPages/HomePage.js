
//-- Update Selected Link Style to "Contact Us" link (Underline) --//
$(function () {
    $('#LnkHome').addClass('menuitemSelected');
    $('#LnkAboutUs').removeClass('menuitemSelected');
    $('#LnkGallery').removeClass('menuitemSelected');
    $('#LnkEvents').removeClass('menuitemSelected');
    $('#LnkNews').removeClass('menuitemSelected');
    $('#LnkMembers').removeClass('menuitemSelected');
    $('#LnkContactUs').removeClass('menuitemSelected');
})



function LnkGallerySelectedStyle() {
    $('#LnkHome').removeClass('menuitemSelected');
    $('#LnkAboutUs').removeClass('menuitemSelected');
    $('#LnkGallery').addClass('menuitemSelected');
    $('#LnkEvents').removeClass('menuitemSelected');
    $('#LnkNews').removeClass('menuitemSelected');
    $('#LnkMembers').removeClass('menuitemSelected');
    $('#LnkContactUs').removeClass('menuitemSelected');
}

function LnkEventsSelectedStyle() {
    $('#LnkHome').removeClass('menuitemSelected');
    $('#LnkAboutUs').removeClass('menuitemSelected');
    $('#LnkGallery').removeClass('menuitemSelected');
    $('#LnkEvents').addClass('menuitemSelected');
    $('#LnkNews').removeClass('menuitemSelected');
    $('#LnkMembers').removeClass('menuitemSelected');
    $('#LnkContactUs').removeClass('menuitemSelected');
}

function LnkNewsSelectedStyle() {
    $('#LnkHome').removeClass('menuitemSelected');
    $('#LnkAboutUs').removeClass('menuitemSelected');
    $('#LnkGallery').removeClass('menuitemSelected');
    $('#LnkEvents').removeClass('menuitemSelected');
    $('#LnkNews').addClass('menuitemSelected');
    $('#LnkMembers').removeClass('menuitemSelected');
    $('#LnkContactUs').removeClass('menuitemSelected');
}

