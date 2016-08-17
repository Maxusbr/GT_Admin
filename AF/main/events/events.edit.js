(function () {
    'use strict';

    function EventsEditController($rootScope, $scope, eventService, $filter) {
        var vm = this;
        $scope.event = $rootScope.editEvent;
        eventService.getCategories(function (data) {
            $rootScope.eventCategories = data;
            $scope.baseCategory = data.filter(function (item) {
                return item.IdParent == null;
            });
        });
        $scope.getChildCategory = function (id) {
            if (!$rootScope.eventCategories) return [];
            return $rootScope.eventCategories.filter(function(item) {
                return item.IdParent === id;
            });
        }
    }

    angular
        .module('app')
        .controller('EventsEditController', EventsEditController);

    EventsEditController.$inject = ['$rootScope', '$scope', 'eventService', '$filter'];
})();