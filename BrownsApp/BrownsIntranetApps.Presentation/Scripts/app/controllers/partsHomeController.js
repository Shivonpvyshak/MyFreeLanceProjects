(function () {
    'use strict';

    angular.module('theApp').controller('partsHomeController',
        function ($scope, $window) {
            $scope.executeSearch = function () {
                var url = "/Search#?searchText=" + $scope.searchText + "&searchMode=BYPARTNUMBER";
                $window.location.href = url;
            };

            $scope.executePartbyDescSearch = function () {
                var url = "/Search#?searchText=" + $scope.searchText + "&searchMode=BYPARTDESCRIPTION";
                $window.location.href = url;
            }

            $scope.executeModelBySearch = function () {
                var url = "/Search#?searchText=" + $scope.searchText + "&searchMode=BYMODEL";
                $window.location.href = url;
            }
        });
})();