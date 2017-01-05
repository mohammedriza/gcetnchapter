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


//--- Get News Feed by News ID ---//
function GetNewsFeedByNewsID(NewsID) {

    $("#divAddUpdateNewsFeed").load("/News/GetNewsFeedByNewsID/",
        {NewsID: NewsID},
        function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success") {
                $("#divAddEditNewsFeedModal").modal();
            }
            else if (statusTxt == "error") {
                GeneralWarningsAndErrorDialog("Error Loading Data...", "Failed to load data. Please open the application in a new browser and try again. \n\nIf the issue still continues, please contact your systems administrator for assistance.", "red");
            }
        });
}


function AddUpdateNewsFeed() {
    var NewsID = $("#LblNewsID").val();
    var Headline = $("#TxtNewsHeadline").val();
    var NewsDetail = $("#TxtNewsDetail").val();

    if (Headline == "" || NewsDetail == "") {
        GeneralWarningsAndErrorDialog("Warning", "News Headline and Detail are mandatory to add New Feed.", "red");
    }
    else {
        $.ajax({
            url: "/News/AddUpdateNewsFeed/",
            type: "POST",
            data: {
                NewsID: NewsID,
                HeadLine: Headline,
                NewsDetail: NewsDetail
            },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "News Feed successfully saved. Close the modal and refresh the page to see the updated news Feed.", "green");
                    InitializeAddNewsFeed();
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to save News Feed. Please try again later.", "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("ERROR", "Error Description: " + error + "\n" + xhr.responseText, "red");
            }
        });
    }

}


function DeleteNewsFeed(NewsID) {
    if (confirm("Are you sure you want to delete the selected News Feed?. Please confirm...")) {
        $.ajax({
            url: "/News/DeleteNewsFeed",
            type: "POST",
            data: { NewsID: NewsID },
            success: function (data, result) {
                if (data == "Success") {
                    GeneralWarningsAndErrorDialog("SUCCESS", "The selected News Feed is deleted successfully. Close the modal and refresh the page to see the updated News Feed", "green");
                }
                else if (data == "Error") {
                    GeneralWarningsAndErrorDialog("ERROR", "Failed to delete the selected News Feed. Please try again later.", "red");
                }
                else if (data.indexOf("Exception") >= 0) {
                    GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", data, "red");
                }
                else if (data == "401") {
                    ShowAccessDeniedMessage();
                }
            },
            error: function (xhr, status, error) {
                GeneralWarningsAndErrorDialog("UNEXPECTED ERROR...", "An unexpected error had occured. Please try again later.", "red");
            }
        });
    }
}


function InitializeAddNewsFeed()
{
    $("#LblNewsID").val("0");
    $("#TxtNewsHeadline").val("");
    $("#TxtNewsDetail").val("");
}

//--- Open Add News Feed Modal ---//
$(document).on("click", "#LnkAddNewsFeed", function () {
    GetNewsFeedByNewsID(0);
    InitializeAddNewsFeed()
    $("#divAddEditNewsFeedModal").modal();
});

//--- Save News Feed (Add / Update ) ---//
$(document).on("click", "#BtnSaveNewsFeed", function () {
    AddUpdateNewsFeed();
});

//--- Cancel Save News Feed Modal ---//
$(document).on("click", "#BtnCancel", function () {
    $("#divAddEditNewsFeedModal").modal("hide");
});
