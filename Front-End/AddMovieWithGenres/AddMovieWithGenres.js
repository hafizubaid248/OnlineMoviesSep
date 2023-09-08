$(document).ready(function () {
    
    $('#genres-table').DataTable();

   
    $.ajax({
        type: "GET",
        url: "http://localhost:2141/movies/getallgenres",
        success: function (genres) {
            var genresSelect = $("#genres");
            $.each(genres, function (index, genre) {
                genresSelect.append("<option value='" + genre.GenreID + "'>" + genre.Name + "</option>");
            });
        },
        error: function (error) {
            console.error("Failed to fetch genres: " + error.responseText);
        }
    });





    $("#add-movie-genres-form").submit(function (e) {
        e.preventDefault();
    
        var title = $("#title").val();
        var description = $("#description").val();
        var releaseDateInput = $("#release-date").val();
        var genreIDs = $("#genres").val().join();
    
        
        // var parts = releaseDateInput.split('-');
        // var releaseDate = parts[2] + '-' + parts[0] + '-' + parts[1]; // yyyy-mm-dd
    
        // var movie = {
        //     Title: title,
        //     Description: description,
        //     ReleaseDate: releaseDate
        // };






    // $("#add-movie-genres-form").submit(function (e) {
    //     e.preventDefault();


    //     var title = $("#title").val();
    //     var description = $("#description").val();
    //     var releaseDate = $("#release-date").val();
    //     var genreIDs = $("#genres").val();


    //     var movie = {
    //         Title: title,
    //         Description: description,
    //         ReleaseDate: releaseDate
    //     };



      
        $.ajax({
            type: "POST",
            url: "http://localhost:2141/admin/addmoviewithgenres",
            contentType: "application/json",
            data: JSON.stringify({ title: title, description:description,releaseDate:releaseDateInput,genreId:genreIDs}),
            success: function (response) {
                $(".result-message").text("Movie added successfully.");
            },
            error: function (error) {
                $(".result-message").text("Failed to add movie: " + error.responseText);
            }
        });
    });




    });








