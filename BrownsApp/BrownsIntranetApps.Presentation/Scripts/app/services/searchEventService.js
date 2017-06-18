(function () {
    'use strict';

    angular.module('theApp').factory('searchEventService',
        function ($rootScope) {
            var service = {};

            service.SelectedPart = null;
            service.EditPart = null;
            service.DeletePart = null;

            service.partSelected = function (part) {
                this.SelectedPart = part;
                this.broadcastSelectedPart();
            };

            service.partEdit = function (part) {
                this.EditPart = part;
                this.broadcastEditPart();
            };

            service.partDelete = function (part) {
                this.DeletePart = part;
                this.broadcastDeletePart();
            };
            service.nodeDeleted = function () {
                this.broadcastDeletedNode();
            }

            service.deSelectNode = function (node) {
                this.SelectedPart = null;
                this.broadcastDeSelectedNode();
            }

            service.broadcastSelectedPart = function () {
                $rootScope.$broadcast('handleBroadcastViewPart');
            };

            service.broadcastEditPart = function () {
                $rootScope.$broadcast('handleBroadcastEditPart');
            }

            service.broadcastDeletePart = function () {
                $rootScope.$broadcast('handleBroadcastDeletePart');
            }

            service.broadcastDeSelectedNode = function () {
                $rootScope.$broadcast('handleBroadcastDeSelectedNode');
            }

            return service;
        }
    );
})();