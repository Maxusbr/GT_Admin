

(function () {
    'use strict';

    angular
        .module('app')
        .controller('EventListController', EventListController);

    EventListController.$inject = ['$rootScope', '$scope', 'personService', '$interval'];
    function EventListController($rootScope, $scope, personService, $interval) {
        var vm = this;
        $scope.Promise = personService.getPersons();
        $rootScope.createEvent = function create_event() {
            console.log('create event');
            app.closeSecond();
            app.loadContentView('/main/events/events.create.html', 1800);
        }

        $scope.selectEvents = function (id) {
            console.log(id);
            $rootScope.Id = id;
            app.closeSecond();
            app.loadContentView('/main/events/events.viewone.html', 1800);
        }
    }
})();