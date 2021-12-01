$('#edo-ani1').on("click", function () {
    document.getElementById("physicalPerson").classList.remove("d-none");
    document.getElementById("legalPerson").classList.add("d-none");
});

$('#edo-ani2').on("click", function () {
    document.getElementById("physicalPerson").classList.add("d-none");
    document.getElementById("legalPerson").classList.remove("d-none");
});