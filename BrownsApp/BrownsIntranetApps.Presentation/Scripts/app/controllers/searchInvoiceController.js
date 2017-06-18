(function () {
    'use strict';

    angular.module('theApp')
           .controller('searchInvoiceController',
            function ($scope, $filter, $http, $location, $window, config, notificationService) {
                $scope.searchInvoice = function (invoiceNumber) {
                    $window.location.href = '/PartsInvoice/ViewPartsInvoice';
                };

                //======================EOF==============================================
            });
})();