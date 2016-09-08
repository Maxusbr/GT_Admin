(function () {
    'use strict';

    function personAntroEditorController($rootScope, $scope, eventService, personService, $timeout) {
        var vm = this;


        $rootScope.saveAntro = function save_antro() {

        }

        $rootScope.displayAntroTypes = function display_antro_types() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.antro.types.html', 3200);
        }

        $scope.antronames = [];
        personService.getAntroNames(function(data) {
            $scope.antronames = data;
        });

        $scope.association = { type: 'person' }

        if (!$rootScope.events)
            eventService.getEvents();
        var antroAssociations = [];
        if ($rootScope.editedAntro.Links) {
            $scope.personeRange = $rootScope.editedAntro.Links.PersonLinks;
            $scope.eventRange = $rootScope.editedAntro.Links.EventLinks;
        } else {
            $scope.personeRange = [];
            $scope.eventRange = [];
        }
        $scope.saveAntro = function () {
            $rootScope.editedAntro.IdPerson = $rootScope.personId;

            personService.saveEntity($rootScope.personId, $rootScope.editedAntro, 'antro', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                if (id > 0 && antroAssociations.length > 0) {
                    //TODO change metod
                    antroAssociations.forEach(function (item) {
                        personService.saveAntroLink(id, item.Id, item.type);
                    });
                }
                $rootScope.getAntros();
                $timeout(function () {
                    return $rootScope.app.closeView('disAntroEditor');
                }, 3000);
            });
        }

        $scope.addAssociation = function (item) {
            if ($rootScope.editedAntro.Id)
                personService.saveAntroLink($rootScope.editedAntro.Id, item.Id, item.type, function (data) {
                    var res = data;
                });
            else antroAssociations.push(item);
            switch (item.type) {
                case 'person':
                    var pers = $rootScope.persons.filter(function (el) {
                        return el.Id === item.Id;
                    })[0];
                    $scope.personeRange.push({ Name: pers.Name, LastName: pers.LastName });
                    break;
                case 'event':
                    var event = $rootScope.events.filter(function (el) {
                        return el.Id === item.Id;
                    })[0];
                    $scope.eventRange.push({ Name: event.Name });
                    break;
                default:
            }
        }
        $scope.getPersonMedia = function (personId) {
            personService.getMedia(personId, function (data) {
                $scope.personmedialist = [];
                data.forEach(function (item) {
                    $scope.personmedialist.push.apply($scope.personmedialist, item.List);
                });
            });
        }

    }

    angular
        .module('app')
        .controller('personAntroEditorController', personAntroEditorController);

    personAntroEditorController.$inject = ['$rootScope', '$scope', 'eventService', 'personService', '$timeout'];
})();