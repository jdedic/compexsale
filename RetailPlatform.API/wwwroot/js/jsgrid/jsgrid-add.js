(function ($) {
    "use strict";
    $("#batchDelete").jsGrid({
        width: "100%",
        autoload: true,
        //filtering: true,
        //inserting: true,
        paging: true,
        sorting: true,
        confirmDeleting: false,

        pageSize: 15,
        pageButtonCount: 5,

        controller: {
            loadData: function (filter) {
                return $.ajax({
                    type: "GET",
                    url: "/Product/Get",
                    data: filter,
                    dataType: "json"
                });
            },
            updateItem: function (item) {
                return $.ajax({
                    type: "GET",
                    url: "/Add/EditAdd" + item,
                    data: item,
                    dataType: "json"
                });
            },
        },
        fields: [
            { name: "uniqueId", type: "text", width: 60, title: "Oznaka" },
            { name: "name", type: "text", width: 100, title: "Naziv" },
            { name: "category", width: 100, title: "Kategorija" },
            { name: "quantity", width: 50, title: "Količina" },
            { name: "unit", width: 20, title: "Jedinica" },
            { name: "place", width: 50, title: "Lokacija" },
            { name: "status", width: 50, title: "Status" },
            {
                type: "control", editButton: false, deleteButton: false,
                itemTemplate: function (value, item) {

                    var $customEditButton = $("<button>")
                        .attr({ class: "btn btn-outline-warning btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.editButtonTooltip })
                        .attr({ id: "btn-edit-" + item.id })
                        .text("Izmeni")
                        .click(function (e) {
                            //alert("ID: " + item.id);
                            document.location.href = "/Product/EditProduct/" + item.id;
                            e.stopPropagation();
                        });
                    var $customDeleteButton = $("<button>")
                        .attr({ class: "btn btn-outline-danger btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.deleteButtonTooltip })
                        .text("Ukloni")
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

