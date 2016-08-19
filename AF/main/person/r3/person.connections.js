(function () {
    'use strict';

    function PersonConnectionsController($rootScope, $scope, personService, eventService) {
        var vm = this;
        $rootScope.getPersonConnection = function() {
            $scope.Promise = personService.getConnection($rootScope.personId, function (data) {
            $scope.connectionList = [];
            data.forEach(function (item) {
                if (item.List.length > 0) {
                    $scope.connectionList.push.apply($scope.connectionList, item.List);
                }
            });
        });
        }
        $rootScope.getPersonConnection();

        if (!$rootScope.connectiontypes)
            personService.getСonnectionTypes(function (data) {
                $rootScope.connectiontypes = [];
                $rootScope.connectiontypes.push.apply($rootScope.connectiontypes, data);
            });
        if (!$rootScope.events)
            eventService.getEvents();
        if (!$rootScope.realyEvents)
            eventService.getRealyEvents();
        $rootScope.addConnection = function () {
            $rootScope.editedConnection = { id_ConnectionType: 1};
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.connectionst.editor.html', 3200);
        }
        $rootScope.editConnection = function (item) {
            $rootScope.editedConnection = item;
            app.closeFour();
            app.loadContentView('/main/person/r3/r4/peron.connectionst.editor.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('PersonConnectionsController', PersonConnectionsController);

    PersonConnectionsController.$inject = ['$rootScope', '$scope', 'personService', 'eventService'];
})();