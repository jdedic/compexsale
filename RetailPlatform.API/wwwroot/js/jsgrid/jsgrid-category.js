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
            updateItem: function (item) {
                return $.ajax({
                    type: "GET",
                    url: "/Category/EditCategory" + item,
                    data: item,
                    dataType: "json"
                });
            },
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
                            var url = "/Category/EditCategory"
                            $.get(url, { id: item.id }, function (data) {
                                $('#myModalContent').html(data);
                                $('#myModal').modal('show');
                            });
                            e.stopPropagation();
                        });
                    var $customDeleteButton = $("<button>")
                        .attr({ class: "btn btn-outline-danger btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.deleteButtonTooltip })
                        .text("Delete")
                        .attr({ id: "btn-delete-" + item.id })
                        .click(function (e) {
                            $('#categoryModal').modal('show');
                            $('#categoryId').text(item.id);
                            if (item.isAssigned) {
                                $('#message').text("Ne možete ukloniti kategoriju, jer je kategorija dodeljena jednom od proizvoda.");
                            } else {
                                $('#message').text("Da li zelite da uklonite " + item.name + " kategoriju?");
                            }
                            
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

