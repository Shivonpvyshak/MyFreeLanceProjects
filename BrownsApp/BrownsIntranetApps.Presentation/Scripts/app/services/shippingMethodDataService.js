(function () {
    'use strict';

    angular.module('theApp').factory('shippingMethodDataService',
        function () {
            var shippingMethods = [
            { TypeCode: "UPS Ground", TypeCodeID: 1 },
            { TypeCode: "UPS Next Day Air", TypeCodeID: 2 },
            { TypeCode: "UPS 2nd Day Air", TypeCodeID: 3 },
            { TypeCode: "LTL Freight", TypeCodeID: 4 }
            ];

            function getshippingMethods() {
                return shippingMethods;
            };

            return {
                getshippingMethods: getshippingMethods
            };
        }
    );
})();





