(function($) {
    "use strict";
    $("#batchDelete").jsGrid({
        width: "100%",
        autoload: true,
        confirmDeleting: false,
        paging: true,
        controller: {
            loadData: function() {
                return [
                    {
                        "First Name": "Rowan",
                        "Last Name": "Torres",
                        "Email": "Rowan.torres@gmail.com",
                        "Telephone": "6 Days ago",
                        "Working Position": "Customer",
                    },
                    {
                        "First Name": "Alonzo",
                        "Last Name": "Perez",
                        "Email": "Perez.Alonzo@gmail.com",
                        "Telephone": "2 Days ago",
                        "Working Position": "Customer",
                    }];
            }
        },
        fields: [
            {
                headerTemplate: function() {
                    return $("<button>").attr("type", "button").text("Delete") .addClass("btn btn-danger btn-sm btn-delete mb-0 b-r-2")
                        .click( function () {
                            deleteSelectedItems();
                        });
            },
            itemTemplate: function(_, item) {
                return $("<input>").attr("type", "checkbox")
                        .prop("checked", $.inArray(item, selectedItems) > -1)
                        .on("change", function () {
                            $(this).is(":checked") ? selectItem(item) : unselectItem(item);
                        });
            },
            align: "center",
            width: 50
            },
            { name: "Ime", type: "text", width: 100 },
            { name: "Prezime", type: "text", width: 100 },
            { name: "Email", width: 100 },
            { name: "Telefon", type: "text", width: 100 },
            { name: "Funkcija", type: "text", width: 100 }
        ]
    });
    var selectedItems = [];
    var selectItem = function(item) {
        selectedItems.push(item);
    };
    var unselectItem = function(item) {
        selectedItems = $.grep(selectedItems, function(i) {
            return i !== item;
        });
    };
    var deleteSelectedItems = function() {
        if(!selectedItems.length || !confirm("Are you sure?"))
            return;
        deleteClientsFromDb(selectedItems);
        var $grid = $("#batchDelete");
        $grid.jsGrid("option", "pActionIndex", 1);
        $grid.jsGrid("loadData");
        selectedItems = [];
    };
    var deleteClientsFromDb = function(deletingClients) {
        db.clients = $.map(db.clients, function(client) {
            return ($.inArray(client, deletingClients) > -1) ? null : client;
        });
    };
})(jQuery);
