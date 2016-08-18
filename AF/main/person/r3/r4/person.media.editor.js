(function () {
    'use strict';

    function PersonMediaEditController($rootScope, $scope, personService, eventService, $filter) {
        var vm = this;
        
        $scope.file = $rootScope.editedMedia.MediaLink;
        console.log($rootScope.editedMedia);
        $scope.association = { type: 'person' }

        if (!$rootScope.events)
            eventService.getEvents();
        var mediaAssociations = [];

        $scope.personeRange = $rootScope.editedMedia.Links.PersonLinks;
        $scope.eventRange = $rootScope.editedMedia.Links.EventLinks;
        function save(path) {
            $rootScope.editedMedia.id_Person = $rootScope.personId;
            $rootScope.editedMedia.MediaLink = path;
            personService.saveEntity($rootScope.personId, $rootScope.editedMedia, 'media', function (id) {
                if (id > 0 && mediaAssociations.length > 0) {
                    mediaAssociations.forEach(function(item) {
                        personService.saveMediaLink(id, item.Id, item.type);
                    });
                }
                $rootScope.getMedias();
                app.closeView('personMediaEdit');
            });
        }

        $scope.saveMedia = function () {
            if ($rootScope.editedMedia.id_MediaType === 2 && typeof $scope.file != 'string')
                personService.uploadImage($scope.file, function(data) {
                    save(`${serviceUrl}${data.path}`);
                });
            else save($scope.file);
        }
        
        $scope.addAssociation = function (item) {
            if ($rootScope.editedMedia.Id)
                personService.saveMediaLink($rootScope.editedMedia.Id, item.Id, item.type, function(data) {
                    var res = data;
                });
            else mediaAssociations.push(item);
            switch (item.type) {
                case 'person':
                    var pers = $rootScope.persons.filter(function(el) {
                        return el.Id === item.Id;
                    })[0];
                    $scope.personeRange.push({Name: pers.Name, LastName: pers.LastName});
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
        $scope.getPersonMedia = function(personId) {
            personService.getMedia(personId, function (data) {
                $scope.personmedialist = [];
                data.forEach(function (item) {
                    $scope.personmedialist.push.apply($scope.personmedialist, item.List);
                });
            });
        }

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        $scope.loadTags = function (query) {
            var result = $scope.tags.filter(function (item) { return item.Name.toLowerCase().indexOf(query.toLowerCase()) >= 0; });
            result = $filter('orderBy')(result, function (item) {
                item.Name.substring(0, query.length);
            });
            return result;
        }
    }

    angular
        .module('app')
        .controller('PersonMediaEditController', PersonMediaEditController);

    PersonMediaEditController.$inject = ['$rootScope', '$scope', 'personService', 'eventService', '$filter'];
})();