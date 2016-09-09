(function () {
    'use strict';

    function personAntroEditorController($rootScope, $scope, eventService, personService, $timeout) {
        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';


        $rootScope.saveAntro = function save_antro() {

        }

        $rootScope.displayAntroTypes = function display_antro_types() {
            app.closeFive();
            app.loadContentView('/main/dictionary/dictionary.antro.types.html', 3200);
        }

        $scope.antronames = [];
        personService.getAntroNames(function (data) {
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

        function continueSave() {
            $rootScope.getAntros();
            if (!$scope.errorYes)
                $scope.Promise = $timeout(function () {
                    return $rootScope.app.closeView('disAntroEditor');
                }, timeoutMsgShow);
        }
        $scope.saveAntro = function () {
            $rootScope.editedAntro.IdPerson = $rootScope.personId;
            personService.saveEntity($rootScope.personId, $rootScope.editedAntro, 'antro', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                if (id > 0 && antroAssociations.length > 0) {
                    personService.saveAntroLinks(id, antroAssociations, function (data) {
                        $scope.errorYes = data.success;
                        $scope.message = data.success ? data.message : 'Save complete';
                        $scope.showMessage = true;
                        continueSave();
                    });
                } else continueSave();
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