(function () {
    'use strict';

    angular.module('theApp').factory('customerdataservice',
        function ($http, $q, config) {
            function getCustomer(customerId) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Customer/Get/" + "?customerId=" + customerId;

                $http({ method: 'GET', url: url })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        deferred.reject(status);
                    });

                return deferred.promise;
            };

            function addCustomer(custmerDTO) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Customer/Add";

                $http({
                    url: url,
                    dataType: 'json',
                    data: custmerDTO,
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

            function getAllCustomers() {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Customer/GetAll";

                $http({ method: 'GET', url: url })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (data, status) {
                        deferred.reject(status);
                    });

                return deferred.promise;
            };

            function deleteCustomer(customerID) {
                var deferred = $q.defer();

                var url = config.endpoints.apiURL + "Customer/Delete?id=" + customerID;

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
                addCustomer: addCustomer,
                //putPart: putPart,
                deleteCustomer: deleteCustomer,
                getCustomer: getCustomer,
                getAllCustomers: getAllCustomers
            };
        }
    );
})();