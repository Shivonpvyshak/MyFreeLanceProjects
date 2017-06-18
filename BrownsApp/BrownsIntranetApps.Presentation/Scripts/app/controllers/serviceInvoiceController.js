(function () {
    'use strict';

    angular.module('theApp').controller('serviceInvoiceController',
        function ($scope, $filter, $http, $location, $window, notificationService, stateDataService, laborDataService, invoiceStatusDataService, paymentStatusDataService,
                            shippingMethodDataService, serviceInvoiceDataService,countydataservice) {
            //Add PartInvoice Item to List
            //------------------------------------------------------------------------------------------------------------
            $scope.addPartItem = function (partItem) {
                var item = {
                    Quantity: partItem.addedquantity,
                    Description: partItem.addeddescription,
                    Price: partItem.addedprice,
                    Total: partItem.addedprice * partItem.addedquantity,
                    RecordStatus: 'ACTIVE'
                };

                if ($scope.InvoiceDTO == null) {
                    $scope.InvoiceDTO = {
                        InvoiceItems: [{
                            Quantity: partItem.addedquantity,
                            Description: partItem.addeddescription,
                            Price: partItem.addedprice,
                            Total: partItem.addedprice * partItem.addedquantity,
                            RecordStatus: 'ACTIVE'
                        }]
                    };
                }
                else {
                    if ($scope.InvoiceDTO != null && $scope.InvoiceDTO.InvoiceItems == null) {
                        $scope.InvoiceDTO.InvoiceItems = [];
                        $scope.InvoiceDTO.InvoiceItems.push(item);
                    }
                    else {
                        $scope.InvoiceDTO.InvoiceItems.push(item);
                    }
                }

                $scope.partItem.addedquantity = "";
                $scope.partItem.addeddescription = "";
                $scope.partItem.addedprice = "";

                if ($scope.InvoiceDTO.PartsSubTotal == null)
                    $scope.InvoiceDTO.PartsSubTotal = 0;

                $scope.InvoiceDTO.PartsSubTotal = $scope.InvoiceDTO.PartsSubTotal + item.Total;
            };

            //------------------------------------------------------------------------------------------------------------

            //Remove items from Part Item List
            //------------------------------------------------------------------------------------------------------------

            $scope.removePartItem = function (partItem) {
                $scope.InvoiceDTO.PartsSubTotal = $scope.InvoiceDTO.PartsSubTotal - partItem.Total;
                $scope.InvoiceDTO.InvoiceItems[$scope.InvoiceDTO.InvoiceItems.indexOf(partItem)].RecordStatus = "Deleted";
                //$scope.InvoiceDTO.InvoiceItems.splice($scope.InvoiceDTO.InvoiceItems.indexOf(partItem), 1);
            };
            //------------------------------------------------------------------------------------------------------------

            //Loading the dropdowns
            //------------------------------------------------------------------------------------------------------------

            $scope.allStates = stateDataService.getStates();
            $scope.allLaborTypes = laborDataService.getLaborTypes();
            $scope.allInvoiceStatuses = invoiceStatusDataService.getInvoiceStatuses();
            $scope.allPaymentStatuses = paymentStatusDataService.getPaymentStatuses();
            $scope.allShppingMethods = shippingMethodDataService.getshippingMethods();
            $scope.allCounties = countydataservice.getCounties();
            //------------------------------------------------------------------------------------------------------------

            $('#dpInvoiceDate').datetimepicker();
            $('#divServiceStartDate').datetimepicker();
            $('#divServiceEndDate').datetimepicker();

            //Add Labor
            //------------------------------------------------------------------------------------------------------------
            $scope.addLabor = function (servicelabor) {
                var labor = {
                    LaborType: servicelabor.laborType,
                    Hours: servicelabor.addeddHours,
                    Rate: servicelabor.addedrate,
                    Amount: servicelabor.addeddHours * servicelabor.addedrate,
                    RecordStatus: 'ACTIVE'
                };

                if ($scope.InvoiceDTO == null) {
                    $scope.InvoiceDTO = {
                        InvoiceLabors: [{
                            LaborType: servicelabor.laborType,
                            Hours: servicelabor.addeddHours,
                            Rate: servicelabor.addedrate,
                            Amount: servicelabor.addeddHours * servicelabor.addedrate,
                            RecordStatus: 'ACTIVE'
                        }]
                    };
                }
                else {
                    if ($scope.InvoiceDTO != null && $scope.InvoiceDTO.InvoiceLabors == null) {
                        $scope.InvoiceDTO.InvoiceLabors = [];
                        $scope.InvoiceDTO.InvoiceLabors.push(labor);
                    }
                    else {
                        $scope.InvoiceDTO.InvoiceLabors.push(labor);
                    }
                }

                $scope.labor.laborType.laborID = 1;
                $scope.labor.addeddHours = "";
                $scope.labor.addedrate = "";

                if ($scope.InvoiceDTO.LaborSubTotal == null)
                    $scope.InvoiceDTO.LaborSubTotal = 0;

                $scope.InvoiceDTO.LaborSubTotal = $scope.InvoiceDTO.LaborSubTotal + labor.Amount;
            };
            //------------------------------------------------------------------------------------------------------------

            //Remove Labor
            //------------------------------------------------------------------------------------------------------------
            $scope.removelabor = function (labor) {
                $scope.InvoiceDTO.LaborSubTotal = $scope.InvoiceDTO.LaborSubTotal - labor.Amount;
                $scope.InvoiceDTO.InvoiceLabors[$scope.InvoiceDTO.InvoiceLabors.indexOf(labor)].RecordStatus = "Deleted";
            };
            //------------------------------------------------------------------------------------------------------------

            //Submit Part Invoice
            //------------------------------------------------------------------------------------------------------------
            $scope.submitServiceInvoice = function (event) {
                notificationService.showInfoMessageOnTarget("Submitting Invoice", event.target, false);

                function success() {
                    //notificationService.showGeneralSuccessMessage("Info Message :- Invoice Save and Sumbitted Succefully");
                    //notificationService.showSuccessMessageOnTarget("Info Message :- Invoice Save and Sumbitted Succefully", event.target, true);

                    var url = "";
                    url = "ServiceInvoice/SearchServiceInvoice#?searchText=" + $scope.InvoiceDTO.InvoiceNumber;
                    $window.location.href = url;
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }
                $scope.InvoiceDTO.InvoiceType = "SERVICE-INVOICE";
                if ($("#customerId").val() != 0) {
                    $scope.InvoiceDTO.Customer.ID = $("#customerId").val();
                    $scope.InvoiceDTO.CustomerID = $("#customerId").val();
                }
                $scope.InvoiceDTO.InvoiceDate = $('#svcdate').val();
                $scope.InvoiceDTO.ServiceStartDate = $('#dtServiceStartDate').val();
                $scope.InvoiceDTO.ServiceEndDate = $('#dtServiceEndDate').val();

                $scope.InvoiceDTO.BalanceDue = $('#balanceDue').val();
                //TypeCode Assignement
                $scope.InvoiceDTO.InvoiceStatus.TypeCode = $("#invStatus option:selected").text();
                $scope.InvoiceDTO.County.TypeCode = $("#invCounty option:selected").text();

                serviceInvoiceDataService
                    .postServiceInvoice($scope.InvoiceDTO
                        )
                    .then(success, error);
            };

            $scope.searchInvoice = function (invoiceNumber) {
                function success(data) {
                    $scope.InvoiceDTO = data;
                    $scope.searchSuccess = true;
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                serviceInvoiceDataService
                    .getServiceInvoice(invoiceNumber)
                    .then(success, error);
            };

            var searchText = $location.search().searchText;

            if (searchText != null) {
                $scope.invoiceNumber = searchText;
                $scope.searchInvoice(searchText);
            }
            $scope.navigateToAddInvoice = function () {
                var url = "";
                url = "/ServiceInvoice";
                $window.location.href = url;
            };

            //Edit Invoice Navigation
            //------------------------------------------------------------------------------------------------------------
            $scope.editInvoice = function (event) {
                var url = "";
                url = "/ServiceInvoice#?invoiceData=" + $scope.InvoiceDTO.InvoiceNumber;
                $window.location.href = url;
            };
            //------------------------------------------------------------------------------------------------------------

            //Navigate from Edit
            //------------------------------------------------------------------------------------------------------------

            var invoiceData = $location.search().invoiceData;
            if (invoiceData != null) {
                function success(data) {
                    $scope.InvoiceDTO = data;

                    $scope.InvoiceDTO.ServiceStartDate = $filter('date')(data.ServiceStartDate, 'MMM d, y h:mm:ss a');
                    $scope.InvoiceDTO.ServiceEndDate = $filter('date')(data.ServiceEndDate, 'MMM d, y h:mm:ss a');
                    $scope.InvoiceDTO.InvoiceDate = $filter('date')(data.InvoiceDate, 'MMM d, y h:mm:ss a');
                    //$('#invStatus').val(data.InvoiceStatus.TypeCode);

                    $scope.InvoiceDTO.InvoiceStatus.TypeCode = data.InvoiceStatus.TypeCode;
                    $scope.InvoiceDTO.InvoiceStatus.TypeCodeID = data.InvoiceStatus.TypeCodeID;
                    $scope.InvoiceDTO.County.TypeCode = data.County.TypeCode;
                    $scope.InvoiceDTO.County.TypeCodeID = data.County.TypeCodeID;
                    $scope.InvoiceDTO.Customer.State.TypeCode = data.Customer.State.TypeCode;
                    $scope.InvoiceDTO.Customer.State.TypeCodeID = data.Customer.State.TypeCodeID;

                    $scope.InvoiceDTO.SubmitingMode = 'Update';
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                serviceInvoiceDataService
                    .getServiceInvoice(invoiceData)
                    .then(success, error);
            }

            //-----------------------------------------------------------------------------------------------------------------

            //Delete Invoice
            //------------------------------------------------------------------------------------------------------------
            $scope.deleteInvoice = function (invoiceNumber) {
                function success() {
                    $("#deletePartInvoiceModal").modal("toggle");
                    var url = "";
                    url = "/BillingHome";
                    $window.location.href = url;
                    notificationService.showGeneralSuccessMessage("Info Message :- PartInvoice Removed from Database");
                    notificationService.showSuccessMessageOnTarget("Info Message :- PartInvoice Removed from Database");
                }
                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }
                serviceInvoiceDataService
                    .deleteInvoice(
                       invoiceNumber)
                    .then(success, error);
            };

            //-----------------------------------------------End of Delete Invoice------------------------------------------------------------------

            //Print Part Invoice
            //------------------------------------------------------------------------------------------------------------
            $scope.printServiceInvoice = function (event) {

//                $scope.formatDecimal(123.7889)
                var bodyTemplate = "<html><head> <title></title> <meta charset='utf-8'/> <link href='../Content/Css/bootstrap.min.css' rel='stylesheet'/> <link href='../Content/Css/printingPage.css' rel='stylesheet'/></head><body onload='window.print()'> <div class='container'> <div style='padding:5px; border:1px solid thin; width:100%;height:130px'> <div class='col-xs-12' style='text-align:center'> <h3><b>Service Invoice</b></h3> </div><div class='col-xs-12'> <div class='col-xs-6'> <img src='../Content/Images/bhe.png' width='200' height='60'/> <h6> <b>1926 E. Lincoln Way, Ames, IA 50010<br/> Ph: (800) 723-5460</b> </h6> </div><div class='col-xs-3'></div><div class='col-xs-3'> <div class='col-xs-5'> <b>Invoice#&nbsp;&nbsp;&nbsp;&nbsp;:</b> </div><div class='col-xs-7'> <b>#InvoiceNumber</b> </div><div class='col-xs-5'> <b>Date:</b></div><div class='col-xs-7'> <b> #InvoiceDate</b> </div></div></div></div><div class='col-xs-12' style='border-bottom:1px solid black'> </div><div class='col-xs-12'> <div class='col-xs-6'> <br/><br/> <h4>Customer: <b>#CustomerName</b></h4> </div><div class='col-xs-6'> <br/><br/> <h4>Serviced At: <b>#ServiceAt</b></h4> </div></div><div class='col-xs-12'> <div class='col-xs-6'> <b>Address</b> <div class='col-xs-12' style='margin-bottom: 1px;'> #Address1 #Address2 </div><div class='col-xs-12' style='margin-bottom: 1px;'> #City #State #Zip</div></div><div class='col-xs-6'> <div class='col-xs-12'> <b>Service Details</b> </div><div class='col-xs-12' style='margin-bottom: 1px;'>Service Start Date: #ServiceStartDate</div><div class='col-xs-12' style='margin-bottom: 1px;'>Service End Date: #ServiceEndDate</div></div></div><div class='col-xs-12'> <br/><br/><br/> <table class='dashboardtable' id='invoicetable' style='text-align:center'> <thead> <tr> <th> Make of Equipment </th> <th> Model </th> <th> Serial No </th> <th> Unit No </th> <th> Customer P.O </th> </tr></thead> <tbody> <tr> <td class='form-group'> #Make </td><td class='form-group'> #Model </td><td class='form-group'> #SerialNo </td><td class='form-group'> #UnitNo </td><td class='form-group'> #CustomerPO </td></tr></tbody> </table> </div><div class='col-xs-12'> <br/><br/><br/> <b>Parts</b> <table class='dashboardtable' id='invoicetable'> <thead> <tr> <th> Quantity </th> <th style='width:600px'> Description </th> <th> Price </th> <th> Amount </th> </tr></thead> <tbody> #InvoiceItems </tbody> </table> </div><div class='col-xs-12' style='text-align:right'> <br/><br/> <b> Sub-Total : #PartsSubTotal1 </b> </div><div class='col-xs-12'> <br/><br/><br/> <b>Labor</b> <table class='dashboardtable' id='invoicetable'> <thead> <tr> <th> Labor Type </th> <th> Hours </th> <th> Rate </th> <th> Amount </th> </tr></thead> <tbody> #LaborItems </tbody> </table> </div><div class='col-xs-12' style='text-align:right'> <br/><br/> <b> Sub-Total : #LaborSubTotal1 </b> </div><div class='col-xs-12'> <div class='col-xs-6'></div><div class='col-xs-6'> <br/> <table class='dashboardtable' id='totalsection'> <tbody> <tr> <td>Parts Subtotal:</td><td> #PartsSubTotal2 </td></tr><tr> <td>Labor Subtotal:</td><td> #LaborSubTotal2 </td></tr>#Tax #TravelCharge #TravelExpense #Freight <tr> <td> <h4><b>Total</b></h4> </td><td> <h4><b>#Total</b></h4> </td></tr><tr> <td>Balance Due</td><td> #BalanceDue </td></tr></tbody> </table> <br/> <br/> </div></div></div></body></html>";
                var invoice = $scope.InvoiceDTO;
                bodyTemplate = bodyTemplate.replace("#InvoiceNumber", $scope.InvoiceDTO.InvoiceNumber);
                var datestring = '';
                if ($scope.InvoiceDTO.InvoiceDate != undefined) {
                    datestring = new Date($scope.InvoiceDTO.InvoiceDate);
                }
                else {
                    datestring = new Date();
                }

                bodyTemplate = bodyTemplate.replace("#InvoiceDate", datestring.toLocaleDateString());
                bodyTemplate = bodyTemplate.replace("#CustomerName", $scope.InvoiceDTO.Customer.Name);
                bodyTemplate = bodyTemplate.replace("#Address1", $scope.InvoiceDTO.Customer.Address1);
                bodyTemplate = bodyTemplate.replace("#Address2", $scope.InvoiceDTO.Customer.Address2 == null ? '' : $scope.InvoiceDTO.Customer.Address2);
                bodyTemplate = bodyTemplate.replace("#City", $scope.InvoiceDTO.Customer.City);
                bodyTemplate = bodyTemplate.replace("#State", $scope.InvoiceDTO.Customer.State.TypeCode);
                bodyTemplate = bodyTemplate.replace("#Zip", $scope.InvoiceDTO.Customer.Zip);

                bodyTemplate = bodyTemplate.replace("#ServiceAt", $scope.InvoiceDTO.ServicedAt);
                var svcStartDate = new Date($scope.InvoiceDTO.ServiceStartDate);
                var svcEndDate = new Date($scope.InvoiceDTO.ServiceEndDate);
                bodyTemplate = bodyTemplate.replace("#ServiceStartDate", svcStartDate.toLocaleDateString());
                bodyTemplate = bodyTemplate.replace("#ServiceEndDate", svcEndDate.toLocaleDateString());

                bodyTemplate = bodyTemplate.replace("#Make", $scope.InvoiceDTO.Make);
                bodyTemplate = bodyTemplate.replace("#Model", $scope.InvoiceDTO.Model);
                bodyTemplate = bodyTemplate.replace("#SerialNo", $scope.InvoiceDTO.SerialNumber);
                bodyTemplate = bodyTemplate.replace("#CustomerPO", $scope.InvoiceDTO.CustomerPO);
                bodyTemplate = bodyTemplate.replace("#UnitNo", $scope.InvoiceDTO.UnitNumber);
                bodyTemplate = bodyTemplate.replace("#PartsSubTotal1", "$" + $scope.formatDecimal($scope.InvoiceDTO.PartsSubTotal));
                bodyTemplate = bodyTemplate.replace("#PartsSubTotal2", "$"+$scope.formatDecimal($scope.InvoiceDTO.PartsSubTotal));
                bodyTemplate = bodyTemplate.replace("#LaborSubTotal1", "$" + $scope.formatDecimal($scope.InvoiceDTO.LaborSubTotal));
                bodyTemplate = bodyTemplate.replace("#LaborSubTotal2", "$" +$scope.formatDecimal($scope.InvoiceDTO.LaborSubTotal));
                if ($scope.InvoiceDTO.Tax > 0) {
                    var taxHtml = "<tr><td>Tax:</td><td>$" + $scope.formatDecimal($scope.InvoiceDTO.Tax) + "</td></tr>";
                    bodyTemplate = bodyTemplate.replace("#Tax", taxHtml);
                }
                else {
                    bodyTemplate = bodyTemplate.replace("#Tax", "");
                }

                if ($scope.InvoiceDTO.TravelCharge > 0) {
                    var tChargeHtml = "<tr><td>Travel Charge:</td><td>$" + $scope.formatDecimal($scope.InvoiceDTO.TravelCharge) + "</td></tr>";
                    bodyTemplate = bodyTemplate.replace("#TravelCharge", tChargeHtml);
                }
                else {
                    bodyTemplate = bodyTemplate.replace("#TravelCharge", "");
                }

                if ($scope.InvoiceDTO.TravelExpense > 0) {
                    var tExpenseHtml = "<tr><td>Travel Expense:</td><td>$" + $scope.formatDecimal($scope.InvoiceDTO.TravelExpense) + "</td></tr>";
                    bodyTemplate = bodyTemplate.replace("#TravelExpense", tExpenseHtml);
                }
                else {
                    bodyTemplate = bodyTemplate.replace("#TravelExpense", "");
                }

                if ($scope.InvoiceDTO.Freight > 0) {
                    var freightHtml = "<tr><td>Freight</td><td>$" + $scope.formatDecimal($scope.InvoiceDTO.Freight) + "</td></tr>";
                    bodyTemplate = bodyTemplate.replace("#Freight", freightHtml);

                }
                else
                    bodyTemplate = bodyTemplate.replace("#Freight", "");
                // bodyTemplate = bodyTemplate.replace("#TravelCharge", $scope.InvoiceDTO.TravelCharge == null ? "$" + 0.00 : "$" + $scope.InvoiceDTO.TravelCharge);
                // bodyTemplate = bodyTemplate.replace("#TravelExpense", $scope.InvoiceDTO.TravelExpense == null ? "$" + 0.00 : "$" + $scope.InvoiceDTO.TravelExpense);
                //bodyTemplate = bodyTemplate.replace("#Freight", $scope.InvoiceDTO.Freight == null ? "$" + 0.00 : "$" + $scope.InvoiceDTO.Freight);
                bodyTemplate = bodyTemplate.replace("#Total", "$" + $scope.formatDecimal($scope.InvoiceDTO.Total));
                bodyTemplate = bodyTemplate.replace("#BalanceDue", $scope.formatDecimal($scope.InvoiceDTO.BalanceDue));
                if ($scope.InvoiceDTO.InvoiceItems != null && $scope.InvoiceDTO.InvoiceItems.length > 0) {
                    var invoiceItems = "";
                    for (var i = 0; i < $scope.InvoiceDTO.InvoiceItems.length; i++) {
                        var tr = "<tr> <td> #Quantity </td><td style='width:700px'> #Description </td><td> #Price </td><td> #Total </td></tr>";
                        tr = tr.replace("#Quantity", $scope.InvoiceDTO.InvoiceItems[i].Quantity);
                        tr = tr.replace("#Description", $scope.InvoiceDTO.InvoiceItems[i].Description);
                        tr = tr.replace("#Price", "$" + $scope.formatDecimal($scope.InvoiceDTO.InvoiceItems[i].Price));
                        tr = tr.replace("#Total", "$" + $scope.formatDecimal($scope.InvoiceDTO.InvoiceItems[i].Price * $scope.InvoiceDTO.InvoiceItems[i].Quantity));
                        invoiceItems = invoiceItems.concat(tr)
                    }
                }
                bodyTemplate = bodyTemplate.replace("#InvoiceItems", invoiceItems);
                if ($scope.InvoiceDTO.InvoiceLabors != null && $scope.InvoiceDTO.InvoiceLabors.length > 0) {
                    var invoiceLabors = "";
                    for (var i = 0; i < $scope.InvoiceDTO.InvoiceLabors.length; i++) {
                        var tr = "<tr> <td> #LaborType </td><td> #Hours </td><td> #Rate </td><td> #Amount </td></tr>";
                        tr = tr.replace("#LaborType", $scope.InvoiceDTO.InvoiceLabors[i].LaborType.TypeCode);
                        tr = tr.replace("#Hours", $scope.InvoiceDTO.InvoiceLabors[i].Hours);
                        tr = tr.replace("#Rate", "$" + $scope.formatDecimal($scope.InvoiceDTO.InvoiceLabors[i].Rate));
                        tr = tr.replace("#Amount", "$" + $scope.formatDecimal($scope.InvoiceDTO.InvoiceLabors[i].Amount));
                        invoiceLabors = invoiceLabors.concat(tr)
                    }
                }
                bodyTemplate = bodyTemplate.replace("#LaborItems", invoiceLabors);
                var popupWinindow = window.open('', '_blank', 'width=1200,height=3500,scrollbars=1,resizable=1,menubar=no,toolbar=no,location=no,status=no,titlebar=no');

                popupWinindow.document.open();
                popupWinindow.document.write(bodyTemplate);

                popupWinindow.document.close();
            };
            //-------------------------------------------------------End of Print-----------------------------------------------------

            $scope.formatDecimal = function (value) {
                if (value == null)
                    value = 0;

                return parseFloat(Math.round(value * 100) / 100).toFixed(2);
            }
        });
})();//End of the Function

$(function () {
    //$('#dtServiceStartDate').datetimepicker({
    //    });
    //$('#dtServiceEndDate').datetimepicker({
    //});

    $("#dtServiceStartDate").on("dp.change", function (e) {
        $('#dtServiceEndDate').data("DateTimePicker").minDate(e.date);
    });
    $("#dtServiceEndDate").on("dp.change", function (e) {
        $('#dtServiceStartDate').data("DateTimePicker").maxDate(e.date);
    });
});