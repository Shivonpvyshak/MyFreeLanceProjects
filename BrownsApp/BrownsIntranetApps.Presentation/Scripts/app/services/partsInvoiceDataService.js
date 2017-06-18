(function () {
    'use strict';

    angular.module('theApp').factory('partsInvoiceDataService',
        function ($http, $q, config) {
            function getPartsInvoice(invoiceNumber) {
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

            function postPartsInvoice1(invoiceDTO) {
                var deferred = $q.defer();
                $.ajax({
                    url: 'PartsInvoice/SavePartInvoice',//make sure url exist
                    data: { invoiceDTO: invoiceDTO },//pass data to action
                    type: 'POST',
                    success: function (data) {
                        deferred.resolve({ data: data, status: status });
                    },
                    error: function (data, status) {
                        deferred.reject({ data: data, status: status });
                    }
                });

                return deferred.promise;
            }

            function postPartsInvoice(invoiceDTO) {
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

            function putPart(partID, partNumber, make, model, snrange, partManual, partDescription, listPrice, companyID) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Part/Edit";


                $http({
                    url: url,
                    data: {
                        PartNumber: partNumber,
                        Model: model,
                        Make: make,
                        SerialNumberRange: snrange,
                        PartDescription: partDescription,
                        PartManual: partManual,
                        ListPrice: listPrice,
                        CompanyID: companyID,
                        ID: partID
                    },
                    method: 'PUT'
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
                postPartsInvoice: postPartsInvoice,
                putPart: putPart,
                deleteInvoice: deleteInvoice,
                getPartsInvoice: getPartsInvoice
            };
        }
    );
})();