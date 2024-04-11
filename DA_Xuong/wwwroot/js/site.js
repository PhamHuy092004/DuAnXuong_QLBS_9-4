// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#dropdownMenuLink').click(function (e) {
        e.preventDefault(); // Ngăn chặn hành động mặc định của liên kết
        $(this).next('.dropdown-menu').toggleClass('show');
    });
});
function addToCart() {
    document.getElementById("addToCartForm").submit();
}
setTimeout(function () {
    document.getElementById("successMessage").style.display = "none";
}, 3000);
setTimeout(function () {
    document.getElementById("errorMessage").style.display = "none";
}, 3000);
document.addEventListener('DOMContentLoaded', function () {
    var minusButton = document.querySelector('.minus-btn');
    var plusButton = document.querySelector('.plus-btn');
    var inputField = document.querySelector('input[name="quantity"]');

    minusButton.addEventListener('click', function () {
        var currentValue = parseInt(inputField.value);
        if (currentValue > 1) {
            inputField.value = currentValue - 1;
        }
    });

    plusButton.addEventListener('click', function () {
        var currentValue = parseInt(inputField.value);
        inputField.value = currentValue + 1;
    });
});
