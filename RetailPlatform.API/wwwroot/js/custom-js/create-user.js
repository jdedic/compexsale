function changePassword() {
    var x = document.getElementById("userPassword");
    if (x.classList.contains('d-none')) {
        x.classList.remove('d-none');
        x.classList.add('d-block');
    } else {
        x.classList.remove('d-block');
        x.classList.add('d-none');
    }
}

function removeUser() {
    var id = parseInt($('#userId').text());
    var url = "/User/RemoveUser"
    $.post(url, { id: id }, function (data) {
        $('#userModal').modal('hide');
        var $grid = $("#batchDelete");
        $grid.jsGrid("option", "pActionIndex", 1);
        $grid.jsGrid("loadData");
    });
   
}