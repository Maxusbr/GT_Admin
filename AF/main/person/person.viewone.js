(function () {
    'use strict';

    function personViewoneController($rootScope, $scope, personService) {
        var vm = this;

        $rootScope.displayFacts = function display_facts() {
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
        $rootScope.displayInternet = function display_internet() {
            app.closeThird();
            app.loadContentView('/main/person/r3/person.internet.html', 2500);
        }
        $rootScope.displayAntro = function display_antro() {
            app.closeThird();
            app.loadContentView('/main/person/r3/person.antro.html', 2500);
        }

        $rootScope.displayNotes = function display_notes(){
            app.closeThird();
            app.loadContentView('/main/person/r3/person.notes.html', 2500);
        }

        $scope.Id = $rootScope.personId;
        $scope.counts = { CountDescriptions: 0, CountFacts: 0, CountConnects: 0, CountMedias: 0, CountLinks: 0, CountAntros: 0 }
        $rootScope.getPerson = function(id) {
            $scope.Promise = personService.getPerson(id, function (data) {
                $rootScope.person = data;
                personService.getCountes(id, function (counts) {
                    $scope.counts = counts;
                });
            });
        }
        $rootScope.getPerson($scope.Id);
        $rootScope.editPerson = function edit_person() {
            app.closeThird();
            app.loadContentView('/main/person/person.edit.html', 2200);
        }
    }

    angular
        .module('app')
        .controller('personViewoneController', personViewoneController);

    personViewoneController.$inject = ['$rootScope', '$scope', 'personService'];
})();