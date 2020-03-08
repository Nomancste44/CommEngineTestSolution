$(document).ready(function () {
    //Load all available products
    $('#btnLoadProduct').click(function () {
        $.ajax({
            url: '/api/products/GetAllProducts',
            method: 'GET',
            success: function (data) {
                $('#tblBody').empty();
                $.each(data, function (index, value) {
                    var row = $('<tr><td class="hide"> ' + value.ProductId + '</td><td>'
                        + value.ProductName + '</td><td>'
                        + value.ProductCategoryName + '</td><td>'
                        + value.ProductPrice + '</td><td>'
                        + value.ManufacturedDate + '</td><td>'
                        + value.ExpiredDate + '</td>'
                        + '<td><input type="button" class="btn btn-success editProduct" value="Edit"/>' + '</td>'
                        + '<td><input type="button" class="btn btn-danger deleteProduct" value="Delete"/>' + '</td></tr>');
                    $('#tblData').append(row);
                });
            }
        });
    });
    //Open up the product creational modal
    $('#btnCreateProduct').click(function () {
        $('#createModal').modal('show');
    });
});
