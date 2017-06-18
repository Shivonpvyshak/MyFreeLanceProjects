$(document).ready(function () {
    $.getAllCustomers(true);

    var d = new Date($("#invSelectedDateModel").val());
    var resultDate = d.getFullYear() + "-" + ("00" + (d.getMonth() + 1)).slice(-2) + "-" + ("00" + d.getDate()).slice(-2) + "T" + ("00" + d.getHours()).slice(-2) + ":" + ("00" + d.getMinutes()).slice(-2);
    document.getElementById("invSelectedDate").value = resultDate;

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
