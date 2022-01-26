$(document).ready(function () {
    $('.legalPerson').hide();
    $('#customer-title').hide();
    $("#vendor-button").addClass("hovered");
});

$('#customer-button').on("click", function () {
    $("#customer-button").addClass("hovered");
    $("#vendor-button").removeClass("hovered");
    $('#customer-title').show();
    $('#vendor-title').hide();
});

$('#vendor-button').on("click", function () {
    $("#vendor-button").addClass("hovered");
    $("#customer-button").removeClass("hovered");
    $('#customer-title').hide();
    $('#vendor-title').show();
});

$('#edo-ani1').on("click", function () {
    $('.physicalPerson').show();
    $('.legalPerson').hide();
});

$('#edo-ani2').on("click", function () {
    $('.physicalPerson').hide();
    $('.legalPerson').show();
});
