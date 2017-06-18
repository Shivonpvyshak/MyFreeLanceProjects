(function () {
    'use strict';

    angular.module('theApp').controller('fileUploadController',
        function ($scope, $filter, $http, $location, fileUploadService, companyDataService, notificationService) {
            $scope.allCompanies = companyDataService.getCompanies();

            $scope.selectPartFileforUpload = function (file) {
                $scope.SelectedPartFileForUpload = file[0];
            }

            $scope.selectPartPriceFileforUpload = function (file) {
                $scope.SelectedPartPriceFileForUpload = file[0];
            }

            $scope.UploadPartFile = function (companyID) {
                function success(data) {
                    $scope.isFileUploadSuccess = true;
                    notificationService.showGeneralSuccessMessage("Info Message :- Upload Success, please proceed with File Import");
                }

                function error(reason) {
                    $scope.isFileUploadSuccess = false;
                    notificationService.showGeneralErrorMessage("Error Message :- Upload Falied!! Please try again with valid 'Parts' Excel file");
                }

                $scope.IsFormSubmitted = true;
                $scope.Message = "";
                $scope.CheckFileValidExcel($scope.SelectedPartFileForUpload);
                if ($scope.IsFileValid) {
                    fileUploadService
                        .uploadFile($scope.SelectedPartFileForUpload, "PART", companyID)
                        .then(success, error);
                }
                else {
                    $scope.Message = "All the fields are required.";
                }
            };

            $scope.UploadPartPriceFile = function () {
                function success(data) {
                    $scope.isPartPriceUploadSuccess = true;
                    notificationService.showGeneralSuccessMessage("Info Message :- Upload Success, please proceed with File Import");
                }

                function error(reason) {
                    $scope.isPartPriceUploadSuccess = false;
                    notificationService.showGeneralErrorMessage("Error Message :- Upload Falied!! Please try again with valid 'Parts Price' Excel file");
                }

                $scope.IsFormSubmitted = true;
                $scope.Message = "";
                $scope.CheckFileValidExcel($scope.SelectedPartPriceFileForUpload);
                if ($scope.IsFileValid) {
                    fileUploadService
                        .uploadFile($scope.SelectedPartPriceFileForUpload, "PARTPRICE", -1)
                        .then(success, error);
                }
                else {
                    $scope.Message = "All the fields are required.";
                }
            };

            $scope.ImportPartData = function (companyID) {
                $scope.isPartImportExecuting = true;
                function success(data) {
                    $scope.isFileImportSuccess = true;
                    notificationService.showGeneralSuccessMessage("Info Message :- Part Data Import Success");
                    $scope.isPartImportExecuting = false;
                }

                function error(reason) {
                    $scope.isFileImportSuccess = false;
                    notificationService.showGeneralErrorMessage("Error Message :- Part Data Import Falied!! Please try again with valid 'Parts' Excel file");
                    $scope.isPartImportExecuting = false;
                }
                fileUploadService
                      .importPartData(companyID)
                      .then(success, error);
            };

            $scope.ImportPartPriceData = function () {
                $scope.isPartPriceImportExecuting = true;
                function success(data) {
                    $scope.isPartPriceUploadSuccess = true;
                    notificationService.showGeneralSuccessMessage("Info Message :- Part Price Data Update Success");
                    $scope.isPartPriceImportExecuting = false;
                }

                function error(reason) {
                    $scope.isPartPriceUploadSuccess = false;
                    notificationService.showGeneralErrorMessage("Error Message :- Part Price Data Update Falied!! Please try again with valid 'Parts Price' Excel file");
                    $scope.isPartPriceImportExecuting = false;
                }
                fileUploadService
                      .importPartPriceData()
                      .then(success, error);
            };

            $scope.CheckFileValidExcel = function (file) {
                var isValid = false;
                if (file != null) {
                    if ((file.type == 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' || file.type == '.xlsx' || file.type == '.xls')) {
                        // $scope.FileInvalidMessage = "";
                        isValid = true;
                    }
                    else {
                        isValid = false;
                        //$scope.FileInvalidMessage = "Selected file is Invalid. (only file type xls and xlsx allowed)";
                    }
                }
                else {
                    // $scope.FileInvalidMessage = "Excel File required!";
                    isValid = false;
                }

                $scope.IsFileValid = isValid;
            };
        });
})();//End of the Function