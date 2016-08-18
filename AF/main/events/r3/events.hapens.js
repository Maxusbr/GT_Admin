(function () {
    'use strict';

    function EventsHapensController($rootScope, $scope, personService) {
        var vm = this;

        personService.getFact($rootScope.personId, function (data) {
            $scope.factlist = [];
            data.forEach(function (item) {
                $scope.factlist.push.apply($scope.factlist, item.List);
            });
        });

        $rootScope.addHapens = function addHapens(){
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.fact.create.html', 3200);
        }
    }

    angular
        .module('app')
        .controller('EventsHapensController', EventsHapensController);

    EventsHapensController.$inject = ['$rootScope', '$scope', 'personService'];
})();