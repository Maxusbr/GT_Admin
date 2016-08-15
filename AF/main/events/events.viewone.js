(function () {
    'use strict';

   
    function EventsViewoneController($rootScope, $scope, personService) {
        var vm = this;

        $rootScope.displayNotes = function display_notes() {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.notes.html', 2500);
        }
        $rootScope.displayFacts = function display_facts() {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.facts.html', 2500);
        }
        $rootScope.displayMedia = function display_media() {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.media.html', 2500);
        }
        $rootScope.displayConnections = function display_connections() {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.connections.html', 2500);
        }
        $rootScope.displayUser = function display_internet() {
            app.closeThird();
            app.loadContentView('/main/events/r3/events.users.html', 2500);
        }
        // $rootScope.displayAntro = function display_antro() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.antro.html', 2500);
        // }
        $scope.Id = $rootScope.Id;
        $scope.counts = { CountDescriptions: 0, CountFacts: 0, CountConnects: 0, CountMedias: 0, CountLinks: 0, CountAntros: 0 }
        $scope.Promise = personService.getPerson($scope.Id, function (data) {
            $scope.person = data;
            personService.getCountes($scope.Id, function (counts) {
                $scope.counts = counts;
            });
        });
        $rootScope.editEvent = function edit_person() {
            app.closeThird();
            app.loadContentView('/main/events/events.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('EventsViewoneController', EventsViewoneController);

    EventsViewoneController.$inject = ['$rootScope', '$scope', 'personService'];
    
})();