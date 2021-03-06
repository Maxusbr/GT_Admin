﻿(function () {
    'use strict';

    function PersonConnectionstEditorController($rootScope, $scope, $filter, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';

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
            if (typeof $scope.connectionId !== "number") return;
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
                    $scope.connectionId = person.Name;
                    break;
                case 2:
                case 3:
                    $rootScope.editedConnection.id_Event = $scope.connectionId;
                    var event = $scope.connectionList.filter(function (item) {
                        return item.Id === $scope.connectionId;
                    })[0];
                    $rootScope.editedConnection.Event = { Id: event.Id, Name: event.Name };
                    $scope.connectionId = event.Name;
                    break;
                default:
                    break;
            }
        });
        $scope.getConnections = function (id) {
            getConnectionList(id);
            $scope.connectionId = getConnectionId();
        }

        $scope.getConnections($rootScope.editedConnection.id_ConnectionType);

        $rootScope.saveConnection = function () {
            console.log($scope.editedConnection.id_ConnectionType);
            console.log($scope.connectionId);

            if ($scope.editedConnection.id_ConnectionType == undefined) {
                $scope.errorYes = true;
                $scope.message = 'Выберите тип связи';
                $scope.showMessage = true;
                return;
            }
            if ($scope.connectionId == undefined) {
                $scope.errorYes = true;
                $scope.message = 'Выберите тип связи';
                $scope.showMessage = true;
                return;
            }
          
            console.log('save connection click');
            $rootScope.editedConnection.Event = null;
            $rootScope.editedConnection.PersonConnectTo = null;
            $rootScope.editedConnection.id_Person = $rootScope.personId;
            console.log($rootScope.editedConnection);
            personService.saveEntity($rootScope.personId, $rootScope.editedConnection, 'connection', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                if ($rootScope.getPersonCounts)
                    $rootScope.getPersonCounts();
                $rootScope.getPersonConnection();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('personConnectionEdit');
                    }, timeoutMsgShow);

            });
        }
    }

    angular
        .module('app')
        .controller('PersonConnectionstEditorController', PersonConnectionstEditorController);

    PersonConnectionstEditorController.$inject = ['$rootScope', '$scope', '$filter', 'personService', '$timeout'];
})();