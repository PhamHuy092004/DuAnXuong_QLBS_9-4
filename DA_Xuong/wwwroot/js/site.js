// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#dropdownMenuLink').click(function (e) {
        e.preventDefault(); // Ngăn chặn hành động mặc định của liên kết
        $(this).next('.dropdown-menu').toggleClass('show');
    });
});
document.querySelectorAll('.minus-btn').forEach(function (button) {
    button.addEventListener('click', function () {
        var input = this.nextElementSibling;
        var currentValue = parseInt(input.value);
        if (currentValue > 1) {
            input.value = currentValue - 1;
        }
    });
});

document.querySelectorAll('.plus-btn').forEach(function (button) {
    button.addEventListener('click', function () {
        var input = this.previousElementSibling;
        var currentValue = parseInt(input.value);
        input.value = currentValue + 1;
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
