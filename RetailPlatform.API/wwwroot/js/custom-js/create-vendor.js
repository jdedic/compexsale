﻿$(document).ready(function () {
    $('.legalPerson').hide();
    $("#edo-ani1").addClass("hovered");
});

$('#edo-ani1').on("click", function () {
    $("#edo-ani1").addClass("hovered");
    $("#edo-ani2").removeClass("hovered");
    $('.physicalPerson').show();
    $('.legalPerson').hide();
    $("#legalCheckbox").prop('checked', false);
});

$('#edo-ani2').on("click", function () {
    $("#edo-ani1").removeClass("hovered");
    $("#edo-ani2").addClass("hovered");
    $('.physicalPerson').hide();
    $('.legalPerson').show();
    $("#legalCheckbox").prop('checked', true);
});

function changePassword() {
    var x = document.getElementById("vendorPassword");
    if (x.classList.contains('d-none')) {
        x.classList.remove('d-none');
        x.classList.add('d-block');
    } else {
        x.classList.remove('d-block');
        x.classList.add('d-none');
    }
}
