(function () {
    'use strict';
    angular.module('theApp').controller('partsInvoiceController',
        function ($scope, $filter, $http, $location, $window, notificationService, stateDataService, invoiceStatusDataService, paymentStatusDataService,
        shippingMethodDataService, partsInvoiceDataService, countydataservice) {
            //Shipping Address Loading
            //------------------------------------------------------------------------------------------------------------
            //$scope.getSameAddrress = function ($event) {
            //    if ($event) {
            //        $scope.InvoiceDTO.Customer.ShippingAddress1 = $scope.InvoiceDTO.Customer.Address1;
            //        $scope.InvoiceDTO.Customer.ShippingAddress2 = $scope.InvoiceDTO.Customer.Address2;
            //        $scope.InvoiceDTO.Customer.ShippingCity = $scope.InvoiceDTO.Customer.City;
            //        $scope.InvoiceDTO.Customer.ShippingZip = $scope.InvoiceDTO.Customer.Zip;
            //        $scope.InvoiceDTO.Customer.ShippingState = $scope.InvoiceDTO.Customer.State;
            //    }
            //    else {
            //        $scope.InvoiceDTO.Customer.ShippingAddress1 = "";
            //        $scope.InvoiceDTO.Customer.ShippingAddress2 = "";
            //        $scope.InvoiceDTO.Customer.ShippingCity = "";
            //        $scope.InvoiceDTO.Customer.ShippingZip = "";
            //        $scope.InvoiceDTO.Customer.ShippingState = 0;
            //    }
            //};
            //------------------------------------------------------------------------------------------------------------

            //Set Store Pickup
            //------------------------------------------------------------------------------------------------------------
            $scope.setStorePickUp = function ($event) {
                if ($event) {
                    $scope.InvoiceDTO.Customer.ShippingAddress1 = "";
                    $scope.InvoiceDTO.Customer.ShippingAddress2 = "";
                    $scope.InvoiceDTO.Customer.ShippingCity = "";
                    $scope.InvoiceDTO.Customer.ShippingZip = "";
                    $scope.InvoiceDTO.Customer.ShippingState = "";
                    $scope.InvoiceDTO.IsStorePickUp = true;
                }
                else {
                    $scope.InvoiceDTO.Customer.ShippingAddress1 = $scope.InvoiceDTO.Customer.Address1;
                    $scope.InvoiceDTO.Customer.ShippingAddress2 = $scope.InvoiceDTO.Customer.Address2;
                    $scope.InvoiceDTO.Customer.ShippingCity = $scope.InvoiceDTO.Customer.City;
                    $scope.InvoiceDTO.Customer.ShippingZip = $scope.InvoiceDTO.Customer.Zip;
                    $scope.InvoiceDTO.Customer.ShippingState = $scope.InvoiceDTO.Customer.State;

                    $scope.InvoiceDTO.IsStorePickUp = false;
                }
            };
            //------------------------------------------------------------------------------------------------------------

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

                //  $scope.InvoiceDTO.InvoiceItems.splice($scope.InvoiceDTO.InvoiceItems.indexOf(partItem), 1);
            };

            //------------------------------------------------------------------------------------------------------------

            //Loading the dropdowns
            //------------------------------------------------------------------------------------------------------------

            $scope.allStates = stateDataService.getStates();
            $scope.shippingStates = stateDataService.getStates();
            $scope.allInvoiceStatuses = invoiceStatusDataService.getInvoiceStatuses();
            $scope.allPaymentStatuses = paymentStatusDataService.getPaymentStatuses();
            $scope.allShppingMethods = shippingMethodDataService.getshippingMethods();
            $scope.allCounties = countydataservice.getCounties();
            //------------------------------------------------------------------------------------------------------------

            $('#dpInvoiceDate').datetimepicker();

            //$("#dpInvoiceDate").datepicker({
            //    autoclose: true,
            //    todayHighlight: true
            //}).datepicker('update', new Date());

            //Submit Part Invoice
            //------------------------------------------------------------------------------------------------------------
            $scope.submitPartsInvoice = function (event) {
                notificationService.showInfoMessageOnTarget("Submitting Invoice", event.target, false);

                function success() {
                    //  notificationService.showGeneralSuccessMessage("Info Message :- Invoice Save and Sumbitted Succefully");
                    // notificationService.showSuccessMessageOnTarget("Info Message :- Invoice Save and Sumbitted Succefully", event.target, true);

                    var url = "";
                    url = "PartsInvoice/SearchPartsInvoice#?searchText=" + $scope.InvoiceDTO.InvoiceNumber;
                    $window.location.href = url;
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                $scope.InvoiceDTO.InvoiceType = "PART-INVOICE";
                if ($("#customerId").val() != 0) {
                    $scope.InvoiceDTO.Customer.ID = $("#customerId").val();
                    $scope.InvoiceDTO.CustomerID = $("#customerId").val();
                }

                $scope.InvoiceDTO.InvoiceDate = $('#invdate').val();
                $scope.InvoiceDTO.BalanceDue = $('#balanceDue').val();

                //TypeCode Assignement
                $scope.InvoiceDTO.InvoiceStatus.TypeCode = $("#invStatus option:selected").text();
                $scope.InvoiceDTO.County.TypeCode = $("#invCounty option:selected").text();
                $scope.InvoiceDTO.ShippingMethod.TypeCode = $("#shippingMethod option:selected").text();
                $scope.InvoiceDTO.PaymentStatus.TypeCode = $("#paymentStatus option:selected").text();

                partsInvoiceDataService
                    .postPartsInvoice($scope.InvoiceDTO
                        )
                    .then(success, error);
            };
            //------------------------------------------------------------------------------------------------------------

            //Print Part Invoice
            //------------------------------------------------------------------------------------------------------------
            $scope.printPartInvoice = function (event) {
                var bodyTemplate = "<html><head> <title></title> <meta charset='utf-8'/> <link href='../Content/Css/bootstrap.min.css' rel='stylesheet'/> <link href='../Content/Css/printingPage.css' rel='stylesheet'/></head><body onload='window.print()'> <div class='container'> <div style='padding:5px; border:1px solid thin; width:100%;height:130px'> <div class='col-xs-12' style='text-align:center'> <h3><b>Parts Invoice</b></h3> </div><div class='col-xs-6'> <img src='../Content/Images/bhe.png' width='200' height='60'/> <h6> <b>1926 E. Lincoln Way, Ames, IA 50010<br/> Ph: (800) 723-5460</b> </h6> </div><div class='col-xs-3'></div><div class='col-xs-3'> <div class='col-xs-5'> <b>Invoice#&nbsp;&nbsp;&nbsp;&nbsp;:</b> </div><div class='col-xs-7'> <b>#InvoiceNumber</b> </div><div class='col-xs-5'> <b>Invoice Date:</b></div><div class='col-xs-7'> <b> #InvoiceDate</b> </div></div></div></div><div class='col-xs-12' style='border-bottom:1px solid black'> </div><div class='col-xs-12'> <div class='col-xs-6'> <br/><br/> <h4>Customer: <b>#CustomerName</b></h4> </div><div class='col-xs-6'> </div></div><div class='col-xs-12'> <div class='col-xs-6'> <b>Address</b> <div class='col-xs-12' style='margin-bottom: 1px;'> #Address1 #Address2 </div><div class='col-xs-12' style='margin-bottom: 1px;'> #City #State #Zip</div></div><div class='col-xs-6'> <div class='col-xs-12'> <b>Shipping Address </b> </div><div class='col-xs-12' style='margin-bottom: 1px;'> #ShippingAddress1 #ShippingAddress2</div><div class='col-xs-12' style='margin-bottom: 1px;'> #ShippingCity #ShippingState #ShippingZip </div></div></div><div class='col-xs-12'> <br/><br/><br/> <table class='dashboardtable' id='invoicetable' style='text-align:center'> <thead> <tr> <th> Sales Rep </th> <th> Shipping Method </th> <th> Payment </th> <th> Customer P.O </th> </tr></thead> <tbody> <tr> <td class='form-group'> #SalesRep </td><td> #ShippingMethod </td><td> #PaymentStatus </td><td class='form-group'> #CustomerPO </td></tr></tbody> </table> </div><div class='col-xs-12'> <br/><br/><br/> <b>Parts</b> <table class='dashboardtable' id='invoicetable'> <thead> <tr> <th> Quantity </th> <th style='width:600px'> Description </th> <th> Price </th> <th> Amount </th> </tr></thead> <tbody> #InvoiceItems </tbody> </table> </div><div class='col-xs-12' style='text-align:right'> <br/><br/> <b> Sub-Total : #PartsSubTotal1 </b> </div><div class='col-xs-12'> <div class='col-xs-6'></div><div class='col-xs-6'> <br/> <table class='dashboardtable' id='totalsection'> <tbody> <tr> <td>Parts Subtotal:</td><td> #PartsSubTotal2 </td></tr>#Tax #Freight <tr> <td> <h4><b>Total</b></h4> </td><td> <h4><b>#Total</b></h4> </td></tr><tr> <td>Balance Due</td><td> #BalanceDue </td></tr></tbody> </table> <br/> <br/> </div></div></div></body></html>";
                var invoice = $scope.InvoiceDTO;
                bodyTemplate = bodyTemplate.replace("#InvoiceNumber", $scope.InvoiceDTO.InvoiceNumber);
                var datestring = '';
                if ($scope.InvoiceDTO.InvoiceDate != undefined) {
                    datestring = new Date($scope.InvoiceDTO.InvoiceDate);
                }
                else {
                    datestring = new Date();
                }

                var formattedDate = datestring.getMonth() + 1 + '/' + datestring.getDate() + '/' + datestring.getYear();
                bodyTemplate = bodyTemplate.replace("#InvoiceDate", datestring.toLocaleDateString());
                bodyTemplate = bodyTemplate.replace("#CustomerName", $scope.InvoiceDTO.Customer.Name);
                bodyTemplate = bodyTemplate.replace("#Address1", $scope.InvoiceDTO.Customer.Address1);
                bodyTemplate = bodyTemplate.replace("#Address2", $scope.InvoiceDTO.Customer.Address2 == null ? '' : $scope.InvoiceDTO.Customer.Address2);
                bodyTemplate = bodyTemplate.replace("#City", $scope.InvoiceDTO.Customer.City);
                bodyTemplate = bodyTemplate.replace("#State", $scope.InvoiceDTO.Customer.State.TypeCode);
                bodyTemplate = bodyTemplate.replace("#Zip", $scope.InvoiceDTO.Customer.Zip);

                if (!$scope.InvoiceDTO.IsStorePickUp) {
                    bodyTemplate = bodyTemplate.replace("#ShippingAddress1", $scope.InvoiceDTO.Customer.ShippingAddress1);
                    bodyTemplate = bodyTemplate.replace("#ShippingAddress2", $scope.InvoiceDTO.Customer.ShippingAddress2);
                    bodyTemplate = bodyTemplate.replace("#ShippingCity", $scope.InvoiceDTO.Customer.ShippingCity);
                    bodyTemplate = bodyTemplate.replace("#ShippingState", $scope.InvoiceDTO.Customer.ShippingState.TypeCode);
                    bodyTemplate = bodyTemplate.replace("#ShippingZip", $scope.InvoiceDTO.Customer.ShippingZip);
                }
                else {
                    bodyTemplate = bodyTemplate.replace("#ShippingAddress1", "Store Pickup");
                    bodyTemplate = bodyTemplate.replace("#ShippingAddress2", "");
                    bodyTemplate = bodyTemplate.replace("#ShippingCity", "");
                    bodyTemplate = bodyTemplate.replace("#ShippingState", "");
                    bodyTemplate = bodyTemplate.replace("#ShippingZip", "");
                }

                bodyTemplate = bodyTemplate.replace("#SalesRep", $scope.InvoiceDTO.SalesRep);
                bodyTemplate = bodyTemplate.replace("#ShippingMethod", $scope.InvoiceDTO.ShippingMethod.TypeCode);
                bodyTemplate = bodyTemplate.replace("#PaymentStatus", $scope.InvoiceDTO.PaymentStatus.TypeCode);
                bodyTemplate = bodyTemplate.replace("#CustomerPO", $scope.InvoiceDTO.CustomerPO);
                bodyTemplate = bodyTemplate.replace("#PartsSubTotal1", "$" + parseFloat(Math.round($scope.InvoiceDTO.PartsSubTotal * 100) / 100).toFixed(2));
                bodyTemplate = bodyTemplate.replace("#PartsSubTotal2", "$" + parseFloat(Math.round($scope.InvoiceDTO.PartsSubTotal * 100) / 100).toFixed(2));

                

                if ($scope.InvoiceDTO.Tax > 0) {
                    var roundedTax = parseFloat(Math.round($scope.InvoiceDTO.Tax * 100) / 100).toFixed(2);
                    var taxHtml = "<tr><td>Tax:</td><td>$" + roundedTax + "</td></tr>";
                    bodyTemplate = bodyTemplate.replace("#Tax", taxHtml);
                }
                else {
                    bodyTemplate = bodyTemplate.replace("#Tax", "");
                }

                if ($scope.InvoiceDTO.Freight > 0)
                {
                    var freightHtml = "<tr><td>Freight</td><td>$" + parseFloat(Math.round($scope.InvoiceDTO.Freight * 100) / 100).toFixed(2) + "</td></tr>";
                    bodyTemplate = bodyTemplate.replace("#Freight", freightHtml);

                }
                else
                    bodyTemplate = bodyTemplate.replace("#Freight", "");

                //bodyTemplate = bodyTemplate.replace("#Freight", $scope.InvoiceDTO.Freight == null ? "$" + 0.00 : "$" + $scope.InvoiceDTO.Freight);
                bodyTemplate = bodyTemplate.replace("#Total", "$" + parseFloat(Math.round($scope.InvoiceDTO.Total * 100) / 100).toFixed(2));
               
                var balanceDue= $scope.InvoiceDTO.BalanceDue == null ?  0: $scope.InvoiceDTO.BalanceDue;
                bodyTemplate = bodyTemplate.replace("#BalanceDue", "$" + parseFloat(Math.round(balanceDue * 100) / 100).toFixed(2));
                if ($scope.InvoiceDTO.InvoiceItems != null && $scope.InvoiceDTO.InvoiceItems.length > 0) {
                    var invoiceItems = "";
                    for (var i = 0; i < $scope.InvoiceDTO.InvoiceItems.length; i++) {
                        var tr = "<tr> <td> #Quantity </td><td style='width:700px'> #Description </td><td> #Price </td><td> #Total </td></tr>";
                        tr = tr.replace("#Quantity", $scope.InvoiceDTO.InvoiceItems[i].Quantity);
                        tr = tr.replace("#Description", $scope.InvoiceDTO.InvoiceItems[i].Description);
                        var invPrice = $scope.InvoiceDTO.InvoiceItems[i].Price;
                        tr = tr.replace("#Price", "$" + parseFloat(Math.round(invPrice * 100) / 100).toFixed(2));
                        var pTotal = $scope.InvoiceDTO.InvoiceItems[i].Price * $scope.InvoiceDTO.InvoiceItems[i].Quantity;
                        tr = tr.replace("#Total", "$" + parseFloat(Math.round(pTotal * 100) / 100).toFixed(2));
                        invoiceItems = invoiceItems.concat(tr)
                    }
                }
                bodyTemplate = bodyTemplate.replace("#InvoiceItems", invoiceItems);
                var popupWinindow = window.open('', '_blank', 'width=1200,height=3500,scrollbars=1,resizable=1,menubar=no,toolbar=no,location=no,status=no,titlebar=no');

                popupWinindow.document.open();
                popupWinindow.document.write(bodyTemplate);

                popupWinindow.document.close();
            };
            //------------------------------------------------------------------------------------------------------------

            //Search invoice
            //------------------------------------------------------------------------------------------------------------
            $scope.searchInvoice = function (invoiceNumber) {
                function success(data) {
                    $scope.InvoiceDTO = data;
                    $('#invdate').val($scope.InvoiceDTO.InvoiceDate.toLocaleString());
                    $scope.InvoiceDTO.ShippingMethod.TypeCode = data.ShippingMethod.TypeCode;
                    $scope.InvoiceDTO.ShippingMethod.TypeCodeID = data.ShippingMethod.TypeCodeID;
                    $scope.InvoiceDTO.PaymentStatus.TypeCode = data.PaymentStatus.TypeCode;
                    $scope.InvoiceDTO.PaymentStatus.TypeCodeID = data.PaymentStatus.TypeCodeID;
                    $scope.InvoiceDTO.InvoiceStatus.TypeCode = data.InvoiceStatus.TypeCode;
                    $scope.InvoiceDTO.InvoiceStatus.TypeCodeID = data.InvoiceStatus.TypeCodeID;
                    $scope.InvoiceDTO.County.TypeCode = data.County.TypeCode;
                    $scope.InvoiceDTO.County.TypeCodeID = data.County.TypeCodeID;
                    $scope.InvoiceDTO.Customer.State.TypeCode = data.Customer.State.TypeCode;
                    $scope.InvoiceDTO.Customer.State.TypeCodeID = data.Customer.State.TypeCodeID;
                    $scope.InvoiceDTO.Customer.ShippingState.TypeCode = data.Customer.ShippingState.TypeCode;
                    $scope.InvoiceDTO.Customer.ShippingState.TypeCodeID = data.Customer.ShippingState.TypeCodeID;
                    $scope.searchSuccess = true;
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                partsInvoiceDataService
                    .getPartsInvoice(invoiceNumber)
                    .then(success, error);
            };
            //------------------------------------------------------------------------------------------------------------

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
                partsInvoiceDataService
                    .deleteInvoice(
                       invoiceNumber)
                    .then(success, error);
            };

            //------------------------------------------------------------------------------------------------------------

            //Navigated from Billing Home to SearchPage
            //------------------------------------------------------------------------------------------------------------
            var searchText = $location.search().searchText;

            if (searchText != null) {
                $scope.invoiceNumber = searchText;
                $scope.searchInvoice(searchText);
            }
            //------------------------------------------------------------------------------------------------------------

            //Add Invoivce Navigation
            //------------------------------------------------------------------------------------------------------------
            $scope.navigateToAddInvoice = function () {
                var url = "";
                url = "/PartsInvoice";
                $window.location.href = url;
            };
            //------------------------------------------------------------------------------------------------------------

            //Edit Invoice Navigation
            //------------------------------------------------------------------------------------------------------------
            $scope.editInvoice = function (event) {
                var url = "";
                url = "/PartsInvoice#?invoiceData=" + $scope.InvoiceDTO.InvoiceNumber;
                $window.location.href = url;
            };
            //------------------------------------------------------------------------------------------------------------

           
            //Navigate from Edit
            //------------------------------------------------------------------------------------------------------------

            var invoiceData = $location.search().invoiceData;
            if (invoiceData != null) {
                function success(data) {
                    $scope.InvoiceDTO = data;

                    $scope.InvoiceDTO.InvoiceDate = $filter('date')(data.InvoiceDate, 'MMM d, y h:mm:ss a');
                    //$('#invStatus').val(data.InvoiceStatus.TypeCode);
                    $scope.InvoiceDTO.ShippingMethod.TypeCode = data.ShippingMethod.TypeCode;
                    $scope.InvoiceDTO.ShippingMethod.TypeCodeID = data.ShippingMethod.TypeCodeID;
                    $scope.InvoiceDTO.PaymentStatus.TypeCode = data.PaymentStatus.TypeCode;
                    $scope.InvoiceDTO.PaymentStatus.TypeCodeID = data.PaymentStatus.TypeCodeID;
                    $scope.InvoiceDTO.InvoiceStatus.TypeCode = data.InvoiceStatus.TypeCode;
                    $scope.InvoiceDTO.InvoiceStatus.TypeCodeID = data.InvoiceStatus.TypeCodeID;
                    $scope.InvoiceDTO.County.TypeCode = data.County.TypeCode;
                    $scope.InvoiceDTO.County.TypeCodeID = data.County.TypeCodeID;
                    $scope.InvoiceDTO.Customer.State.TypeCode = data.Customer.State.TypeCode;
                    $scope.InvoiceDTO.Customer.State.TypeCodeID = data.Customer.State.TypeCodeID;
                    $scope.InvoiceDTO.Customer.ShippingState.TypeCode = data.Customer.ShippingState.TypeCode;
                    $scope.InvoiceDTO.Customer.ShippingState.TypeCodeID = data.Customer.ShippingState.TypeCodeID;

                    $scope.InvoiceDTO.SubmitingMode = 'Update';
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                partsInvoiceDataService
                    .getPartsInvoice(invoiceData)
                    .then(success, error);
            }

            //-----------------------------------------------------------------------------------------------------------------
        });
})();//End of the Function