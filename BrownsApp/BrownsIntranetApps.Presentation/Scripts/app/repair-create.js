$(document).ready(function () {
    $.getAllCustomers(true);
    //var myDate = new Date();
    //var prettyDate = (myDate.getMonth() + 1) + '/' + myDate.getDate() + '/' +
    //        myDate.getFullYear();
    //$("#invSelectedDate").val(prettyDate);

   

});

$(document).on('change', ':file', function () {

    if ($(this)["0"].id === "VendorInvoicesFileBase")
    {
        var input = $(this),
            numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
        $("#lblVendorInvoice").text(label);
    input.trigger('fileselect', [numFiles, label]);
    }
    else if ($(this)["0"].id === "ServiceReportBillFileBase")
    {   
        var input = $(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
            label = input.val().replace(/\\/g, '/').replace(/.*\//, '');

        $("#lblServiceReportBillFile").text(label);
        input.trigger('fileselect', [numFiles, label]);
    }
});

$.actionOnCreateButtonClick = function () {

     //$("#invDate").val($("#invSelectedDate").val());
}