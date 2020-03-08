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
    $(function() {
        $(document).on("click", ".editProduct", function() {

            var productId = $(this).parents().eq(1).find('.hide').text();
            
            $.ajax({
                url: '/api/products/GetAProduct/?productId=' + productId,
                method: 'GET',
                success: function (data) {
                    $('#editModal').modal('show');
                    console.log(data);
                    var date = new Date(parseInt(data.ManufacturedDate.substr(6)));
                    var day = ("0" + date.getDate()).slice(-2);
                    var month = ("0" + (date.getMonth() + 1)).slice(-2);
                    var eDate = new Date(parseInt(data.ExpiredDate.substr(6)));
                    var eDay = ("0" + eDate.getDate()).slice(-2);
                    var eMonth = ("0" + eDate.getMonth()).slice(-2);
                    $(function() {
                        $(document).on("click", '.editDropDownMenu li a', function () {
                            $(this).parents(".dropdown").find('.btn').html('');
                            $(this).parents(".dropdown").find('.btn').html(data.ProductCategoryName + ' <span class="caret"></span>');
                            $(this).parents(".dropdown").find('.btn').val(data.ProductCategoryId);
                        });
                    });
                    $("#editProductName").val(data.ProductName);
                    $("#editMdatetimepicker").val((month) + "/" + (day) + "/" + date.getFullYear());
                    $("#editEdatetimepicker").val((eMonth) + "/" + (eDay) + "/" + eDate.getFullYear());
                    $("#editProductPrice").val(data.ProductPrice);
                }
            });
        });
    });
});
