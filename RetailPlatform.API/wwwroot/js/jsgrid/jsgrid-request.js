(function ($) {
    "use strict";
    $("#batchDelete").jsGrid({
        width: "100%",
        autoload: true,
        paging: true,
        sorting: true,
        confirmDeleting: false,

        pageSize: 15,
        pageButtonCount: 5,

        controller: {
            loadData: function (filter) {
                return $.ajax({
                    type: "GET",
                    url: "/Product/GetRequest",
                    data: filter,
                    dataType: "json"
                });
            },
            updateItem: function (item) {
                return $.ajax({
                    type: "GET",
                    url: "/Product/EditRequest" + item,
                    data: item,
                    dataType: "json"
                });
            },
        },
        fields: [
            { name: "uniqueId", type: "text", width: 60, title: "Unique id" },
            { name: "name", type: "text", width: 100, title: "Name" },
            { name: "category", width: 100, title: "Category" },
            { name: "place", width: 60, title: "Place" },
            {
                type: "control", editButton: false, deleteButton: false,
                itemTemplate: function (value, item) {

                    var $customEditButton = $("<button>")
                        .attr({ class: "btn btn-outline-warning btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.editButtonTooltip })
                        .attr({ id: "btn-edit-" + item.id })
                        .text("Edit")
                        .click(function (e) {
                            document.location.href = "/Product/EditRequest/" + item.id;
                            e.stopPropagation();
                        });
                    var $customDeleteButton = $("<button>")
                        .attr({ class: "btn btn-outline-danger btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.deleteButtonTooltip })
                        .text("Delete")
                        .attr({ id: "btn-delete-" + item.id })
                        .click(function (e) {
                            $('#addModal').modal('show');
                            $('#addId').text(item.id);
                            $('#message').text("Da li zelite da uklonite " + item.name + " oglas?");
                            e.stopPropagation();
                        });

                    return $("<div>")
                        .append($customEditButton)
                        .append($customDeleteButton);
                }
            }
        ]
    });

    var deleteSelectedItems = function () {
        if (!selectedItems.length || !confirm("Are you sure?"))
            return;
        deleteClientsFromDb(selectedItems);
        var $grid = $("#batchDelete");
        $grid.jsGrid("option", "pActionIndex", 1);
        $grid.jsGrid("loadData");
        selectedItems = [];
    };
    var deleteClientsFromDb = function (deletingClients) {
        db.clients = $.map(db.clients, function (client) {
            return ($.inArray(client, deletingClients) > -1) ? null : client;
        });
    };
})(jQuery);

