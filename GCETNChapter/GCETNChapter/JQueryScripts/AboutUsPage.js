$(function () {
    $('#divAboutUsPage').fadeIn(1000);
    $('#divGceTnTrust').fadeIn(1000);

    //-- Update Selected Link Style to "About Us" link (Underline) --//
    $('#LnkHome').removeClass('menuitemSelected');
    $('#LnkAboutUs').addClass('menuitemSelected');
    $('#LnkGallery').removeClass('menuitemSelected');
    $('#LnkEvents').removeClass('menuitemSelected');
    $('#LnkNews').removeClass('menuitemSelected');
    $('#LnkMembers').removeClass('menuitemSelected');
    $('#LnkContactUs').removeClass('menuitemSelected');
})


$(document).ready(function () {
    $('#LnkAboutUsGceTnTrust').click(function () {
        $('#divGceTnTrust').show('clip');
        $('#divFounderMessage').hide('clip');
        $('#divTheBoardMembers').hide('clip');
    });

    $('#LnkAboutUsFounderMessage').click(function () {
        $('#divGceTnTrust').hide('clip');
        $('#divFounderMessage').show('clip');
        $('#divTheBoardMembers').hide('clip');
    });

    $('#LnkAboutUsTheBoardMembers').click(function () {
        $('#divGceTnTrust').hide('clip');
        $('#divFounderMessage').hide('clip');
        $('#divTheBoardMembers').show('clip');
    });
});