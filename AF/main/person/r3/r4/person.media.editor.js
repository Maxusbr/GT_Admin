(function () {
    'use strict';

    function PersonMediaEditController($rootScope, $scope, personService, eventService, $filter, $timeout) {
        var vm = this;

        $scope.file = $rootScope.editedMedia.MediaLink;
        $scope.file_video = $rootScope.editedMedia.id_MediaType === 1 ? $rootScope.editedMedia.MediaLink : 'https://www.youtube.com/watch?v=undefined';
        $scope.embed = '//img.youtube.com/vi/undefined';

        $scope.association = { types: 'person' }

        if (!$rootScope.events)
            eventService.getEvents();
        var mediaAssociations = [];
        if ($rootScope.editedMedia.Links) {
            $scope.personeRange = $rootScope.editedMedia.Links.PersonLinks;
            $scope.eventRange = $rootScope.editedMedia.Links.EventLinks;
        } else {
            $scope.personeRange = [];
            $scope.eventRange = [];
        }

        $scope.videoPreview = function () {
            $scope.youtube_link = $scope.file_video.split('v=');
            // $scope.embed_link = $scope.youtube_link[1];
            $scope.embed = '//img.youtube.com/vi/' + $scope.youtube_link[1] + '/3.jpg';

        }
        function save(path) {
            $rootScope.editedMedia.id_Person = $rootScope.personId;
            $rootScope.editedMedia.MediaLink = path;
            personService.saveEntity($rootScope.personId, $rootScope.editedMedia, 'media', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                if (id > 0 && mediaAssociations.length > 0) {
                    personService.saveMediaLinks(id, mediaAssociations, $rootScope.getPersonCounts);
                }
                $rootScope.getMedias();
                $timeout(function () {
                    return app.closeView('personMediaEdit');
                }, 3000);
            });
        }

        $scope.saveMedia = function () {
            if ($rootScope.editedMedia.id_MediaType === 2 && typeof $scope.file != 'string')
                personService.uploadImage($scope.file, function (data) {
                    $scope.errorYes = !data.path;
                    if (data.path) {
                        $scope.message = 'Save complete';
                        save(`${serviceUrl}${data.path}`);
                    } else {
                        $scope.message = 'Error save: ' + data;
                    }
                    $scope.showMessage = true;
                });
            else save($scope.file_video);
        }

        $scope.addAssociation = function (item) {
            if ($rootScope.editedMedia.Id)
                personService.saveMediaLink($rootScope.editedMedia.Id, item.Id, item.types, function (data) {
                    var res = data;
                });
            else mediaAssociations.push({ Id: item.Id, types: item.types });
            switch (item.types) {
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

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        $scope.loadTags = function (query) {
            if (!$scope.tags) return [];
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

    PersonMediaEditController.$inject = ['$rootScope', '$scope', 'personService', 'eventService', '$filter', '$timeout'];
})();