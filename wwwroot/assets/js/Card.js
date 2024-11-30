document.addEventListener("DOMContentLoaded", function () {
    // Show the form when the 'Book Now' button is clicked
    document.getElementById("btnShowForm").addEventListener("click", function () {
        document.getElementById("bookingFormContainer").style.display = "block";
    });

    // Show/hide Visa and PayPal fields based on payment method selection
    document.getElementById("paymentMethod").addEventListener("change", function () {
        var paymentMethod = this.value;
        if (paymentMethod === 'Visa') {
            document.getElementById("visaDetails").style.display = "block";
            document.getElementById("paypalDetails").style.display = "none";
        } else if (paymentMethod === 'PayPal') {
            document.getElementById("visaDetails").style.display = "none";
            document.getElementById("paypalDetails").style.display = "block";
        } else {
            document.getElementById("visaDetails").style.display = "none";
            document.getElementById("paypalDetails").style.display = "none";
        }
    });
});