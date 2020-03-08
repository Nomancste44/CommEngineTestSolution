//To load all available categories in drop-down
$('#productCategory').on('click', function () {
    $.ajax({
        url: '/api/ProductCategory/GetAllProductCategories',
        type: 'GET',
        success: function (data) {
            $('#productCategoryMenuList').empty();
            $.each(data, function (index, value) {
                var anItem = $('<li><a href="#" data-value="' + value.ProductCategoryId + '">' + value.CategoryName + '</a></li>');

                $('#productCategoryMenuList').append(anItem);
            });
        }
    });
});

//To set the selected category from the categories drop-down
$(function () {
    $(document).on("click", '.dropdown-menu li a', function () {
        $(this).parents(".dropdown").find('.btn').html($(this).text() + ' <span class="caret"></span>');
        $(this).parents(".dropdown").find('.btn').val($(this).data('value'));
    });
});

//Close the error alert for Bad Creating request
$('#linkClose').click(function () {
    $('#divError').hide('fade');
});

//Create a new product
$('#btnSaveProduct').on('click', function () {
    var product = {
        ProductCategoryId: $("#productCategory").val(),
        ProductName: $("#productName").val(),
        ManufacturedDate: $("#mdatetimepicker").val(),
        ExpiredDate: $("#edatetimepicker").val(),
        ProductPrice: $("#productPrice").val()
    };
    $.ajax({
        type: 'POST',
        data: JSON.stringify(product),
        url: '/api/Products/CreateProduct',
        contentType: "application/json",
        success: function (data) {
            $('#createModal').modal('toggle');
            $('#tblBody').empty();
            $.each(data, function (index, value) {
                var row = $('<tr><td class="hide"> ' + value.ProductId + '</td><td>'
                    + value.ProductName + '</td><td>'
                    + value.ProductCategoryId + '</td><td>'
                    + value.ProductPrice + '</td><td>'
                    + value.ManufacturedDate + '</td><td>'
                    + value.ExpiredDate + '</td>'
                    + '<td><input type="button" class="btn btn-success editProduct" value="Edit"/>' + '</td>'
                    + '<td><input type="button" class="btn btn-danger deleteProduct" value="Delete"/>' + '</td></tr>');
                $('#tblData').append(row);
            });
        },
        error: function (jqXhr) {
            $('#divErrorText').text(jqXhr.responseText);
            $('#divError').show('fade');
        }
    });
});
