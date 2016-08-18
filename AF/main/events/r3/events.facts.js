(function () {
    'use strict';

    function EventFactsController($rootScope, $scope, eventService) {
        var vm = this;

        eventService.getFact($rootScope.eventId, function (data) {
            $scope.factlist = [];
            data.forEach(function (item) {
                $scope.factlist.push.apply($scope.factlist, item.List);
            });
        });

        $rootScope.addFact = function addFact(){
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.fact.edit.html', 3200);
        }
        $rootScope.editFact = function (item){
            $rootScope.editedFact = item;
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.fact.edit.html', 3200);
        }

        if (!$rootScope.facttypes)
            eventService.getFactTypes(function (data) {
                $rootScope.facttypes = [];
                $rootScope.facttypes.push.apply($rootScope.facttypes, data);
            });
    }

    angular
        .module('app')
        .controller('EventFactsController', EventFactsController);

    EventFactsController.$inject = ['$rootScope', '$scope', 'personService'];
})();