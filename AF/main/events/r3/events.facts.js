(function () {
    'use strict';

    function EventFactsController($rootScope, $scope, eventService) {
        var vm = this;

        $rootScope.getFacts = function () {
            eventService.getFact($rootScope.eventId, function (data) {
                $scope.factlist = data;
                $scope.factlist.forEach(function (item) {
                    if (item.LastChange)
                        item.LastChange.localdate = new Date(item.LastChange.Date);
                });
            });
        }
        $rootScope.getFacts();

        //eventService.getFact($rootScope.eventId, function (data) {
        //    $scope.factlist = [];
        //    data.forEach(function (item) {
        //        $scope.factlist.push.apply($scope.factlist, item.List);
        //    });
        //});

        $rootScope.addFact = function addFact() {
            $rootScope.editedFact = {}
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

    EventFactsController.$inject = ['$rootScope', '$scope', 'eventService'];
})();