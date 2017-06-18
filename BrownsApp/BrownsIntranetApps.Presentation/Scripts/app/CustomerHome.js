var customerList;
$(document).ready(function () {
    var table = $('#cutomerList').DataTable();

    // var json = [{ "ID": 14, "Name": "S CUSTOMER", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 15, "Name": "TEST CUST PART", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 16, "Name": "rtretert", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 17, "Name": "terterter", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 18, "Name": "gdfgdfg", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 19, "Name": "sdfsdf", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 20, "Name": "sdfdsf", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 24, "Name": "Test Customer", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 25, "Name": "S10 Customer", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 26, "Name": "sddsfd", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 27, "Name": "sdadsa", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 28, "Name": "P2 Cust", "Contact": null, "Position": null, "PhoneNumber": null, "Fax": null, "Email": null, "BillingContact": null, "BillingEmail": null, "BillingPhone": null, "TaxExcemptNumber": null, "TaxJurisdiction": null, "TaxClassification": null }, { "ID": 29, "Name": "hkjhjkh", "Contact": "jhjkhjkh", "Position": "jhkjhj", "PhoneNumber": "jkhkjh", "Fax": "hjhjkh", "Email": "jhkjhkj", "BillingContact": "jhkjhj", "BillingEmail": "jkhkjh", "BillingPhone": "hjhkjh", "TaxExcemptNumber": "jkhjkh", "TaxJurisdiction": "IOWA-Tax", "TaxClassification": "RegularTax" }];

    
    var api = $("#apiKey").val();
    var url = api + "Customer/Home/GetAll";
     $.ajax({
        "type": "GET",
        //"url": "http://localhost:47268/API/Customer/Home/GetAll",
        "url": url,
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (json) {
            //customerList = JSON.stringify(json.Data);
            customerList = json.Data;
            table.destroy();
            table = $('#cutomerList').DataTable({
                "processing": true,
                "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                buttons: [
                     'copy', 'excel', 'print'
                ],
                "data": customerList,
                "columns": [
                            {
                                "data": "ID",
                                "name": "Id"
                            },
                            {
                                "data": "Name",
                                "name": "Name"
                            },
                            {
                                "data": "Contact",
                                "name": "Contact"
                            },
                            {
                                "data": "Position",
                                "name": "Position"
                            },

                            {
                                "data": "PhoneNumber",
                                "name": "Phone#"
                            },
                            {
                                "data": "Fax",
                                "name": "Fax"
                            },
                            {
                                "data": "Email",
                                "name": "Email"
                            },
                            {
                                "data": "BillingContact",
                                "name": "Billing Contact"
                            },
                            {
                                "data": "BillingEmail",
                                "name": "Billing Email"
                            },
                            {
                                "data": "BillingPhone",
                                "name": "Billing Phone"
                            },
                            {
                                "data": "TaxExcemptNumber",
                                "name": "Tax Excempt#"
                            },
                            {
                                "data": "TaxJurisdiction",
                                "name": "Tax Jurisdiction"
                            },
                              {
                                  "data": "TaxClassification",
                                  "name": "Tax Classification"
                              }
                ],
                "columnDefs": [
                    { "width": "6%", "targets": [4] },
                        { "width": "6%", "targets": [5] },
                        { "width": "6%", "targets": [9] },
                        { "width": "6%", "targets": [10] },
                        { "width": "6%", "targets": [11] },
                        { "width": "6%", "targets": [12] },
                        {
                            "targets": [0],
                            "visible": false,
                            "searchable": false
                        },

                        {
                            "targets": [1],

                            "render": function (data, type, row) {
                                //Used to get around issue where you cant use javascript in actionlink
                                //var links = '@Html.ActionLink(' + row.Name + ', "Edit", new { id = -1 })' ;
                                //links = links.replace(/-1/g, row.ID);
                                //return links;

                                return '<a href="../Customer/SearchCustomer?customerId=' + row.ID + '"  onclick="executeSearch(' + row.ID + ')">' + row.Name + '</a>';
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

    $('#name').on('change', function () {
        table
        .column(1)
        .search(this.value)
        .draw();
    });

    $('#contact').on('change', function () {
        table
        .column(2)
        .search(this.value)
        .draw();
    });

    $('#position').on('change', function () {
        table
        .column(3)
        .search(this.value)
        .draw();
    });

    $('#phone').on('change', function () {
        table
        .column(4)
        .search(this.value)
        .draw();
    });
    $('#fax').on('change', function () {
        table
        .column(5)
        .search(this.value)
        .draw();
    });

    $('#email').on('change', function () {
        table
        .column(6)
        .search(this.value)
        .draw();
    });
    $('#billingContact').on('change', function () {
        table
        .column(7)
        .search(this.value)
        .draw();
    });

    $('#billingEmail').on('change', function () {
        table
        .column(8)
        .search(this.value)
        .draw();
    });
    $('#billingPhone').on('change', function () {
        table
        .column(9)
        .search(this.value)
        .draw();
    });
    $('#taxExcempt').on('change', function () {
        table
        .column(10)
        .search(this.value)
        .draw();
    });
    $('#taxJurisdiction').on('change', function () {
        table
        .column(10)
        .search(this.value)
        .draw();
    });
    $('#taxClassification').on('change', function () {
        table
        .column(10)
        .search(this.value)
        .draw();
    });
});

$(document).ajaxStart(function () {
    $.blockUI({
        message: $('#processingDiv')
    });
});

$(document).ajaxComplete(function (event, xhr, settings) {
    $.unblockUI();
});
