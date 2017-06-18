(function () {
    'use strict';

    angular.module('theApp').factory('companyDataService',
        function () {
            var companies = [
            { companyName: "All", companyID: -1 },
            { companyName: "JLG", companyID: 1 },
            { companyName: "SkyTrak", companyID: 2 },
            { companyName: "Gradall", companyID: 3 },
            { companyName: "Lull", companyID: 4 }
            ];

            function getCompanies() {
                return companies;
            };

            return {
                getCompanies: getCompanies
            };
        }
    );
})();