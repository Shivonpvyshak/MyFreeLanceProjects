(function () {
    'use strict';

    angular.module('theApp').factory('partDataService',
        function ($http, $q, config) {
            function postPart(partNumber, make, model, snrange, partManual, partDescription, listPrice, companyID) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Part/Add";

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
                        CompanyID: companyID
                    },
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

            function deletePart(partID, partNumber, make, model, snrange, partManual, partDescription, listPrice, companyID) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Part/Delete";

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

            return {
                postPart: postPart,
                putPart: putPart,
                deletePart: deletePart
            };
        }
    );
})();