$(function () {
      
});



$.generateReport = function () {
    var table = $('#generalReport').DataTable();
    //From layoutHome hidden apiKey
    var api = $("#apiKey").val();
    var url = api + "Invoice/GetInvoiceGeneralReportData?invoiceType=" + $("#invStatus option:selected").text();

    if ($('#txtFromDate').val() != undefined && $('#txtFromDate').val() != "")
    {
        url = url + "&fromDate=" + $('#txtFromDate').val();
    }
    if ($('#txtToDate').val() != undefined && $('#txtToDate').val() != "") {
        url = url + "&toDate=" + $('#txtToDate').val();
    }
    if ($('#Part').val() != undefined && $('#Part').val() != "") {
        url = url + "&partsDescription=" + $('#Part').val();
    }
    if ($('#Customer').val() != undefined && $('#Customer').val() != "") {
        url = url + "&customerName=" + $('#Customer').val();
    }


    $.ajax({
        "type": "GET",
        "url": url,
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (json) {
          
            data = json.Data;
            table.destroy();
            $('#generalReport').show();
           table = $('#generalReport').DataTable({
                "processing": true,
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                buttons: [
                     'copy', 'excel', 'print'
                ],
                "data": data,
                "columns": [
                            {
                                "data": "InvoiceType",
                                "name": "InvoiceType"
                            },
                            {
                                "data": "InvoiceNumber",
                                "name": "InvoiceNumber"
                            },
                            {
                                "data": "Name",
                                "name": "Name"
                            },
                            {
                                "data": "PartsSubTotal",
                                "name": "PartsSubTotal"
                            },
                            {
                                "data": "LaborSubTotal",
                                "name": "LaborSubTotal"
                            },

                            {
                                "data": "InvoiceDate",
                                "name": "InvoiceDate"
                            },
                            {
                                "data": "Total",
                                "name": "Total"
                            },
                            {
                                "data": "BalanceDue",
                                "name": "BalanceDue"
                            }
                ],
                "columnDefs": [

                   
                        //{
                        //    "targets": [1],

                        //    "render": function (data, type, row) {
                        //        return '<a href="../Repair/Details?Id=' + row.Id + '"  onclick="executeSearch(' + row.Id + ')">' + row.RepairNumber + '</a>';
                        //    }
                        //},
                        {
                            "targets": [5],
                            "render": function (value) {
                                return $.formatDate(value);
                            }

                        },
                        {
                            "targets": [3],
                            "render": function (value) {
                                return $.formatToCurrency(value);
                            }
                        },
                        {
                            "targets": [4],
                            "render": function (value) {
                                return $.formatToCurrency(value);
                            }
                        },
                        {
                            "targets": [6],
                            "render": function (value) {
                                return $.formatToCurrency(value);
                            }
                        },
                        {
                            "targets": [7],
                            "render": function (value) {
                                return $.formatToCurrency(value);
                            }
                        }

                ],
                dom: "<'row'<'col-sm-6'l><'col-sm-6'f><'col-sm-12'rt>><'row'<'col-sm-5'i><'col-sm-7'p>>B"
            });
        },
        "error": function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
    $.formatDate = function (value) {
        if (value === null || value === undefined) return "";
        var trimmedDate = value.substr(0, 10);
        var mm = trimmedDate.substr(5, 2);
        var dd = trimmedDate.substr(8, 2);
        var yyyy = trimmedDate.substr(0, 4);
        return mm + "/" + dd + "/" + yyyy;
    }

    $.formatToCurrency = function (toFormat) {
        var converted = "$0.00";
        if (toFormat == undefined) {
            return converted;
        }

        var converted = "$" + toFormat.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,");

        return converted;
    }
}


//$(document).ajaxStart(function () {
//    $.blockUI({
//        message: $('#processingDiv')
//    });
//});

//$(document).ajaxComplete(function (event, xhr, settings) {
//    $.unblockUI();
//});