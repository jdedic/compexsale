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
                    url: "/Vendor/BusinessAccounts",
                    data: filter,
                    dataType: "json"
                });
            },
            updateItem: function (item) {
                return $.ajax({
                    type: "GET",
                    url: "/Vendor/EditBusinessAccount" + item,
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
                        .text("Izmeni")
                        .click(function (e) {
                            document.location.href = "/Vendor/EditBusinessAccount/" + item.id;
                            e.stopPropagation();
                        });
                    var hasAdds = item.isAssigned;
                    var deleteStyle = hasAdds == true ? "d-none" : "";
                    var $customDeleteButton = $("<button>")
                        .attr({ class: "btn btn-outline-danger btn-xs" })
                        .attr({ title: jsGrid.fields.control.prototype.deleteButtonTooltip })
                        .text("Ukloni")
                        .attr({ id: "btn-delete-" + item.id })
                        .click(function (e) {
                            $('#vendorModal').modal('show');
                            $('#vendorId').text(item.id);
                            $('#message').text("Da li zelite da uklonite " + item.companyName + " vendora?");
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

