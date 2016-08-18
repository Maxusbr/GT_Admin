(function () {
    'use strict';

    function personAntroEditorController($rootScope, $cookieStore, eventService, personService) {
        var vm = this;


            $rootScope.saveAntro = function save_antro(){
                
            }

            $rootScope.displayAntroTypes = function display_antro_types(){
                app.closeFive();
                app.loadContentView('/main/dictionary/dictionary.antro.types.html', 3200);
            }

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
            $scope.saveAntro = function(path) {
                $rootScope.editedAntro.id_Person = $rootScope.personId;

                personService.saveEntity($rootScope.personId, $rootScope.editedAntro, 'antro', function (id) {
                    if (id > 0 && antroAssociations.length > 0) {
                        antroAssociations.forEach(function (item) {
                            personService.saveMediaLink(id, item.Id, item.type);
                        });
                    }
                    $rootScope.getMedias();
                    app.closeView('disAntroEditor');
                });
            }

            $scope.addAssociation = function (item) {
                if ($rootScope.editedAntro.Id)
                    personService.saveMediaLink($rootScope.editedAntro.Id, item.Id, item.type, function (data) {
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

    personAntroEditorController.$inject = ['$rootScope', '$cookieStore', 'eventService', 'personService'];
})();