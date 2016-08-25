

(function () {
    'use strict';

    angular
        .module('app')
        .controller('EventListController', EventListController);

    EventListController.$inject = ['$rootScope', '$scope', 'eventService', '$interval'];
    function EventListController($rootScope, $scope, eventService, $interval) {
        var vm = this;
        $rootScope.loadEvent = function() {
            $scope.Promise = eventService.getEvents();
        }
        $rootScope.loadEvent();

        $scope.createEvent = function () {
            console.log('create event');
            $rootScope.editEvent = {}
            app.closeSecond();
            app.loadContentView('/main/events/events.edit.html', 1800);
        }

        $scope.selectEvents = function (id) {
            console.log(id);
            $rootScope.eventId = id;
            app.closeSecond();
            app.loadContentView('/main/events/events.viewone.html', 1800);
        }
    }
})();