(function () {
    'use strict';

    function EventsFactEditController($rootScope, $scope, eventService) {
        var vm = this;
        
        $rootScope.saveFact = function save_fact() {
            console.log('save fact click, event - '+  $rootScope.eventId);

            $rootScope.editedFact.id_Event = $rootScope.eventId;
            eventService.saveEntity($rootScope.eventId, $rootScope.editedFact, 'fact', function (data) {
                $rootScope.getFacts();
                app.closeView('personFactCreate');
            });
        }

        $scope.setConnection = function (id) {
            if (!id) return;
            var type = $rootScope.facttypes.filter(function (item) {
                return item.Id === id;
            })[0];
            $rootScope.editedFact.FactType = type;
        }
    }

    angular
        .module('app')
        .controller('EventsFactEditController', EventsFactEditController);

    EventsFactEditController.$inject = ['$rootScope', '$scope', 'eventService'];
})();