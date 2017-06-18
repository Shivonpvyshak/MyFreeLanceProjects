(function () {
    'use strict';

    angular.module('theApp').factory('serviceInvoiceDataService',
        function ($http, $q, config) {
            function getServiceInvoice(invoiceNumber) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Invoice/Parts/Get/" + "?invoiceNumber=" + invoiceNumber;

                $http({ method: 'GET', url: url })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        deferred.reject(status);
                    });

                return deferred.promise;
            };

            function postServiceInvoice(invoiceDTO) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Invoice/Add";

                $http({
                    url: url,
                    dataType: 'json',
                    data: invoiceDTO,
                    method: 'POST'
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data, status) {
                    deferred.reject({ data: data, status: status });
                });

                return deferred.promise;
            };

            function deleteInvoice(invoiceNumber) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Invoice/Delete?invoiceNumber=" + invoiceNumber + "&APIKey=BHEAPI";

                $http({ method: 'DELETE', url: url })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        deferred.reject(status);
                    });

                return deferred.promise;
            };

            return {
                postServiceInvoice: postServiceInvoice,
                getServiceInvoice: getServiceInvoice,
                deleteInvoice: deleteInvoice
            };
        }
    );
})();