(function () {
    'use strict';

   
    function EventsViewoneController($rootScope, $scope, eventService) {
        var vm = this;

        $rootScope.displayNotes = function () {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.notes.html', 2500);
        }
        $rootScope.displayFacts = function () {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.facts.html', 2500);
        }
        $rootScope.displayHapens = function () {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.hapens.html', 2500);
        }
        $rootScope.displayMedia = function () {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.media.html', 2500);
        }
        $rootScope.displayConnections = function () {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.connections.html', 2500);
        }
        $rootScope.displayUser = function () {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.users.html', 2500);
        }
        // $rootScope.displayAntro = function display_antro() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.antro.html', 2500);
        // }
        $scope.Id = $rootScope.eventId;
        $scope.counts = { CountDescriptions: 0, CountFacts: 0, CountConnects: 0, CountMedias: 0, CountLinks: 0, CountAntros: 0 }
        $rootScope.getEvent = function(id) {
            $scope.Promise = eventService.getEvent(id, function (data) {
                $scope.event = data;
                eventService.getCountes(id, function (counts) {
                    $scope.counts = counts;
                });
            });
        }
        $rootScope.getEvent($scope.Id);

        $scope.editEvent = function (event) {
            $rootScope.editEvent = event;
            app.closeThird();
            app.loadContentView('/main/events/events.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('EventsViewoneController', EventsViewoneController);

    EventsViewoneController.$inject = ['$rootScope', '$scope', 'eventService'];
    
})();