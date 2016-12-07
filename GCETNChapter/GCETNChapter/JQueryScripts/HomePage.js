
//-- FUNCTION TO SCROLL IMAGES IN THE HOME PAGE ---//
$(function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    myIndex++;
    if (myIndex > x.length) { myIndex = 1 }
    x[myIndex - 1].style.display = "block";
    setTimeout(carousel, 9000);
})


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

