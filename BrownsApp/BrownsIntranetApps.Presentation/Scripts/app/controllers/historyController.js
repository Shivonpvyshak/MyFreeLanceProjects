(function () {
    'use strict';

    angular.module('theApp').controller('historyController',
        function ($scope, $filter, $location, taxonHistoryDataService, notificationService) {
            function getUniqueNames(nameHistories) {
                var sortedNameHistories = nameHistories.sort(function (a, b) {
                    return new Date(b.HistoryDate) - new Date(a.HistoryDate);
                });

                var flags = [], output = [], l = sortedNameHistories.length, i;
                for (i = 0; i < l; i++) {
                    if (flags[sortedNameHistories[i].NameId]) continue;
                    flags[sortedNameHistories[i].NameId] = true;
                    output.push(sortedNameHistories[i]);
                }
                return output;
            }

            $scope.selectName = function (name) {
                $scope.selectedName = name;
            }

            $scope.getHistory = function (internalId) {
                function success(results) {
                    $scope.InternalId = $scope.searchText;

                    $scope.taxonHistory = results;

                    $scope.distinctNames = getUniqueNames(results.NameHistoryDtos);

                    $scope.selectedName = $scope.distinctNames[0];

                    $scope.isSearchExecuting = false;
                }

                function error() {
                    notificationService.showGeneralErrorMessage("Error searching for Node");
                    $scope.isSearchExecuting = false;
                }

                $scope.isSearchExecuting = true;

                taxonHistoryDataService
                    .getByInternalId(internalId)
                    .then(success, error);
            };

            var internalId = $location.search().internalId;

            if (internalId != null) {
                $scope.searchText = internalId;
                $scope.getHistory(internalId);
            }
        });
})();