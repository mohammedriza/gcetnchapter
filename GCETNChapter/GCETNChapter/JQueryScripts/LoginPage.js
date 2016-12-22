$(function () {
    $("#divLoginPage").fadeIn(1000);
    $("#txtUsername").focus();

    //-- Remove all Selected Link Style (Underline) --//
    $("#LnkHome").removeClass("menuitemSelected");
    $("#LnkAboutUs").removeClass("menuitemSelected");
    $("#LnkGallery").removeClass("menuitemSelected");
    $("#LnkEvents").removeClass("menuitemSelected");
    $("#LnkNews").removeClass("menuitemSelected");
    $("#LnkMembers").removeClass("menuitemSelected");
    $("#LnkContactUs").removeClass("menuitemSelected");
})


function AuthenticateMember() {
    $("#LoginProgressModal").modal();    //--- Showe Loading spinner when user clicks on login button ---//

    var username = $("#txtUsername").val();
    var password = $("#txtPassword").val();

    if (username == "" || password == "")
        GeneralWarningsAndErrorDialog("WARNING...", "Username or Password cannot be blank.", "red");
    else {
        $.post("/MemberRegistration/Login/",
        {
            Username: username,
            Password: password
        },
        function (data, status) {
            if (data == "Pass" && status == "success")
                window.location.replace("/MemberProfile/MyProfile");
            else if (data == "Pending") {
                $("#LoginProgressModal").modal("hide");
                GeneralWarningsAndErrorDialog("ALERT...", "Your account is still in pending status. You will be able to login once your account has been approved by the Trust group. Please contact the Trust for assistance.", "red");
            }
            else if (data == "Inactive") {
                $("#LoginProgressModal").modal("hide");
                GeneralWarningsAndErrorDialog("WARNING...", "Your account has been deactivated. Please contact the Trust for assistance.", "red");
            }
            else if (data == "Fail" || status == "error") {
                $("#LoginProgressModal").modal("hide");
                GeneralWarningsAndErrorDialog("ERROR...", "Failed to authenticate. Please try make sure your username and password are correct.", "red");
            }
            else {
                $("#LoginProgressModal").modal("hide");
                GeneralWarningsAndErrorDialog("ERROR...", "An unexpected error had occured. Please try again later or contact the Trust for assistance.", "red");
            }
        });
    }
}
