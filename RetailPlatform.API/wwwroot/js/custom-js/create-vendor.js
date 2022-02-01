$(document).ready(function () {
    $('.legalPerson').hide();
    $("#edo-ani1").addClass("hovered");
});

$('#edo-ani1').on("click", function () {
    $("#edo-ani1").addClass("hovered");
    $("#edo-ani2").removeClass("hovered");
    $('.physicalPerson').show();
    $('.legalPerson').hide();
});

$('#edo-ani2').on("click", function () {
    $("#edo-ani1").removeClass("hovered");
    $("#edo-ani2").addClass("hovered");
    $('.physicalPerson').hide();
    $('.legalPerson').show();
});
