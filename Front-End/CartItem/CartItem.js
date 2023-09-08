// $(document).ready(function () {
//     // Handle form submission
//     $("#add-to-cart-form").submit(function (e) {
//         e.preventDefault();

//         // Get form data
//         var userID = $("#userID").val();
//         var movieID = $("#movieID").val();
//         var genreID = $("#genreID").val();
//         var quantity = $("#quantity").val();

//         // Create cart item object
//         var cartItem = {
//             UserID: userID,
//             MovieID: movieID,
//             GenreID: genreID,
//             Quantity: quantity
//         };

//         // Send AJAX request to add item to cart
//         $.ajax({
//             type: "POST",
//             url: "http://localhost:2141/customer/addtocart",
//             contentType: "application/json",
//             data: JSON.stringify(cartItem),
//             success: function (response) {
//                 $(".result-message").text("Item added to cart successfully.");
//             },
//             error: function (error) {
//                 $(".result-message").text("Failed to add item to cart: " + error.responseText);
//             }
//         });
//     });
// });









































$(document).ready(function () {
    // Initialize DataTable
    var cartTable = $('#cart-table').DataTable();
    var cartTable = $('#cart-table').DataTable();

    // Function to add a movie to the cart
    function addToCart(movieID, genreID) {
        var quantity = 1; // You can allow customers to specify quantity if needed

        var cartItem = {
            UserID: 1, // Replace with the actual user ID
            MovieID: movieID,
            GenreID: genreID,
            Quantity: quantity
        };

        // Send AJAX request to add to cart
        $.ajax({
            type: "POST",
            url: "http://localhost:2141/customer/addtocart",
            contentType: "application/json",
            data: JSON.stringify(cartItem),
            success: function (response) {
                // Reload the DataTable to reflect updated cart
                cartTable.ajax.reload(null, false);
                console.log(response);
            },
            error: function (error) {
                console.error("Failed to add to cart: " + error.responseText);
            }
        });
    }

    // Fetch cart items and populate the DataTable
    function fetchCartItems() {
        $.ajax({
            type: "GET",
            url: "http://localhost:2141/movies/getall",
            success: function (cartItems) {
                // Clear the DataTable
                cartTable.clear();

                // Populate the DataTable with cart items
                $.each(cartItems, function (index, cartItem) {
                    cartTable.row.add([
                        cartItem.Title,
                        cartItem.Genre,
                        cartItem.Quantity,
                        '<button class="remove-from-cart" data-movieid="' + cartItem.MovieID + '" data-genreid="' + cartItem.GenreID + '">Remove</button>'
                    ]);
                });

                // Draw the DataTable
                cartTable.draw();
            },
            error: function (error) {
                console.error("Failed to fetch cart items: " + error.responseText);
            }
        });
    }



    function fetchCartItems() {

        var genre = {
         
           Name: name
          
        };
        $.ajax({
            type: "GET",
            url: "http://localhost:2141/movies/getallgenres",
            success: function (Genre) {
                // Clear the DataTable
                cartTable.clear();

                // Populate the DataTable with cart items
                $.each(Genre, function (index, genre) {
                    cartTable.row.add([
                        cartItem.Name
                        // cartItem.Genre,
                        // cartItem.Quantity,
                        // '<button class="remove-from-cart" data-movieid="' + cartItem.MovieID + '" data-genreid="' + cartItem.GenreID + '">Remove</button>'
                    ]);
                });

                // Draw the DataTable
                cartTable.draw();
            },
            error: function (error) {
                console.error("Failed to fetch cart items: " + error.responseText);
            }
        });
    }













    

    // Fetch and populate cart items on page load
    fetchCartItems();

    // Handle "Add to Cart" button click
    $('#cart-table tbody').on('click', '.add-to-cart', function () {
        var movieID = $(this).data('movieid');
        var genreID = $(this).data('genreid');
        addToCart(movieID, genreID);
    });







  
    $('#cart-table tbody').on('click', '.remove-from-cart', function () {
        var movieID = $(this).data('movieid');
        var genreID = $(this).data('genreid');
        removeFromCart(movieID, genreID);
    });


    function removeFromCart(movieID, genreID) {
        // Send AJAX request to remove from cart
        $.ajax({
            type: "POST",
            url: "http://localhost:2141/customer/removefromcart",
            contentType: "application/json",
            data: JSON.stringify({ MovieID: movieID, GenreID: genreID }),
            success: function (response) {
                // Reload the DataTable to reflect updated cart
                cartTable.ajax.reload(null, false);
                console.log(response);
            },
            error: function (error) {
                console.error("Failed to remove from cart: " + error.responseText);
            }
        });
    }

});















































// // $(document).ready(function () {
 


// //     $("#add-to-cart-form").submit(function (e) {
// //         e.preventDefault();

      
// //         var userId = 1; 
// //         var movieId = $("#movie").val();
// //         var genreId = $("#genre").val();
// //         var quantity =$("#quantity").val();

 
// //         $.ajax({
// //             type: "POST",
// //             url: "http://localhost:2141/customer/addtocart",
// //             contentType: "application/json",
// //             data: JSON.stringify({ UserID: userId, MovieID: movieId, GenreID: genreId, Quantity:quantity }),
// //             success: function (response) {
// //                 $(".result-message").text(response);
// //             },
// //             error: function (error) {
// //                 $(".result-message").text("Failed to add item to cart: " + error.responseText);
// //             }
// //         });
// //     });
// // });
