(function () {
    'use strict';

    function PersonConnectionsController($rootScope, $scope, personService, eventService, $q) {
        var vm = this;
        $rootScope.getPersonConnection = function () {
            $scope.Promise = personService.getConnection($rootScope.personId, function (data) {
                $scope.connectionList = [];

                var deferred = $q.defer();
                var promise = deferred.promise;
                promise.then(function () {
                    data.forEach(function (item) {
                        if (item.List.length > 0) {
                            $scope.connectionList.push.apply($scope.connectionList, item.List);
                        }
                    });
                }).then(function () {
                    $scope.connectionList.forEach(function (item) {
                        if (item.LastChange)
                            item.LastChange.localdate = new Date(item.LastChange.Date);
                    });
                });
                deferred.resolve();

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
            $rootScope.editedConnection = { id_ConnectionType: 1 };
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

    PersonConnectionsController.$inject = ['$rootScope', '$scope', 'personService', 'eventService', '$q'];
})();