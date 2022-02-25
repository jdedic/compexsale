﻿function returnToAdds() {
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

function handleClick() {
    var x = document.getElementById("compesation");
    if (x.classList.contains('d-none')) {
        x.classList.remove('d-none');
    } else {
        x.classList.add('d-none');
    }
}

function filterAdds() {
    var category = $("#categoryId").val() !== "" ? parseInt($("#categoryId").val()) : 0;
    var location = $("#location").val();
    var name = $("#name").val();

    $.ajax({
        type: "POST",
        url: '/Product/FilterProduct',
        data: { categoryId: category, location: location, name: name },
        datatype: "json",
        success: function (data) {
            var addsTable = $("#adds");
            addsTable.empty();

            if (data.adds.length !== 0) {
                for (i = 0; i < data.adds.length; i++) {

                    addsTable.append(` <div class="col-3">
                               <div class="cycle-box">
                                    <div class="product-detail">
                                        <a href="/Product/ProductPreview/${data.adds[0].id}">
                                            <h4>${data.adds[0].name}</h4>
                                        </a>
                                        <ul class="details">
                                            <li><i class="fa fa-user-o" aria-hidden="true"></i> Datum oglašavanja:</li>
                                            <li>
                                                <i aria-hidden="true"></i> ${data.adds[0].publicationDate}
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="img-wrapper">
                                        <a href="/Product/ProductPreview/${data.adds[0].id}">
                                           <img src="${data.adds[0].imagePath}"
                                               class="img-fluid blur-up lazyload bg-img" alt="">
                                        </a>
                                                </div>
                                                <div class="bottom-detail">
                                                    <div>
                                                        <h5>KATEGORIJA: ${data.adds[0].category}</h5>
                                                    </div>
                                                </div>
                                                <ul class="cart-detail">
                                                    <li>
                                                        <a href="/Product/ProductPreview/${data.adds[0].id}" title="Pošalji upit" tabindex="0">
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