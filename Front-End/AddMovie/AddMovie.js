$(document).ready(function () {
   
    $('#movies-table').DataTable({
        ajax: {
          
            url: 'http://localhost:2141/movies/getall',
            dataSrc: ''
        },
        columns: [
            { data: 'MovieID' },
            { data: 'Title' },
            { data: 'Description' },
            { data: 'ReleaseDate' }
        ]
    });


    $("#add-movie-form").submit(function (e) {
        e.preventDefault();

        var title = $("#title").val();
        var description = $("#description").val();
        var releaseDate = $("#release-date").val();

        var movieData = {
            Title: title,
            Description: description,
            ReleaseDate: releaseDate
        };

        $.ajax({
            type: "POST",
            url: "http://localhost:2141/admin/addmovie",
            contentType: "application/json",
            data: JSON.stringify(movieData),
            success: function (response) {
                $(".result-message").text("Movie added successfully.");
              
                $("#title").val("");
                $("#description").val("");
                $("#release-date").val("");
            },
            error: function (error) {
                $(".result-message").text("Failed to add movie: " + error.responseText);
            }
        });
    });
});
