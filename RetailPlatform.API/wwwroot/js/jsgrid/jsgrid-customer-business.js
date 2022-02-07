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
                    url: "/Customer/BusinessAccounts",
                    data: filter,
                    dataType: "json"
                });
            },
            updateItem: function (item) {
                return $.ajax({
                    type: "GET",
                    url: "/Customer/EditBusinessAccount" + item,
                    data: item,
                    dataType: "json"
                });
            },
        },
        fields: [
            { name: "companyName", type: "text", width: 100, title: "Naziv kompanije" },
            { name: "pib", type: "text", width: 100, title: "PIB" },
            { name: "email", width: 100, title: "Email" },
            { name: "telephone", width: 100, title: "Telefon" },
            { name: "zipCode", width: 50, title: "Poštanski broj" },
            { name: "city", width: 60, title: "Grad" },
            {
                type: "control", editButton: false, deleteButton: false,
                itemTemplate: function (value, item) {

                    var $customEditButton = $("<button>")
                        .attr({ class: "btn btn-outline-warning btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.editButtonTooltip })
                        .attr({ id: "btn-edit-" + item.id })
                        .text("Edit")
                        .click(function (e) {
                            document.location.href = "/Customer/EditBusinessAccount/" + item.id;
                            e.stopPropagation();
                        });
                    var $customDeleteButton = $("<button>")
                        .attr({ class: "btn btn-outline-danger btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.deleteButtonTooltip })
                        .text("Delete")
                        .attr({ id: "btn-delete-" + item.id })
                        .click(function (e) {
                            $('#vendorModal').modal('show');
                            $('#customerId').text(item.id);
                            $('#message').text("Da li zelite da uklonite " + item.companyName + " klijenta?");
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

