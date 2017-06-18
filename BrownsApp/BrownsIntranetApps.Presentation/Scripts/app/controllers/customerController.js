(function () {
    'use strict';
    angular.module('theApp').controller('customerController',
        function ($scope, $filter, $http, $location, $window, notificationService, stateDataService,customerdataservice) {
            $scope.allStates = stateDataService.getStates();
            $scope.shippingStates = stateDataService.getStates();

            

            //Shipping Address Loading
            //------------------------------------------------------------------------------------------------------------
            $scope.getSameAddrress = function ($event) {
                if ($event) {
                    $scope.CustomerDTO.ShippingAddress1 = $scope.CustomerDTO.Address1;
                    $scope.CustomerDTO.ShippingAddress2 = $scope.CustomerDTO.Address2;
                    $scope.CustomerDTO.ShippingCity = $scope.CustomerDTO.City;
                    $scope.CustomerDTO.ShippingZip = $scope.CustomerDTO.Zip;
                    $scope.CustomerDTO.ShippingState = $scope.CustomerDTO.State;
                }
                else {
                    $scope.CustomerDTO.ShippingAddress1 = "";
                    $scope.CustomerDTO.ShippingAddress2 = "";
                    $scope.CustomerDTO.ShippingCity = "";
                    $scope.CustomerDTO.ShippingZip = "";
                    $scope.CustomerDTO.ShippingState = 0;
                }
            };
            //------------------------------------------------------------------------------------------------------------
            //Add Part Controller
            $scope.addCustomer = function (event) {
                notificationService.showInfoMessageOnTarget("Adding Customer", event.target, false);
                function success(data) {
                    notificationService.showInfoMessageOnTarget("", event.target, false);
                    if (data != null)
                    {
                        if (data.IsCustomerAlreadyExist)
                        {
                            var message = 'Error Message :- The customer ' + data.Name + ' already exist!!!'
                            $scope.CustomerDTO = data;
                            notificationService.showGeneralErrorMessage(message);
                        }
                        else 
                        {
                            var url = "";
                            url = "/CustomerHome/CustomerHome";
                            $window.location.href = url;
                        }
                    }
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                //TypeCode Assignement
                $scope.CustomerDTO.State.TypeCode = $("#addrstate option:selected").text();
                $scope.CustomerDTO.ShippingState.TypeCode = $("#shpAddrState option:selected").text();

                customerdataservice
                    .addCustomer(
                        $scope.CustomerDTO)
                    .then(success, error);
            };

            //Search Customer
            //------------------------------------------------------------------------------------------------------------
            $scope.searchCustomer = function (customerId) {
                function success(data) {
                    $scope.CustomerDTO = data;
                }

                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }

                customerdataservice
                    .getCustomer(customerId)
                    .then(success, error);
            };
            //------------------------------------------------------------------------------------------------------------

            //Navigated from Customer Home to SearchPage
            //------------------------------------------------------------------------------------------------------------
            var searchText='';
            var q = window.location.search.substr(1);
            if (q.length) {
                var keys = q.split("=")
                searchText=keys[1];
                }

            if (searchText != "") {
                $scope.searchCustomer(searchText);
            }

            //-----------------------------------------------------------------------------------------------------------------

            //Add Customer Navigation
            //------------------------------------------------------------------------------------------------------------
            $scope.navigateToAddCustomer = function () {
                var url = "";
                url = "/Customer/CreateCustomer";
                $window.location.href = url;
            };
            //------------------------------------------------------------------------------------------------------------
            //Add Customer Navigation
            //------------------------------------------------------------------------------------------------------------
            $scope.navigateToCustomerDashboard = function () {
                var url = "";
                url = "/CustomerHome/CustomerHome";
                $window.location.href = url;
            };
            //------------------------------------------------------------------------------------------------------------

            //Edit Custmer Navigation
            //------------------------------------------------------------------------------------------------------------
            $scope.editCustomer = function (event) {
                var url = "";
                url = "/Customer/CreateCustomer#?Id=" + $scope.CustomerDTO.ID;
                
                $window.location.href = url;
            };

            var customerData = $location.search().Id;
            if (customerData != null) {
                $scope.searchCustomer(customerData);
             }

            //Delete Customer
            //------------------------------------------------------------------------------------------------------------
            $scope.deleteCustomer = function (customerId) {
                function success() {
                    $("#deleteCustomerModal").modal("toggle");
                    var url = "";
                    url = "CustomerHome/CustomerHome";
                    $window.location.href = url;
                    notificationService.showGeneralSuccessMessage("Info Message :- PartInvoice Removed from Database");
                    notificationService.showSuccessMessageOnTarget("Info Message :- PartInvoice Removed from Database");
                }
                function error(reason) {
                    notificationService.showErrorMessageOnTarget(reason.data, reason.status, event.target, false);
                }
                customerdataservice
                    .deleteCustomer(
                       customerId)
                    .then(success, error);
            };




        });
})();//End of the Function