(function () {
    'use strict';

    angular.module('theApp').controller('reportController',
        function ($scope, $filter, $http, $location, companyDataService) {
            $scope.allCompanies = companyDataService.getCompanies();
        });
})();//End of the Function