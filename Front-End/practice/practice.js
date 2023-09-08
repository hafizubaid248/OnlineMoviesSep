// $(document).ready(function () {
    
   
//     $('#cart-table').DataTable();

    
//     $(".add-to-cart-button").click(function () {
        
//         var movieID = $(this).data("movie-id");
//         var quantity = 1; 
        
     
//         $.ajax({
//             type: "POST",
//             url: "http://localhost:2141/shoppingcart/add",
//             // data: { UserID: 1, MovieID: movieID, Quantity: quantity }, 
//             data: { MovieID: movieID, Quantity: quantity }, 
//             success: function (response) {
//                 alert(response);
//             },
//             error: function (error) {
//                 console.error("Failed to add item to cart: " + error.responseText);
//             }
            
//         });
//     });
    

    
//     $(".remove-from-cart-button").click(function () {
//         var shoppingCartID = $(this).data("cart-id");
        
//         $.ajax({
//             type: "POST",
//             url: "http://localhost:2141/shoppingcart/remove",
//             data: { CartID: shoppingCartID },
//             success: function (response) {
//                 console.log("Item added to cart:", response);
//                 alert(response);
//             },
//             error: function (error) {
//                 console.error("Failed to add item to cart: " + error.responseText);
//                 console.error("Failed to remove item from cart: " + error.responseText);
//             }
//         });
//     });
// });
















$(document).ready(function () {
    // Initialize DataTable
    var cartTable = $('#cart-table').DataTable();

    // Function to add a row to the cart table
    function addToCartRow(movieTitle, genre, quantity) {
        cartTable.row.add([movieTitle, genre, quantity, '<button class="remove-from-cart-button">Remove</button>']).draw();
    }

    // Handle adding item to cart
    $(".add-to-cart-button").click(function () {
        var movieTitle = "Movie Title"; // Replace with actual movie title
        var genre = "Genre"; // Replace with actual genre
        var quantity = 1; // Adjust quantity as needed
        // Send AJAX request to add item to cart
        $.ajax({
            type: "POST",
            url: "http://localhost:2141/shoppingcart/add",
            data: { UserID: 1, MovieID: 1, Quantity: quantity }, // Adjust UserID and MovieID as needed
            success: function (response) {
                alert(response);
                addToCartRow(movieTitle, genre, quantity);
            },
            error: function (error) {
                console.error("Failed to add item to cart: " + error.responseText);
            }
        });
    });

    // Handle removing item from cart
    $("#cart-table tbody").on("click", ".remove-from-cart-button", function () {
        var shoppingCartID = $(this).data("cart-id");
        var row = $(this).closest("tr");
        // Send AJAX request to remove item from cart
        $.ajax({
            type: "POST",
            url: "http://localhost:2141/shoppingcart/remove",
            data: { ShoppingCartID: shoppingCartID },
            success: function (response) {
                alert(response);
                cartTable.row(row).remove().draw();
            },
            error: function (error) {
                console.error("Failed to remove item from cart: " + error.responseText);
            }
        });
    });
});
