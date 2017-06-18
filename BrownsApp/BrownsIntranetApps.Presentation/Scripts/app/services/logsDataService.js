(function () {
    'use strict';
    angular.module('theApp').factory('logsDataService',
            function ($http, $q, config) {
                function getExceptionLogSearchResults(fromDate) {
                    var deferred = $q.defer();

                    var url = config.endpoints.apiURL + "Logs/GetExceptionLogs" + "?fromDate=" + fromDate;
                    //  var url = "test" + "Search" + "?searchTerm=" + searchText + "&searchMode=" + searchMode;
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

                return {
                    getExceptionLogSearchResults: getExceptionLogSearchResults
                };

                //-----------------------------------end of the function------------------------------------------------------------
            });
})();