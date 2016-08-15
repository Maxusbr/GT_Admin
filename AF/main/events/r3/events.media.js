(function () {
    'use strict';

    function EventsMediaController($rootScope, $scope, personService) {
        var vm = this;

        personService.getMedia($rootScope.personId, function (data) {
            $scope.medias = [];
            $scope.medialist = [];
            data.forEach(function (item) {
                if (item.List.length > 0)
                    $scope.medias.push({
                        type: item.List[0].MediaType,
                        value: item.List[0].MediaLink,
                        count: item.Count - 1
                    });
                $scope.medialist.push.apply($scope.medialist, item.List);
            });
        });

        $rootScope.addFact = function add_fact() {
            app.closeFour();
            app.loadContentView('/main/events/r3/r4/events.fact.create.html', 3200)
        }
    }

    angular
        .module('app')
        .controller('EventsMediaController', EventsMediaController);

    EventsMediaController.$inject = ['$rootScope', '$scope', 'personService'];
})();