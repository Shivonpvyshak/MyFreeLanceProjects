(function () {
    'use strict';

    angular.module('theApp').factory('fileUploadService',
        function ($http, $q) {
            //var fac = {};
            //fac.UploadFile = function (file, fileType) {
            //    var formData = new FormData();
            //    formData.append("file", file);
            //    formData.append("fileType", fileType);
            //    //We can send more data to server using append

            //    var defer = $q.defer();
            //    $http.post("/ImportData/SaveFiles", formData,
            //        {
            //            withCredentials: true,
            //            headers: { 'Content-Type': undefined },
            //            transformRequest: angular.identity
            //        })
            //    .success(function (d) {
            //        defer.resolve(d);
            //    })
            //    .error(function () {
            //        defer.reject("File Upload Failed!");
            //    });

            //    return defer.promise;
            //}
            //return fac;

            function uploadFile(file, fileType, companyID) {
                var formData = new FormData();
                formData.append("file", file);
                formData.append("fileType", fileType);
                formData.append("companyID", companyID);
                //We can send more data to server using append

                var defer = $q.defer();
                $http.post("/ImportData/SaveFiles", formData,
                    {
                        withCredentials: true,
                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    })
                .success(function (d) {
                    defer.resolve(d);
                })
                .error(function () {
                    defer.reject("File Upload Failed!");
                });

                return defer.promise;
            };

            function importPartData(companyID) {
                var formData = new FormData();
                formData.append("makeID", companyID);
                var defer = $q.defer();
                $http.post("/ImportData/ImportPartData", formData,
                    {
                        withCredentials: true,
                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    })
                .success(function (d) {
                    defer.resolve(d);
                })
                .error(function () {
                    defer.reject("File Upload Failed!");
                });

                return defer.promise;
            }

            function importPartPriceData() {
                var defer = $q.defer();
                $http.post("/ImportData/ImportPartPriceData",
                    {
                        withCredentials: true,
                        headers: { 'Content-Type': undefined },
                        transformRequest: angular.identity
                    })
                .success(function (d) {
                    defer.resolve(d);
                })
                .error(function () {
                    defer.reject("File Upload Failed!");
                });

                return defer.promise;
            };
            return {
                uploadFile: uploadFile,
                importPartData: importPartData,
                importPartPriceData: importPartPriceData
            };
        }
    );
})();