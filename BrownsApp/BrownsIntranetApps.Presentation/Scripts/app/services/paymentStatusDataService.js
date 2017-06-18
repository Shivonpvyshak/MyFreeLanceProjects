(function () {
    'use strict';

    angular.module('theApp').factory('paymentStatusDataService',
        function () {
            var paymentStatuses = [
            { TypeCode: "Due on Receipt", TypeCodeID: 1 },
            { TypeCode: "Credit Card", TypeCodeID: 2 },
            { TypeCode: "Wire Transfer", TypeCodeID: 3 }
            ];

            function getPaymentStatuses() {
                return paymentStatuses;
            };

            return {
                getPaymentStatuses: getPaymentStatuses
            };
        }
    );
})();
