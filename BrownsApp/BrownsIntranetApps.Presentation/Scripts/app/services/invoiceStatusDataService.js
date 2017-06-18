(function () {
    'use strict';

    angular.module('theApp').factory('invoiceStatusDataService',
        function () {
            var invoiceStatuses = [
            { TypeCode: "In Progress", TypeCodeID: 1 },
            { TypeCode: "Pending Validation", TypeCodeID: 2 },
            { TypeCode: "Approved", TypeCodeID: 3 },
            { TypeCode: "Payment Pending", TypeCodeID: 4 },
            { TypeCode: "Paid", TypeCodeID: 5 },
            { TypeCode: "Closed", TypeCodeID: 6 }
            ];

            function getInvoiceStatuses() {
                return invoiceStatuses;
            };

            return {
                getInvoiceStatuses: getInvoiceStatuses
            };
        }
    );
})();