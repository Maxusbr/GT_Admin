(function () {
    'use strict';

    function EventsConnectionsEditController($rootScope, $scope, eventService, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = 'Error';

        $rootScope.saveConnection = function () {
            console.log($scope.connectionId);

            if ($scope.connectionId == undefined) {
                $scope.showMessage = true;
                $scope.errorYes = true;
                $scope.message = 'Объект обязательное поле';
                return;
            }

            console.log('save connection click');

            $rootScope.editedConnection.EventConnectTo = null;
            $rootScope.editedConnection.Person = null;
            $rootScope.editedConnection.id_Event = $rootScope.eventId;
            console.log($rootScope.editedConnection);
            $scope.Promise = eventService.saveEntity($rootScope.eventId, $rootScope.editedConnection, 'connection', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                $rootScope.getEventConnection();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('eventConnectionCreate');
                    }, timeoutMsgShow);

            });
        }

        $rootScope.displayLinkTypes = function () {
            app.loadContentView('/main/dictionary/dictionary.person.links.html', 3200);
        }

        function getConnectionId() {
            switch ($rootScope.editedConnection.id_ConnectionType) {
                case 1:
                    return $rootScope.editedConnection.id_Person;
                case 2:
                case 3:
                    return $rootScope.editedConnection.id_EventConnectTo;
                default:
                    break;
            }

        }




        function getConnectionList(id) {
            $scope.connectionList = [];
            switch (id) {
                case 1:
                    $rootScope.persons.forEach(function (item) {
                        $scope.connectionList.push({ Id: item.Id, Name: `${item.LastName} ${item.Name}` });
                    });
                    break;
                case 2:
                    $rootScope.events.forEach(function (item) {
                        $scope.connectionList.push({ Id: item.Id, Name: item.Name });
                    });
                    break;
                case 3:
                    $rootScope.realyEvents.forEach(function (item) {
                        $scope.connectionList.push({ Id: item.Id, Name: item.Name });
                    });
                    break;
                default:
                    break;
            }
        }


        $scope.getConnections = function (id) {
            getConnectionList(id);
            $scope.connectionId = getConnectionId();
        }
        function readyGet() {
            $scope.getConnections($rootScope.editedConnection.id_ConnectionType);
            $scope.$watch('connectionId', function (id) {
                $rootScope.editedConnection.PersonConnectionType = $rootScope.connectiontypes.filter(function (item) {
                    return item.Id === $rootScope.editedConnection.id_ConnectionType;
                })[0].Name;
                $rootScope.editedConnection.Person = null;
                $rootScope.editedConnection.id_Person = null;
                $rootScope.editedConnection.EventConnectTo = null;
                $rootScope.editedConnection.id_EventConnectTo = null;
                if (!id) return;
                switch ($rootScope.editedConnection.id_ConnectionType) {
                    case 1:
                        $rootScope.editedConnection.id_Person = $scope.connectionId;
                        var person = $scope.connectionList.filter(function (item) {
                            return item.Id === $scope.connectionId;
                        })[0];
                        $rootScope.editedConnection.Person = { Name: person.Name, Id: person.Id };
                        break;
                    case 2:
                    case 3:
                        $rootScope.editedConnection.id_EventConnectTo = $scope.connectionId;
                        var event = $scope.connectionList.filter(function (item) {
                            return item.Id === $scope.connectionId;
                        })[0];
                        $rootScope.editedConnection.EventConnectTo = { Id: event.Id, Name: event.Name };
                        break;
                    default:
                        break;
                }
            });
        }

        if (!$rootScope.persons)
            $scope.Promise = personService.getPersons(readyGet);
        else readyGet();

    }

    angular
        .module('app')
        .controller('EventsConnectionsEditController', EventsConnectionsEditController);

    EventsConnectionsEditController.$inject = ['$rootScope', '$scope', 'eventService', 'personService', '$timeout'];
})();