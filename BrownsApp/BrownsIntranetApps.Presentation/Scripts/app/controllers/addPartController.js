(function () {
    'use strict';

    angular.module('theApp').controller('addPartController',
        function ($scope, $filter, $http, $location, companyDataService, partDataService, searchEventService, notificationService) {
            var clearModal = function () {
                $scope.addPartData = {
                    newPartNumber: null,
                    newMake: null,
                    newModel: null,
                    newSNNumberRange: null,
                    newPartManual: null,
                    newPartDescription: null,
                    newListPrice: null
                }
            }

            $scope.$on('handleBroadcastViewPart', function () {
                var vpart = searchEventService.SelectedPart;
                setViewPart(vpart);
            });

            function setViewPart(vpart) {
                $scope.viewPartData = vpart;
            };

            $scope.$on('handleBroadcastEditPart', function () {
                var epart = searchEventService.EditPart;
                setEditPart(epart);
            });

            function setEditPart(epart) {
                $scope.editPartData = epart;
            };

            $scope.$on('handleBroadcastDeletePart', function () {
                var dpart = searchEventService.DeletePart;
                setDeletePart(dpart);
            });

            function setDeletePart(dpart) {
                $scope.deletePartData = dpart;
            };

            $scope.addPart = function (event) {
                notificationService.showInfoMessageOnTarget("Adding Node", event.target, false);

                function success() {
                    $("#addPartModal").modal("toggle");

                    //searchEventService.deSelectNode();

                    notificationService.showGeneralSuccessMessage("Info Message :- New Part added");
                    notificationService.showSuccessMessageOnTarget("Info Message :- New Part added", event.target, true);
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                partDataService
                    .postPart(
                        $scope.addPartData.newPartNumber,
                        $scope.addPartData.newMake.companyName,
                        $scope.addPartData.newModel,
                        $scope.addPartData.newSNNumberRange,
                        $scope.addPartData.newPartManual,
                        $scope.addPartData.newPartDescription,
                        $scope.addPartData.newListPrice,
                        $scope.addPartData.newMake.companyID)
                    .then(success, error);
            };

            $scope.editPart = function (event) {
                notificationService.showInfoMessageOnTarget("Adding Node", event.target, false);

                function success() {
                    $("#editPartModal").modal("toggle");

                    //searchEventService.deSelectNode();

                    notificationService.showGeneralSuccessMessage("Info Message :- Part Details updated");
                    notificationService.showSuccessMessageOnTarget("Info Message :- Part Details updated", event.target, true);
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                partDataService
                    .putPart(
                        $scope.editPartData.ID,
                        $scope.editPartData.PartNumber,
                        $scope.editPartData.Make,
                        $scope.editPartData.Model,
                        $scope.editPartData.SerialNumberRange,
                        $scope.editPartData.PartManual,
                        $scope.editPartData.PartDescription,
                        $scope.editPartData.ListPrice,
                        $scope.editPartData.CompanyID)
                    .then(success, error);
            };

            //clearAddNode();

            $scope.deletePart = function (event) {
                function success() {
                    $("#deletePartModal").modal("toggle");
                    // splicePart($scope.deletePartData.PartNumber);
                    notificationService.showGeneralSuccessMessage("Info Message :- Part Removed from Database");
                }
                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                partDataService
                    .deletePart(
                        $scope.deletePartData.ID,
                        $scope.deletePartData.PartNumber,
                        $scope.deletePartData.Make,
                        $scope.deletePartData.Model,
                        $scope.deletePartData.SerialNumberRange,
                        $scope.deletePartData.PartManual,
                        $scope.deletePartData.PartDescription,
                        $scope.deletePartData.ListPrice,
                        $scope.deletePartData.CompanyID)
                    .then(success, error);
            };

            $scope.allCompanies = companyDataService.getCompanies();

            $scope.printToCart = function (event) {
                var bodyTemplate = "<html><head> <style>table{border-collapse: collapse; width: 70%;}th, td{padding: 8px; text-align: left; border-bottom: 1px solid #ddd;}td{font-family: Arial;}</style></head><body  onload='window.print()'> <table> <thead> <tr> <th colspan='2' style='font-family:Arial'><h3>Part Detail</h3></th> </tr></thead> <tbody> <tr> <td><h4>Part #</h4></td><td>#PartNum#</td></tr><tr> <td><h4>Make</h4></td><td>#Make#</td></tr><tr> <td><h4>Model</h4></td><td>#Model#</td></tr><tr> <td><h4>Serial Num Range</h4></td><td>#SNRange#</td></tr><tr> <td><h4>Part Manual</h4></td><td>#PartManual#</td></tr><tr> <td><h4>Part Description</h4></td><td>#PartDesc#</td></tr><tr> <td><h4>List Price</h4></td><td>$#ListPrice#</td></tr></tbody> </table></body></html>";
                bodyTemplate = bodyTemplate.replace("#PartNum#", $scope.viewPartData.PartNumber);
                bodyTemplate = bodyTemplate.replace("#Make#", $scope.viewPartData.Make);
                bodyTemplate = bodyTemplate.replace("#Model#", $scope.viewPartData.Model);
                bodyTemplate = bodyTemplate.replace("#SNRange#", $scope.viewPartData.SerialNumberRange);
                bodyTemplate = bodyTemplate.replace("#PartManual#", $scope.viewPartData.PartManual);
                bodyTemplate = bodyTemplate.replace("#PartDesc#", $scope.viewPartData.PartDescription);
                bodyTemplate = bodyTemplate.replace("#ListPrice#", $scope.viewPartData.ListPrice);
                var popupWinindow = window.open('', '_blank', 'width=700,height=400,scrollbars=no,menubar=no,toolbar=no,location=no,status=no,titlebar=no');

                //var bodyTemplate = "<html><head> <title></title> <meta charset='utf-8'/> <link href='../Content/Css/bootstrap.min.css' rel='stylesheet'/> <link href='../Content/Css/printingPage.css' rel='stylesheet'/></head><body  onload='window.print()'> <div class='container'> <div style='padding:5px; border:1px solid thin; width:100%;height:130px'> <div class='col-xs-12' style='text-align:center'> <h3><b>Parts Invoice</b></h3> </div><div class='col-xs-12'> <div class='col-xs-6'> <img src='../Content/Images/bhe.png' width='250' height='80'/> <h6> <b>1926 E. Lincoln Way, Ames, IA 50010 Ph: (800) 723-5460</b> </h6> </div><div class='col-xs-6'> <div class='col-xs-6'> </div><div class='col-xs-3'><b>InvoiceNumber :</b> </div><div class='col-xs-3'> <b>#InvoiceNumber</b> </div><div class='col-xs-6'> </div><div class='col-xs-3'><b>InvoiceDate :</b></div><div class='col-xs-3'> <b> #InvoiceDate</b> </div></div></div></div><div class='col-xs-12' style='border-bottom:1px solid black'> </div><br/> <div class='col-xs-12'> <div class='col-xs-2'> <h3>Customer:</h3> </div><div class='col-xs-8'> <br/> #CustomerName </div></div><div class='col-xs-12'> <div class='col-xs-6'> <b>Address</b> <div class='col-xs-12' style='margin-bottom: 1px;'> <br/> #Address1 </div><br/> <div class='col-xs-12' style='margin-bottom: 1px;'> #Address2 </div><div class='col-xs-12' style='margin-bottom: 1px;'> #City </div><div class='col-xs-6'> #State </div><div class='col-xs-6'> #Zip </div></div><div class='col-xs-6'> <div class='col-xs-12'> <b>Shipping Address </b> </div><div class='col-xs-12' style='margin-bottom: 1px;'> <br/> #ShippingAddress1 </div><br/> <div class='col-xs-12' style='margin-bottom: 1px;'> #ShippingAddress2 </div><div class='col-xs-12' style='margin-bottom: 1px;'> #ShippingCity </div><div class='col-xs-6'> #ShippingState </div><div class='col-xs-6'> #ShippingZip </div></div></div><br/> <div class='col-xs-12'> <br/> <table class='dashboardtable' id='invoicetable' style='text-align:center'> <thead> <tr> <th> Sales Rep </th> <th> Shipping Method </th> <th> Payment </th> <th> Customer P.O </th> </tr></thead> <tbody> <tr> <td class='form-group'> #SalesRep </td><td> #ShippingMethod </td><td> #PaymentStatus </td><td class='form-group'> #CustomerPO </td></tr></tbody> </table> </div><br/> <div class='col-xs-12'> <br/><br/> <table class='dashboardtable' id='invoicetable'> <thead> <tr> <th> Quantity </th> <th style='width:700px'> Description </th> <th> Price </th> <th> Amount </th> </tr></thead> <tbody> <tr> <td> #Quantity </td><td style='width:700px'> #Description </td><td> #Price </td><td> #Total </td></tr></tbody> </table> </div><div class='col-xs-12' style='text-align:right'> <br/> <b> Sub-Total : #PartsSubTotal </b> </div><div class='col-xs-12'> <div class='col-xs-6'></div><div class='col-xs-6'> <br/> <table class='dashboardtable' id='totalsection'> <tbody> <tr> <td>Parts Subtotal:</td><td> #PartsSubtotal </td></tr><tr> <td>Tax:</td><td> #Tax </td></tr><tr> <td>Freight</td><td> #Freight </td></tr><tr> <td><h2><b>Total</b></h2></td><td> <h2><b>#Total</b></h2> </td></tr><tr> <td>Balance Due</td><td> #BalanceDue </td></tr></tbody> </table> </div></div></div></body></html>";

                //var popupWinindow = window.open('', '_blank', 'width=1200,height=2000,scrollbars=yes,menubar=no,toolbar=no,location=no,status=no,titlebar=no');
                popupWinindow.document.open();
                popupWinindow.document.write(bodyTemplate);

                popupWinindow.document.close();
            };
            //End of the Function
        });
})();