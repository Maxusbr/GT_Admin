(function () {
    'use strict';

    function EventsConnectionsController($rootScope, $scope, personService) {
        var vm = this;
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

        $rootScope.addConnection= function add_connection() {
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.connections.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('EventsConnectionsController', EventsConnectionsController);

    EventsConnectionsController.$inject = ['$rootScope', '$scope', 'personService'];
})();