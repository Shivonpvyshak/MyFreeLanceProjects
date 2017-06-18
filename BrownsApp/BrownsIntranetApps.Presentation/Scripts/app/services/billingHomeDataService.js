(function () {
    'use strict';

    angular.module('theApp').factory('billingHomeDataService',
        function ($http, $q, config) {
            function getAllDashboardInvoices() {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Invoice/GetAllDashboardInvoices";

                $http({ method: 'GET', url: url })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        deferred.reject(status);
                    });

                return deferred.promise;
            };

            return {
                getAllDashboardInvoices: getAllDashboardInvoices
            };
        }
    );
})();