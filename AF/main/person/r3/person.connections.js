(function () {
    'use strict';

    function PersonConnectionsController($rootScope, $scope, personService, eventService) {
        var vm = this;
        $rootScope.getPersonConnection = function() {
            personService.getConnection($rootScope.personId, function (data) {
            $scope.connections = [];
            $scope.connectionList = [];
            data.forEach(function (item) {
                if (item.List.length > 0) {
                    var connection = item.Type > 1 ? {
                        name: item.List[0].PersonConnectionType,
                        descript: item.List[0].Description,
                        value: item.List[0].Event.Name,
                        count: item.Count - 1
                    } : {
                        name: item.List[0].PersonConnectionType,
                        descript: item.List[0].Description,
                        value: `${item.List[0].PersonConnectTo.LastName} ${item.List[0].PersonConnectTo.Name}`,
                        count: item.Count - 1
                    };
                    $scope.connectionList.push.apply($scope.connectionList, item.List);
                    $scope.connections.push(connection);
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

            app.closeFour(); 
            $rootScope.editedConnection = { id_ConnectionType: 0, Id: 0, id_Event: 0, PersonConnectTo: null, LastChange: null, Person: null, PersonConnectionType:'', id_PersonConnectTo:null};
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