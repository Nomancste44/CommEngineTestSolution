//To load all available categories in drop-down
$('#editProductCategory').on('click', function () {
    $.ajax({
        url: '/api/ProductCategory/GetAllProductCategories',
        type: 'GET',
        success: function (data) {
            $('#editProductCategoryMenuList').empty();
            $.each(data, function (index, value) {
                var anItem = $('<li><a href="#" data-value="' + value.ProductCategoryId + '">' + value.CategoryName + '</a></li>');

                $('#editProductCategoryMenuList').append(anItem);
            });
        }
    });
});

//To set the selected category from the categories drop-down
$(function () {
    $(document).on("click", '.editDropDownMenu li a', function () {
        $(this).parents(".dropdown").find('.btn').html($(this).text() + ' <span class="caret"></span>');
        $(this).parents(".dropdown").find('.btn').val($(this).data('value'));
    });
});

//Close the error alert for Bad Creating request
$('#editLinkClose').click(function () {
    $('#editDivError').hide('fade');
});

//Create a new product
$('#btnUpdateProduct').on('click', function () {
    var product = {
        ProductCategoryId: $("#editProductCategory").val(),
        ProductName: $("#editProductName").val(),
        ManufacturedDate: $("#editMdatetimepicker").val(),
        ExpiredDate: $("#editEdatetimepicker").val(),
        ProductPrice: $("#editProductPrice").val()
    };
    $.ajax({
        type: 'PUT',
        data: JSON.stringify(product),
        url: '/api/Products/UpdateProduct',
        contentType: "application/json",
        success: function (data) {
            $('#editModal').modal('toggle');
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
            $('#editDivErrorText').text(jqXhr.responseText);
            $('#editDivError').show('fade');
        }
    });
});
