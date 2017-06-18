(function () {
    'use strict';

    angular.module('theApp').factory('searchDataService',
        function ($http, $q, config) {
            function getSearchbyPartNumberResults(searchText, searchMode) {
                var deferred = $q.defer();
                var url = config.endpoints.apiURL + "Part/Search" + "?searchTerm=" + searchText + "&searchMode=BYPARTNUMBER";
                $http({ method: 'GET', url: url })
                    .success(function (data) {
                        // alert('success');
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        // alert('error');

                        deferred.reject(status);
                        // alert(status);
                    });

                return deferred.promise;
            };

            function getSearchbyPartDescResults(searchText, searchMode) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Part/Search" + "?searchTerm=" + searchText + "&searchMode=BYPARTDESCRIPTION";

                $http({ method: 'GET', url: url })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        deferred.reject(status);
                    });

                return deferred.promise;
            };

            function getSearchbyPartModelResults(searchText, searchMode) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Part/Search" + "?searchTerm=" + searchText + "&searchMode=BYMODEL";

                $http({ method: 'GET', url: url })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        deferred.reject(status);
                    });

                return deferred.promise;
            };

            function getSearchbyAll(partNumber, companyID, make, model, serialnum, description, manual) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Part/GetPartsDetails";
                $http({
                    url: url,
                    data: {
                        PartNumber: partNumber,
                        Model: model,
                        Make: make,
                        SerialNumberRange: serialnum,
                        PartDescription: description,
                        PartManual: manual,
                        CompanyID: companyID
                    },
                    method: 'POST'
                })
                   .success(function (data) {
                       deferred.resolve(data);
                   })
                   .error(function (data, status) {
                       deferred.reject(status);
                   });

                return deferred.promise;
            };

            return {
                getSearchbyPartNumberResults: getSearchbyPartNumberResults,
                getSearchbyPartDescResults: getSearchbyPartDescResults,
                getSearchbyPartModelResults: getSearchbyPartModelResults,
                getSearchbyAll: getSearchbyAll
            };
        }
    );
})();