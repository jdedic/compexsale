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
                    url: "/SubCategory/Get",
                    data: filter,
                    dataType: "json"
                });
            },
            updateItem: function (item) {
                return $.ajax({
                    type: "GET",
                    url: "/SubCategory/EditSubCategory" + item,
                    data: item,
                    dataType: "json"
                });
            },
        },
        fields: [
            { name: "name", type: "text", width: 100, title: "Name" },
            { name: "category", type: "text", width: 100, title: "Category" },
            {
                type: "control", editButton: false, deleteButton: false,
                itemTemplate: function (value, item) {

                    var $customEditButton = $("<button>")
                        .attr({ class: "btn btn-outline-warning btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.editButtonTooltip })
                        .attr({ id: "btn-edit-" + item.id })
                        .text("Edit")
                        .click(function (e) {
                            var url = "/SubCategory/EditSubCategory"
                            $.get(url, { id: item.id }, function (data) {
                                $('#subCategoryModalContent').html(data);
                                $('#subCategoryModal').modal('show');
                            });
                            e.stopPropagation();
                        });
                    var $customDeleteButton = $("<button>")
                        .attr({ class: "btn btn-outline-danger btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.deleteButtonTooltip })
                        .text("Delete")
                        .attr({ id: "btn-delete-" + item.id })
                        .click(function (e) {
                            $('#subCategoryDeleteModal').modal('show');
                            $('#subCategoryId').text(item.id);
                            if (item.isAssigned) {
                                $('#message').text("Ne možete ukloniti potkategoriju, jer je potkategorija dodeljena jednom od proizvoda.");
                            } else {
                                $('#message').text("Da li zelite da uklonite " + item.name + " potkategoriju?");
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

