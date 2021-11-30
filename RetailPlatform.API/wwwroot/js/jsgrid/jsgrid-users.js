(function ($) {
    "use strict";
    $("#batchDelete").jsGrid({
        width: "100%",
        autoload: true,
        //filtering: true,
        //inserting: true,
        //editing: true,
        paging: true,
        sorting: true,
        confirmDeleting: false,

        pageSize: 15,
        pageButtonCount: 5,

        controller: {
            loadData: function (filter) {
                return $.ajax({
                    type: "GET",
                    url: "/User/Get",
                    data: filter,
                    dataType: "json"
                });
            }
        },
        fields: [
            { name: "firstName", type: "text", width: 100, title: "First Name" },
            { name: "lastName", type: "text", width: 100, title: "Last Name" },
            { name: "email", width: 100, title: "Email" },
            { name: "workingPosition", width: 100, title: "Working Position" },
            { type: "control" }
            //{ name: "Telephone", type: "text", width: 100 },
            //{ name: "Working Position", type: "text", width: 100 }
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

