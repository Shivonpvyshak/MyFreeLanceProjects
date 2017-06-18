(function () {
    'use strict';

    angular.module('theApp').factory('stateDataService',
        function () {
            var states = [
                { TypeCodeID: 1, TypeCode: "Alabama" },
	            { TypeCodeID: 2, TypeCode: "Alaska" },
	            { TypeCodeID: 3, TypeCode: "Arizona" },
	            { TypeCodeID: 4, TypeCode: "Arkansas" },
	            { TypeCodeID: 5, TypeCode: "California" },
	            { TypeCodeID: 6, TypeCode: "Colorado" },
	            { TypeCodeID: 7, TypeCode: "Connecticut" },
	            { TypeCodeID: 8, TypeCode: "Delaware" },
	            { TypeCodeID: 9, TypeCode: "District of Columbia" },
	            { TypeCodeID: 10, TypeCode: "Florida" },
	            { TypeCodeID: 11, TypeCode: "Georgia" },
	            { TypeCodeID: 12, TypeCode: "Hawaii" },
	            { TypeCodeID: 13, TypeCode: "Idaho" },
	            { TypeCodeID: 14, TypeCode: "Illinois" },
	            { TypeCodeID: 15, TypeCode: "Indiana" },
	            { TypeCodeID: 16, TypeCode: "Iowa" },
	            { TypeCodeID: 17, TypeCode: "Kansas" },
	            { TypeCodeID: 18, TypeCode: "Kentucky" },
	            { TypeCodeID: 19, TypeCode: "Louisiana" },
	            { TypeCodeID: 20, TypeCode: "Maine" },
	            { TypeCodeID: 21, TypeCode: "Maryland" },
	            { TypeCodeID: 22, TypeCode: "Massachusetts" },
	            { TypeCodeID: 23, TypeCode: "Michigan" },
	            { TypeCodeID: 24, TypeCode: "Minnesota" },
	            { TypeCodeID: 25, TypeCode: "Mississippi" },
	            { TypeCodeID: 26, TypeCode: "Missouri" },
	            { TypeCodeID: 27, TypeCode: "Montana" },
	            { TypeCodeID: 28, TypeCode: "Nebraska" },
	            { TypeCodeID: 29, TypeCode: "Nevada" },
	            { TypeCodeID: 30, TypeCode: "New Hampshire" },
	            { TypeCodeID: 31, TypeCode: "New Jersey" },
	            { TypeCodeID: 32, TypeCode: "New Mexico" },
	            { TypeCodeID: 33, TypeCode: "New York" },
	            { TypeCodeID: 34, TypeCode: "North Carolina" },
	            { TypeCodeID: 35, TypeCode: "North Dakota" },
	            { TypeCodeID: 36, TypeCode: "Ohio" },
	            { TypeCodeID: 37, TypeCode: "Oklahoma" },
	            { TypeCodeID: 38, TypeCode: "Oregon" },
	            { TypeCodeID: 39, TypeCode: "Pennsylvania" },
	            { TypeCodeID: 40, TypeCode: "Rhode Island" },
	            { TypeCodeID: 41, TypeCode: "South Carolina" },
	            { TypeCodeID: 42, TypeCode: "South Dakota" },
	            { TypeCodeID: 43, TypeCode: "Tennessee" },
	            { TypeCodeID: 44, TypeCode: "Texas" },
	            { TypeCodeID: 45, TypeCode: "Utah" },
	            { TypeCodeID: 46, TypeCode: "Vermont" },
	            { TypeCodeID: 47, TypeCode: "Virginia" },
	            { TypeCodeID: 48, TypeCode: "Washington" },
	            { TypeCodeID: 49, TypeCode: "West Virginia" },
	            { TypeCodeID: 50, TypeCode: "Wisconsin" },
	            { TypeCodeID: 51, TypeCode: "Wyoming" }

            ];

            function getStates() {
                return states;
            };

            return {
                getStates: getStates
            };
        }
    );
})();