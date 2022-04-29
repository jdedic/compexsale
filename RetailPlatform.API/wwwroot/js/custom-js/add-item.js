function returnToAdds() {
    window.location.href = "/adds";
}

function returnFilteredPage(name) {
    window.location.href = `/Home/AddsGrid?title=${name}`;
    //$.ajax({
    //    type: "POST",
    //    url: '/Home/AddsGrid',
    //    data: { title: name },
    //    datatype: "json",
    //    success: function (data) {
           
    //    },
    //    error: function () {
    //        alert("Dynamic content load failed.");
    //    }
    //});
}

function returnFilteredRequestPage(name) {
    window.location.href = `/Home/RequestsGrid?title=${name}`;
}

function handleClick() {
    var x = document.getElementById("compesation");
    if (x.classList.contains('d-none')) {
        x.classList.remove('d-none');
    } else {
        x.classList.add('d-none');
    }
}

function filterProfiles() {
    var checkbox = document.getElementById('legal');
    var checked = checkbox.checked;
    $.ajax({
        type: "POST",
        url: '/Product/FilterVendors',
        data: { isLegalEntity: checked },
        datatype: "json",
        success: function (data) {
            $('#vendor').empty();
            $('#vendor').append(`<option value>
                                       Selektuj osobu
                                  </option>`);

            if (data.vendors.length !== 0) {
                for (i = 0; i < data.vendors.length; i++) {
                    $('#vendor').append(`<option value="${data.vendors[i].value}">
                                       ${data.vendors[i].text}
                                  </option>`);
                }
            }

        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
}

function filterAdds() {
    var jobType = $("#jobTypeId").val() !== '' ? parseInt($("#jobTypeId").val()) : 0;
    var category = $("#categoryId").val() !== '' ? parseInt($("#categoryId").val()) : 0;
    var location = $("#location").val() !== '' ? $("#location").val() : null;
    var name = $("#name").val() != '' ? $("#name").val() : null;

    $.ajax({
        type: "POST",
        url: '/Product/FilterProduct',
        data: { categoryId: category, location: location, name: name, jobType: jobType },
        datatype: "json",
        success: function (data) {
            var addsTable = $("#adds");
            addsTable.empty();

            if (data.adds.length !== 0) {
                for (i = 0; i < data.adds.length; i++) {

                    addsTable.append(` <div class="col-3">
                               <div class="cycle-box">
                                    <div class="product-detail">
                                        <a>
                                            <h4>${data.adds[i].name}</h4>
                                        </a>
                                        <ul class="details">
                                            <li><i class="fa fa-user-o" aria-hidden="true"></i> Datum oglašavanja:</li>
                                            <li>
                                                <i aria-hidden="true"></i> ${data.adds[i].publicationDate}
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="img-wrapper">
                                        <a>
                                           <img src="${data.adds[i].imagePath}"
                                               class="img-fluid blur-up lazyload bg-img" alt="">
                                        </a>
                                                </div>
                                                <div class="bottom-detail">
                                                    <div>
                                                        <h5>KATEGORIJA: ${data.adds[i].category}</h5>
                                                    </div>
                                                </div>
                                                <ul class="cart-detail">
                                                    <li>
                                                        <a href="/Product/ProductPreview/${data.adds[i].id}" title="Pošalji upit" tabindex="0">
                                                            <i data-feather="refresh-ccw"></i>DETALJI
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="/Client/Contact" title="Pošalji upit" tabindex="0">
                                                            <i data-feather="refresh-ccw"></i>POŠALJI UPIT
                                                        </a>
                                                    </li>
                                                </ul>
                               </div>
                             </div>`);
                }
            }

        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });

}