
$(document).ready(function () {
$("#signin-form").submit(function (e) {
    e.preventDefault();

    // Get form data
    var username = $("#signin-username").val();
    var password = $("#signin-password").val();

    // Create user object for sign-in
    var user = {
        Username: username,
        PasswordHash: password
        
    };

    // Send AJAX request to sign in
    $.ajax({
        type: "POST",
        url: "http://localhost:2141/user/signin",
        contentType: "application/json",
        data: JSON.stringify(user),
        success: function (response) {
            // Redirect to a different page or display a success message
            $(".result-message").text("Sign-in successful. UserID: " + response.UserID);
        },
        error: function (error) {
            $(".result-message").text("Sign-in failed: " + error.responseText);
        }
    });
});
});