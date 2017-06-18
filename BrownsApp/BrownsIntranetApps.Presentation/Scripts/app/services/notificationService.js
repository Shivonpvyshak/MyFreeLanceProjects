(function () {
    'use strict';

    angular.module('theApp').factory('notificationService',
        function () {
            function showGeneralErrorMessage(errorMessage) {
                $.notify(errorMessage, { className: "error" });
            };

            function showGeneralSuccessMessage(successMessage) {
                $.notify(successMessage, { className: "success" });
            };

            function showErrorMessageOnTarget(data, status, target, autoHide) {
                var errorMessage = "Failed: ";

                switch (status) {
                    case 0:
                        errorMessage += "Could not reach application.  Please try again later.";
                        break;
                    case 400:
                        errorMessage += data;
                        break;
                    case 500:
                        errorMessage += data.Message;
                        break;
                    default:
                        errorMessage += "Unknown error.";
                }

                if (!status) {
                    errorMessage = "Could not reach application.  Please try again later.";
                }

                $.notify(target, errorMessage, { className: "error", autoHide: autoHide });
            }

            function showInfoMessageOnTarget(infoMessage, target, autoHide) {
                $.notify(target, infoMessage, { className: "info", autoHide: autoHide });
            }

            function showSuccessMessageOnTarget(infoMessage, target, autoHide) {
                $.notify(target, infoMessage, { className: "success", autoHide: autoHide });
            }

            return {
                showGeneralErrorMessage: showGeneralErrorMessage,
                showGeneralSuccessMessage: showGeneralSuccessMessage,
                showErrorMessageOnTarget: showErrorMessageOnTarget,
                showInfoMessageOnTarget: showInfoMessageOnTarget,
                showSuccessMessageOnTarget: showSuccessMessageOnTarget
            };
        }
    );
})();