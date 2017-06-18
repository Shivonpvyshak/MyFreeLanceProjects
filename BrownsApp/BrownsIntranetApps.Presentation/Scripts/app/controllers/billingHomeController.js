(function () {
    'use strict';

    angular.module('theApp').controller('billingHomeController',
        function ($scope, $filter, $http, $location, $window, notificationService, billingHomeDataService) {
            $scope.initialize = function () {
                $scope.isLoading = true;
                function success(results) {
                    $scope.InProgressInvoices = results.InProgressInvoices;
                    $scope.PendingValidationInvoices = results.PendingValidationInvoices;
                    $scope.ApprovedInvoices = results.ApprovedInvoices;
                    $scope.PaymentPendingInvoices = results.PaymentPendingInvoices;
                    $scope.isLoading = false;
                }

                function error() {
                    notificationService.showGeneralErrorMessage("Error occured while loading data, please contact Technical Team ");
                    $scope.isLoading = false;
                }

                billingHomeDataService
                    .getAllDashboardInvoices()
                    .then(success, error);
            };

            $scope.executeSearch = function (invoiceType, invoiceNumber) {
                var url = "";
                if (invoiceType == "PART-INVOICE") {
                    url = "PartsInvoice/SearchPartsInvoice#?searchText=" + invoiceNumber;
                }
                else {
                    url = "ServiceInvoice/SearchServiceInvoice#?searchText=" + invoiceNumber;
                }
                $window.location.href = url;
            };
            //-----------------------------------------------------------------------------------------------------------------
        });
})();//End of the Function

$(document).ready(function () {
    $('.collapse.in').prev('.panel-heading').addClass('active');
    $('#accordion, #bs-collapse')
        .on('show.bs.collapse', function (a) {
            $(a.target).prev('.panel-heading').addClass('active');
        })
        .on('hide.bs.collapse', function (a) {
            $(a.target).prev('.panel-heading').removeClass('active');
        });
});