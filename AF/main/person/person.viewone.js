(function () {
    'use strict';

    function personViewoneController($rootScope, $scope, personService) {
        var vm = this;

        $rootScope.displayFacts = function display_facts(){
            app.closeThird();
            app.loadContentView('/main/person/r3/person.facts.html', 2500);
        }
        $rootScope.displayMedia = function display_media() {
            app.closeThird();
            app.loadContentView('/main/person/r3/person.media.html', 2500);
        }
        $rootScope.displayConnections = function display_connections() {
            app.closeThird();
            app.loadContentView('/main/person/r3/person.connections.html', 2500);
        }

        $scope.Id = $rootScope.Id;
        $scope.Promise = personService.getPerson($scope.Id, function (data) {
            $scope.person = data;
        });
        $rootScope.editPerson = function edit_person(){
            app.closeThird();
            app.loadContentView('/main/person/person.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('personViewoneController', personViewoneController);

    personViewoneController.$inject = ['$rootScope', '$scope', 'personService'];
})();