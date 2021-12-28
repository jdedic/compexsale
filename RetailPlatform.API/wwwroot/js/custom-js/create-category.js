function removeCategory() {
    var id = parseInt($('#categoryId').text());
    var url = "/Category/RemoveCategory"
    $.post(url, { id: id }, function (data) {
        $('#categoryModal').modal('hide');
        var $grid = $("#basicScenario");
        $grid.jsGrid("option", "pActionIndex", 1);
        $grid.jsGrid("loadData");
    });
}