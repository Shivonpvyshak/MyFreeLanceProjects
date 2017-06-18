$.getAllCustomers = function (extended) {
    var customerList;
        var api = $("#apiKey").val();
        var url = api + "Customer/List";
        $.ajax({
            "type": "GET",
            //"url": "http://localhost:47268/API/Customer/List",
            "url": url,
            "contentType": "application/json; charset=utf-8",
            "dataType": "json",
            "success": function (data) {
                customerList = data.Data;
                $("#customerName").autocomplete({
                    source: customerList,
                    change: function (event, ui) {
                        if (extended === true) {
                            if (ui.item == null) {
                                $("#customerName").val('');
                                $("#customerName").focus();

                                $("#address1").val('');
                                $("#address2").val('');
                                $("#city").val('');
                                $("#state").val('');
                                $("#zip").val('');

                                $("#ShippingAddress1").val('');
                                $("#ShippingAddress2").val('');
                                $("#ShippingCity").val('');
                                $("#ShippingState").val('');
                                $("#ShippingZip").val('');
                            }
                        }
                    },
                    focus: function (event, ui) {
                        $("#customerName").val(ui.item.value);
                        return false;
                    },
                    select: function (event, ui) {
                        if (extended === true) {
                            $("#address1").val(ui.item.Address1);
                            $("#address2").val(ui.item.Address2);
                            $("#city").val(ui.item.City);
                            $("#state").val(ui.item.State);
                            $("#zip").val(ui.item.Zip);
                           

                            $("#ShippingAddress1").val(ui.item.ShippingAddress1);
                            $("#ShippingAddress2").val(ui.item.ShippingAddress2);
                            $("#ShippingCity").val(ui.item.ShippingCity);
                            $("#ShippingState").val(ui.item.ShippingState);
                            $("#ShippingZip").val(ui.item.ShippingZip);
                        }
                        $("#customerId").val(ui.item.ID);
                        return false;
                    }
                });
            },
            "error": function (request, error) {
                alert("Request: " + JSON.stringify(request));
            }
        });
}