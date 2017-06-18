var repairList;
$(document).ready(function () {
    var table = $('#repairList').DataTable();
    //From layoutHome hidden apiKey
    var api = $("#apiKey").val();
    var url = api + "Repair/Home/GetAll";
    $.ajax({
        "type": "GET",
        //"url": "http://localhost:47268/API/Customer/Home/GetAll",
        "url": url,
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (json) {
            //customerList = JSON.stringify(json.Data);
            repairList = json.Data;
            table.destroy();
            table = $('#repairList').DataTable({
                "processing": true,
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                buttons: [
                     'copy', 'excel', 'print'
                ],
                "data": repairList,
                "columns": [
                            {
                                "data": "Id",
                                "name": "Id"
                            },
                            {
                                "data": "RepairNumber",
                                "name": "RepairNumber"
                            },
                            {
                                "data": "RepairType",
                                "name": "RepairType"
                            },
                            {
                                "data": "CustomerName",
                                "name": "CustomerName"
                            },
                            {
                                "data": "Date_Time",
                                "name": "Date_Time"
                            },

                            {
                                "data": "Make",
                                "name": "Make"
                            },
                            {
                                "data": "Model",
                                "name": "Model"
                            },
                            {
                                "data": "UnitNumber",
                                "name": "UnitNumber"
                            },
                            {
                                "data": "SerialNumber",
                                "name": "SerialNumber"
                            },
                            {
                                "data": "MachineHours",
                                "name": "MachineHours"
                            },
                            {
                                "data": "MachineMiles",
                                "name": "MachineMiles"
                            },

                            {
                                "data": "Labor",
                                "name": "Labor"
                            },
                              {
                                  "data": "Parts",
                                  "name": "Parts"
                              },

                              {
                                  "data": "PartsCost",
                                  "name": "PartsCost"
                              },
                              {
                                  "data": "LaborHours",
                                  "name": "LaborHours"
                              },
                               {
                                   "data": "TotalBill",
                                   "name": "TotalBill"
                               }
                ],
                "columnDefs": [
                   
                    {
                        "targets": [0],
                        "visible": false,
                        "searchable": false
                    },
                        {
                            "targets": [1],

                            "render": function (data, type, row) {
                                    return '<a href="../Repair/Details?Id=' + row.Id + '"  onclick="executeSearch(' + row.Id + ')">' + row.RepairNumber + '</a>';
                            }
                        },
                        {
                            "targets": [4],
                            "render": function (value) {
                                return $.formatDate(value);
                            }

                        },
                        {
                             "targets": [11],
                             "render": function (value) {
                                 return $.formatToCurrency(value);
                             }
                        },
                        {
                            "targets": [13],
                            "render": function (value) {
                                return $.formatToCurrency(value);
                            }
                        },
                        {
                            "targets": [15],
                            "render": function (value) {
                                return $.formatToCurrency(value);
                            }
                        },

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
        if (toFormat == undefined)
        {
            return converted;
        }
           
        var converted = "$" + toFormat.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,");
        
        return converted;
    }

    //$('#name').on('change', function () {
    //    table
    //    .column(1)
    //    .search(this.value)
    //    .draw();
    //});

    //$('#contact').on('change', function () {
    //    table
    //    .column(2)
    //    .search(this.value)
    //    .draw();
    //});

    //$('#position').on('change', function () {
    //    table
    //    .column(3)
    //    .search(this.value)
    //    .draw();
    //});

    //$('#phone').on('change', function () {
    //    table
    //    .column(4)
    //    .search(this.value)
    //    .draw();
    //});
    //$('#fax').on('change', function () {
    //    table
    //    .column(5)
    //    .search(this.value)
    //    .draw();
    //});

    //$('#email').on('change', function () {
    //    table
    //    .column(6)
    //    .search(this.value)
    //    .draw();
    //});
    //$('#billingContact').on('change', function () {
    //    table
    //    .column(7)
    //    .search(this.value)
    //    .draw();
    //});

    //$('#billingEmail').on('change', function () {
    //    table
    //    .column(8)
    //    .search(this.value)
    //    .draw();
    //});
    //$('#billingPhone').on('change', function () {
    //    table
    //    .column(9)
    //    .search(this.value)
    //    .draw();
    //});
    //$('#taxExcempt').on('change', function () {
    //    table
    //    .column(10)
    //    .search(this.value)
    //    .draw();
    //});
    //$('#taxJurisdiction').on('change', function () {
    //    table
    //    .column(10)
    //    .search(this.value)
    //    .draw();
    //});
    //$('#taxClassification').on('change', function () {
    //    table
    //    .column(10)
    //    .search(this.value)
    //    .draw();
    //});
});

$(document).ajaxStart(function () {
    $.blockUI({
        message: $('#processingDiv')
    });
});

$(document).ajaxComplete(function (event, xhr, settings) {
    $.unblockUI();
});
