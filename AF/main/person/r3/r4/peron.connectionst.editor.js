(function () {
    'use strict';

    function PersonConnectionstEditorController($rootScope, $scope, $filter, personService) {
        var vm = this;

        function getConnectionId() {
            switch ($rootScope.editedConnection.id_ConnectionType) {
                case 1:
                    return $rootScope.editedConnection.id_PersonConnectTo;
                case 2:
                case 3:
                    return $rootScope.editedConnection.id_Event;
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
        $scope.$watch('connectionId', function (id) {
            $rootScope.editedConnection.PersonConnectionType = $rootScope.connectiontypes.filter(function (item) {
                return item.Id === $rootScope.editedConnection.id_ConnectionType;
            })[0].Name;
            $rootScope.editedConnection.PersonConnectTo = null;
            $rootScope.editedConnection.id_PersonConnectTo = null;
            $rootScope.editedConnection.Event = null;
            $rootScope.editedConnection.id_Event = null;
            if (!id) return;
            switch ($rootScope.editedConnection.id_ConnectionType) {
                case 1:
                    $rootScope.editedConnection.id_PersonConnectTo = $scope.connectionId;
                    var person = $scope.connectionList.filter(function (item) {
                        return item.Id === $scope.connectionId;
                    })[0];
                    $rootScope.editedConnection.PersonConnectTo = { Name: person.Name, Id: person.Id };
                    break;
                case 2:
                case 3:
                    $rootScope.editedConnection.id_Event = $scope.connectionId;
                    var event = $scope.connectionList.filter(function (item) {
                        return item.Id === $scope.connectionId;
                    })[0];
                    $rootScope.editedConnection.Event = { Id: event.Id, Name: event.Name };
                    break;
                default:
                    break;
            }
        });
        $scope.getConnections = function (id) {
            getConnectionList(id);
            $scope.connectionId = getConnectionId();
        }
        //$scope.setConnection = function () {
        //    $rootScope.editedConnection.id_Event = 0;
        //    $rootScope.editedConnection.id_PersonConnectTo = 0;
        //    if (!$scope.connectionId) return;
        //    switch ($rootScope.editedConnection.id_ConnectionType) {
        //        case 1:
        //            $rootScope.editedConnection.id_PersonConnectTo = $scope.connectionId;
        //            var person = $scope.connectionList.filter(function (item) {
        //                return item.Id === $scope.connectionId;
        //            })[0];
        //            $rootScope.editedConnection.PersonConnectTo = { Name: person.Name, Id: person.Id };
        //            break;
        //        case 2:
        //        case 3:
        //            $rootScope.editedConnection.id_Event = $scope.connectionId;
        //            var event = $scope.connectionList.filter(function (item) {
        //                return item.Id === $scope.connectionId;
        //            })[0];
        //            $rootScope.editedConnection.Event = { Id: event.Id, Name: event.Name};
        //            break;
        //        default:
        //            break;
        //    }
        //}

        console.log

            $scope.getConnections($rootScope.editedConnection.id_ConnectionType);

        $rootScope.saveConnection = function () {
            console.log('save connection click');
            $rootScope.editedConnection.Event = null;
            $rootScope.editedConnection.PersonConnectTo = null;
            $rootScope.editedConnection.id_Person = $rootScope.personId;
            console.log($rootScope.editedConnection);
            personService.saveEntity($rootScope.personId, $rootScope.editedConnection, 'connection', function (data) {
                $rootScope.getPersonConnection();
                app.closeView('personConnectionEdit');
            });
        }
    }

    angular
        .module('app')
        .controller('PersonConnectionstEditorController', PersonConnectionstEditorController);

    PersonConnectionstEditorController.$inject = ['$rootScope', '$scope', '$filter', 'personService'];
})();