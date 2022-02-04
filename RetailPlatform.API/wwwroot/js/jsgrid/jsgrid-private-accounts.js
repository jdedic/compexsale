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
                    url: "/Vendor/PrivateAccounts",
                    data: filter,
                    dataType: "json"
                });
            },
            updateItem: function (item) {
                return $.ajax({
                    type: "GET",
                    url: "/Vendor/EditVendor" + item,
                    data: item,
                    dataType: "json"
                });
            },
        },
        fields: [
            { name: "fullName", type: "text", width: 100, title: "Ime i prezime" },
            { name: "jmbg", type: "text", width: 100, title: "JMBG" },
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
                            document.location.href = "/Vendor/EditVendor/" + item.id;
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

