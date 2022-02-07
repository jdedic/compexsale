function removeAdd() {
    var id = parseInt($('#addId').text());
    var url = "/Product/RemoveAdd"
    $.post(url, { id: id }, function (data) {
        $('#addModal').modal('hide');
        var $grid = $("#batchDelete");
        $grid.jsGrid("option", "pActionIndex", 1);
        $grid.jsGrid("loadData");
    });
}