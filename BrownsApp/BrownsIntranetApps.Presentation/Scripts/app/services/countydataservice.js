﻿(function () {
    'use strict';

    angular.module('theApp').factory('countydataservice',
        function () {
            var counties = [
            { TypeCodeID: 1,  TypeCode: "N/A"},
            { TypeCodeID: 2,  TypeCode: "Nebraska"},
            { TypeCodeID: 3,  TypeCode: "Adair"},
            { TypeCodeID: 4,  TypeCode: "Adams"},
            { TypeCodeID: 5,  TypeCode: "Allamakee"},
            { TypeCodeID: 6,  TypeCode: "Appanoose"},
            { TypeCodeID: 7,  TypeCode: "Audubon"},
            { TypeCodeID: 8,  TypeCode: "Benton"},
            { TypeCodeID: 9,  TypeCode: "Black Hawk"},
            { TypeCodeID: 10, TypeCode: "Boone"},
            { TypeCodeID: 11, TypeCode: "Bremer"},
            { TypeCodeID: 12, TypeCode: "Buchanan"},
            { TypeCodeID: 13, TypeCode: "Buena Vista"},
            { TypeCodeID: 14, TypeCode: "Butler"},
            { TypeCodeID: 15, TypeCode: "Calhoun"},
            { TypeCodeID: 16, TypeCode: "Carroll"},
            { TypeCodeID: 17, TypeCode: "Cass"},
            { TypeCodeID: 18, TypeCode: "Cedar"},
            { TypeCodeID: 19, TypeCode: "Cerro Gordo"},
            { TypeCodeID: 20, TypeCode: "Cherokee"},
            { TypeCodeID: 21, TypeCode: "Chickasaw"},
            { TypeCodeID: 22, TypeCode: "Clarke"},
            { TypeCodeID: 23, TypeCode: "Clay"},
            { TypeCodeID: 24, TypeCode: "Clayton"},
            { TypeCodeID: 25, TypeCode: "Clinton"},
            { TypeCodeID: 26, TypeCode: "Crawford"},
            { TypeCodeID: 27, TypeCode: "Dallas"},
            { TypeCodeID: 28, TypeCode: "Davis"},
            { TypeCodeID: 29, TypeCode: "Decatur"},
            { TypeCodeID: 30, TypeCode: "Delaware"},
            { TypeCodeID: 31, TypeCode: "Des Moines"},
            { TypeCodeID: 32, TypeCode: "Dickinson"},
            { TypeCodeID: 33, TypeCode: "Dubuque"},
            { TypeCodeID: 34, TypeCode: "Emmet"},
            { TypeCodeID: 35, TypeCode: "Fayette"},
            { TypeCodeID: 36, TypeCode: "Floyd"},
            { TypeCodeID: 37, TypeCode: "Franklin"},
            { TypeCodeID: 38, TypeCode: "Fremont"},
            { TypeCodeID: 39, TypeCode: "Greene"},
            { TypeCodeID: 40, TypeCode: "Grundy"},
            { TypeCodeID: 41, TypeCode: "Guthrie"},
            { TypeCodeID: 42, TypeCode: "Hamilton"},
            { TypeCodeID: 43, TypeCode: "Hancock"},
            { TypeCodeID: 44, TypeCode: "Hardin"},
            { TypeCodeID: 45, TypeCode: "Harrison"},
            { TypeCodeID: 46, TypeCode: "Henry"},
            { TypeCodeID: 47, TypeCode: "Howard"},
            { TypeCodeID: 48, TypeCode: "Humboldt"},
            { TypeCodeID: 49, TypeCode: "Ida"},
            { TypeCodeID: 50, TypeCode: "Iowa"},
            { TypeCodeID: 51 ,TypeCode: "Jackson"},
            { TypeCodeID: 52 ,TypeCode: "Jasper"},
            { TypeCodeID: 53 ,TypeCode: "Jefferson"},
            { TypeCodeID: 54 ,TypeCode: "Johnson"},
            { TypeCodeID: 55 ,TypeCode: "Jones"},
            { TypeCodeID: 56 ,TypeCode: "Keokuk"},
            { TypeCodeID: 57 ,TypeCode: "Kossuth"},
            { TypeCodeID: 58 ,TypeCode: "Lee"},
            { TypeCodeID: 59, TypeCode: "Linn"},
            { TypeCodeID: 60, TypeCode: "Louisa"},
            { TypeCodeID: 61, TypeCode: "Lucas"},
            { TypeCodeID: 62, TypeCode: "Lyon"},
            { TypeCodeID: 63, TypeCode: "Madison"},
            { TypeCodeID: 64, TypeCode: "Mahaska"},
            { TypeCodeID: 65, TypeCode: "Marion"},
            { TypeCodeID: 66, TypeCode: "Marshall"},
            { TypeCodeID: 67, TypeCode: "Mills"},
            { TypeCodeID: 68, TypeCode: "Mitchell"},
            { TypeCodeID: 69, TypeCode: "Monona"},
            { TypeCodeID: 70, TypeCode: "Monroe"},
            { TypeCodeID: 71, TypeCode: "Montgomery"},
            { TypeCodeID: 72, TypeCode: "Muscatine"},
            { TypeCodeID: 73, TypeCode: "O'Brien"},
            { TypeCodeID: 74, TypeCode: "Osceola"},
            { TypeCodeID: 75, TypeCode: "Page"},
            { TypeCodeID: 76, TypeCode: "Palo Alto"},
            { TypeCodeID: 77, TypeCode: "Plymouth"},
            { TypeCodeID: 78, TypeCode: "Pocahontas"},
            { TypeCodeID: 79, TypeCode: "Polk"},
            { TypeCodeID: 80, TypeCode: "Pottawattamie"},
            { TypeCodeID: 91, TypeCode: "Poweshiek"},
            { TypeCodeID: 92, TypeCode: "Ringgold"},
            { TypeCodeID: 93, TypeCode: "Sac"},
            { TypeCodeID: 94, TypeCode: "Scott"},
            { TypeCodeID: 95, TypeCode: "Shelby"},
            { TypeCodeID: 96, TypeCode: "Sioux"},
            { TypeCodeID: 97, TypeCode: "Story"},
            { TypeCodeID: 98, TypeCode: "Tama"},
            { TypeCodeID: 99, TypeCode: "Taylor"},
            { TypeCodeID: 100, TypeCode: "Union"},
            { TypeCodeID: 101, TypeCode: "Van Buren"},
            { TypeCodeID: 102, TypeCode: "Wapello"},
            { TypeCodeID: 103, TypeCode: "Warren"},
            { TypeCodeID: 104, TypeCode: "Washington"},
            { TypeCodeID: 105, TypeCode: "Wayne"},
            { TypeCodeID: 106, TypeCode: "Webster"},
            { TypeCodeID: 107, TypeCode: "Winnebago"},
            { TypeCodeID: 108, TypeCode: "Winneshiek"},
            { TypeCodeID: 109, TypeCode: "Woodbury"},
            { TypeCodeID: 110, TypeCode: "Worth"},
            { TypeCodeID: 111, TypeCode: "Wright"}];

            function getCounties() {
                return counties;
            };

            return {
                getCounties: getCounties
            };
        }
    );
})();





