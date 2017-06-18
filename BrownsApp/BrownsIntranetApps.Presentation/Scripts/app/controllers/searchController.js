(function () {
    'use strict';

    angular.module('theApp')
           .controller('searchController',
            function ($scope, $filter, $http, $location, $window, config, searchDataService, searchEventService, partDataService, notificationService, companyDataService) {
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

                $scope.viewPart = function (vpart) {
                    searchEventService.partSelected(vpart);
                };

                $scope.editPart = function (epart) {
                    searchEventService.partEdit(epart);
                };

                $scope.executePartbyDescSearch = function (event) {
                    initializeSearch();

                    function success(data) {
                        setSearchResults(data, "Starts With");
                    }

                    function error(reason) {
                        $scope.isSearchExecuting = false;
                        showSearchError(reason, event);
                    }

                    searchDataService
                        .getStartsWithSearchResults($scope.searchText)
                        .then(success, error);
                }

                $scope.executeModelBySearch = function (event) {
                    initializeSearch();

                    function success(data) {
                        setSearchResults(data, "Ends With");
                    }

                    function error(reason) {
                        $scope.isSearchExecuting = false;
                        showSearchError(reason, event);
                    }

                    searchDataService
                        .getEndsWithSearchResults($scope.searchText)
                        .then(success, error);
                }

                $scope.executeSearch = function (event) {
                    initializeSearch();

                    function success(data) {
                        setSearchResults(data, "Parts search by Part Numbers");
                    }

                    function error(reason) {
                        $scope.isSearchExecuting = false;
                        showSearchError(reason, event);
                    }

                    searchDataService
                        .getSearchbyPartNumberResults($scope.searchText, searchMode)
                        .then(success, error);
                };

                $scope.executePartbyDescSearch = function (event) {
                    initializeSearch();

                    function success(data) {
                        setSearchResults(data, "Parts search by Part Description");
                    }

                    function error(reason) {
                        $scope.isSearchExecuting = false;
                        showSearchError(reason, event);
                    }

                    searchDataService
                        .getSearchbyPartDescResults($scope.searchText, searchMode)
                        .then(success, error);
                };

                $scope.executeModelBySearch = function (event) {
                    initializeSearch();

                    function success(data) {
                        setSearchResults(data, "Parts search by Model");
                    }

                    function error(reason) {
                        $scope.isSearchExecuting = false;
                        showSearchError(reason, event);
                    }

                    searchDataService
                        .getSearchbyPartModelResults($scope.searchText, searchMode)
                        .then(success, error);
                };

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

                $scope.deletePart = function (dpart) {
                    $scope.deletePartData = dpart;
                };

                $scope.deletePartDetail = function (event) {
                    function success() {
                        $("#deletePartModal").modal("toggle");
                        splicePart($scope.deletePartData.PartNumber);
                        notificationService.showGeneralSuccessMessage("Info Message :- Part Removed from Database");
                    }
                    function error(reason) {
                        notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                    }
                    var x = $scope.deletePartData.PartNumber;
                    partDataService
                        .deletePart(
                            $scope.deletePartData.ID,
                            $scope.deletePartData.PartNumber,
                            $scope.deletePartData.Make,
                            $scope.deletePartData.Model,
                            $scope.deletePartData.SerialNumberRange,
                            $scope.deletePartData.PartManual,
                            $scope.deletePartData.PartDescription,
                            $scope.deletePartData.ListPrice,
                            $scope.deletePartData.CompanyID)
                        .then(success, error);
                };

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

                //get the search text and search mode from the parts home and search page
                var searchText = $location.search().searchText;
                var searchMode = $location.search().searchMode;

                if (searchText != null) {
                    $scope.searchText = searchText;

                    switch (searchMode) {
                        case "BYPARTNUMBER":
                            $scope.executeSearch();
                            break;
                        case "BYPARTDESCRIPTION":
                            $scope.executePartbyDescSearch();
                            break;
                        case "BYMODEL":
                            $scope.executeModelBySearch();
                            break;
                        default:
                            $scope.executeSearch();
                    }
                }

                $scope.allCompanies = companyDataService.getCompanies();

                $scope.executeSearchByAll = function (event) {
                    initializeSearch();

                    function success(data) {
                        setSearchResults(data, "Advance Parts Search");
                    }

                    function error(reason) {
                        $scope.isSearchExecuting = false;
                        showSearchError(reason, event);
                    }

                    searchDataService
                        .getSearchbyAll($scope.PartNumber, $scope.Make.companyID, $scope.Make.companyName, $scope.Model, $scope.SerialNumberRange, $scope.PartDescription, $scope.PartManual)
                        .then(success, error);
                };
            });
})();