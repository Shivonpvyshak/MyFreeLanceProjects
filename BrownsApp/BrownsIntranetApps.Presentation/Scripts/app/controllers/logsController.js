(function () {
    'use strict';

    angular.module('theApp')
           .controller('logsController',
            function ($scope, $filter, $http, $location, $window, config, notificationService, logsDataService) {
                function setNodeSearchResultsHelperProperties() {
                    for (var i = 0; i < $scope.searchResultNodes.length; i++) {
                        var node = $scope.searchResultNodes[i];

                        //   setNodeHelperProperties(node);
                    }
                }

                function setVisibleSearchResults() {
                    var startingIndex = ($scope.currentPage * $scope.pageSize) - ($scope.pageSize);
                    var endingIndex = ($scope.currentPage * $scope.pageSize);

                    $scope.visibleSearchResultNodes = $scope.searchResultNodes.slice(startingIndex, endingIndex);
                };

                function initializeSearch() {
                    $scope.searchResultNodes = null;
                    $scope.isSearchExecuting = true;
                    $scope.currentPage = 1;
                }

                function setSearchResults(data, searchedMode) {
                    $scope.searchResultNodes = data.Data;
                    $scope.totalItems = data.Data.length;
                    $scope.lastSearchMode = searchedMode;

                    setVisibleSearchResults();

                    setNodeSearchResultsHelperProperties();

                    $scope.isSearchExecuting = false;
                }
                function showSearchError(reason, event) {
                    if (!event) {
                        notificationService.showGeneralErrorMessage("Could not reach application.  Please try again later.");
                    }

                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, true);
                }

                $scope.executeLogsSearch = function (event) {
                    initializeSearch();

                    function success(data) {
                        setSearchResults(data, "Starts With");
                    }

                    function error(reason) {
                        $scope.isSearchExecuting = false;
                        showSearchError(reason, event);
                    }

                    logsDataService
                        .getExceptionLogSearchResults($scope.searchText)
                        .then(success, error);
                }

                $scope.selectNode = function (node) {
                    searchEventService.nodeSelected(node);
                }
                $scope.pageChanged = function () {
                    setVisibleSearchResults();
                };

                //$scope.searchHelpTemplateId = "searchHelp.html";

                $scope.searchResultNodes = null;

                $scope.currentPage = 1;
                $scope.pageSize = 10;
                $scope.totalItems = 0;

                function splicePart(partNumber) {
                    var index = findIndexInData($scope.visibleSearchResultNodes, "PartNumber", partNumber);
                    $scope.visibleSearchResultNodes.splice(index, 1);
                };

                function findIndexInData(data, property, value) {
                    var result = -1;
                    data.some(function (item, i) {
                        if (item[property] === value) {
                            result = i;
                            return true;
                        }
                    });
                    return result;
                }

                //-----------------------------------end of the function------------------------------------------------------------
            });
})();