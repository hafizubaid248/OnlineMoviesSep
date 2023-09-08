$(document).ready(function () {
    // Handle form submission
    $("#signup-form").submit(function (e) {
        e.preventDefault();
        
        // Get form data
        var username = $("#username").val();
        var password = $("#password").val();
        var email = $("#email").val();
        var isAdmin = $("#isAdmin").is(":checked");
        
        // Create user object
        var user = {
            Username: username,
            PasswordHash: password,
            Email: email,
            IsAdmin: isAdmin
        };

        // Send AJAX request to sign up
        $.ajax({
            type: "POST",
            url: "http://localhost:2141/user/signup",
            contentType: "application/json",
            data: JSON.stringify(user),
            success: function (response) {
               
                $(".result-message").text("User has been registered");
             
            },
            error: function (error) {
                
                $(".result-message").text("User registration failed: " + error.responseText);
            }
        });
    });
    
    
});
