(function ($) {
    "use strict";
    $("#basicScenario").jsGrid({
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
                    url: "/Category/Get",
                    data: filter,
                    dataType: "json"
                });
            },
            //updateItem: function (item) {
            //    return $.ajax({
            //        type: "GET",
            //        url: "/User/EditUser" + item,
            //        data: item,
            //        dataType: "json"
            //    });
            //},
        },
        fields: [
            { name: "name", type: "text", width: 250, title: "Name" },
            {
                type: "control", editButton: false, deleteButton: false,
                itemTemplate: function (value, item) {

                    var $customEditButton = $("<button>")
                        .attr({ class: "btn btn-outline-warning btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.editButtonTooltip })
                        .attr({ id: "btn-edit-" + item.id })
                        .text("Edit")
                        .click(function (e) {
                            document.location.href = "/User/EditUser/" + item.id;
                            e.stopPropagation();
                        });
                    var $customDeleteButton = $("<button>")
                        .attr({ class: "btn btn-outline-danger btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.deleteButtonTooltip })
                        .text("Delete")
                        .attr({ id: "btn-delete-" + item.id })
                        .click(function (e) {
                            $('#userModal').modal('show');
                            $('#userId').text(item.id);
                            $('#message').text("Da li zelite da uklonite " + item.firstName + " " + item.lastName + " korisnika?");
                            e.stopPropagation();
                        });

                    return $("<div>")
                        .append($customEditButton)
                        .append($customDeleteButton);
                }
            }
        ]
    });



})(jQuery);

