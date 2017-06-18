(function () {
    'use strict';

    angular.module('theApp').factory('laborDataService',
        function () {
            var labortypes = [
            { TypeCode: "Field", TypeCodeID: 1 },
            { TypeCode: "Field OT", TypeCodeID: 2 },
            { TypeCode: "Shop", TypeCodeID: 3 },
            { TypeCode: "Shop OT", TypeCodeID: 4 }
            ];

            function getLaborTypes() {
                return labortypes;
            };

            return {
                getLaborTypes: getLaborTypes
            };
        }
    );
})();