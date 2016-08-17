(function () {
    'use strict';

   
    function UserViewoneController($rootScope, $scope, personService) {
        var vm = this;

        // $rootScope.displayNotes = function display_notes() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.notes.html', 2500);
        // }
        // $rootScope.displayFacts = function display_facts() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.facts.html', 2500);
        // }
        // $rootScope.displayMedia = function display_media() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.media.html', 2500);
        // }
        // $rootScope.displayConnections = function display_connections() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.connections.html', 2500);
        // }
        // $rootScope.displayUser = function display_internet() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.users.html', 2500);
        // }
        // $rootScope.displayAntro = function display_antro() {
        //     app.closeThird();
        //     app.loadContentView('/main/events/r3/events.antro.html', 2500);
        // }
        $scope.Id = $rootScope.eventId;
        $scope.counts = { CountDescriptions: 0, CountFacts: 0, CountConnects: 0, CountMedias: 0, CountLinks: 0, CountAntros: 0 }
        $scope.Promise = personService.getPerson($scope.Id, function (data) {
            $scope.person = data;
            personService.getCountes($scope.Id, function (counts) {
                $scope.counts = counts;
            });
        });

        $rootScope.editUser = function edit_user() {
            app.closeThird();
            app.loadContentView('/main/user/user.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('UserViewoneController', UserViewoneController);

    UserViewoneController.$inject = ['$rootScope', '$scope', 'personService'];
    
})();