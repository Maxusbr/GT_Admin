(function () {
    'use strict';

    function EventsConnectionsController($rootScope, $scope, eventService) {
        var vm = this;
        $rootScope.getEventConnection = function () {
            $scope.Promise = eventService.getConnection($rootScope.eventId, function (data) {
                $scope.connectionList = [];
                data.forEach(function (item) {
                    if (item.List.length > 0) {
                        $scope.connectionList.push.apply($scope.connectionList, item.List);
                    }
                });
            });
        }
        $rootScope.getEventConnection();

        if (!$rootScope.connectiontypes)
            eventService.getСonnectionTypes(function (data) {
                $rootScope.connectiontypes = [];
                $rootScope.connectiontypes.push.apply($rootScope.connectiontypes, data);
            });
        $scope.editEventConnection = function (item) {
            $rootScope.editedConnection = item;
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.connections.edit.html', 3200);
        }
        $scope.addEventConnection = function () {
            $rootScope.editedConnection = { id_ConnectionType: 1 };
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.connections.edit.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('EventsConnectionsController', EventsConnectionsController);

    EventsConnectionsController.$inject = ['$rootScope', '$scope', 'eventService'];
})();