var connection = new signalR.HubConnectionBuilder().withUrl("/SignalServer").build();

// Start the connection
connection.start().then(function () {
    console.log("SignalR connected");
}).catch(function (err) {
    console.error(err.toString());
});

// Function to save a product
function saveProduct() {
    var productData = {
        Name: $("#productName").val(),
        Price: $("#productPrice").val(),
        // Add other properties as needed
    };

    // Perform an AJAX request to save the product
    $.ajax({
        url: '/Product/Save',  // Adjust the URL based on your project structure
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(productData),
        success: function (result) {
            // Handle the success response
            console.log(result);

            // Notify clients about the saved product
            connection.invoke("SendProductUpdate", "New product saved");

            // You may want to update the UI or navigate to another page upon success
        },
        error: function (error) {
            // Handle the error response
            console.error(error);

            // You may want to display an error message to the user
        }
    });
}

// Receive product update from the server
connection.on("ReceiveProductUpdate", function (message) {
    console.log("Received product update: " + message);
    // Handle the product update on the client side (e.g., display a notification)
});
