function createSubCategory() {
    var url = "/SubCategory/CreateSubCategory"
    $.get(url, function (data) {
        $('#subCategoryModalContent').html(data);
        $('#subCategoryModal').modal('show');
    });
}

function removeSubCategory() {
    var id = parseInt($('#subCategoryId').text());
    var url = "/SubCategory/RemoveSubCategory"
    $.post(url, { id: id }, function (data) {
        $('#subCategoryDeleteModal').modal('hide');
        var $grid = $("#basicScenario");
        $grid.jsGrid("option", "pActionIndex", 1);
        $grid.jsGrid("loadData");
    });
}