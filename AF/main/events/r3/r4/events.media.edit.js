﻿(function () {
    'use strict';

    function EventsMediaCreateController($rootScope, $scope, personService, eventService, $filter, $timeout) {

        var vm = this;
        $scope.showMessage = false;
        $scope.errorYes = false;
        $scope.message = '';
        $scope.file = $rootScope.editedMedia.MediaLink;
        $scope.file_video = $rootScope.editedMedia.id_MediaType === 1 ? $rootScope.editedMedia.MediaLink : 'https://www.youtube.com/watch?v=undefined';
        $scope.embed = '//img.youtube.com/vi/undefined';


        if (!$rootScope.events)
            eventService.getEvents();

        $scope.videoPreview = function () {
            $scope.youtube_link = $scope.file_video.split('v=');
            // $scope.embed_link = $scope.youtube_link[1];
            $scope.embed = '//img.youtube.com/vi/' + $scope.youtube_link[1] + '/3.jpg';

        }


        $scope.association = { types: 'person' }

        var mediaAssociations = [];
        if ($rootScope.editedMedia.Links) {
            $scope.personeRange = $rootScope.editedMedia.Links.PersonLinks;
            $scope.eventRange = $rootScope.editedMedia.Links.EventLinks;
        } else {
            $scope.personeRange = [];
            $scope.eventRange = [];
        }

        function save(path) {
            console.log(path);
            if (path == 'https://www.youtube.com/watch?v=undefined') {
                $scope.showMessage = true;
                $scope.errorYes = true;
                $scope.message = 'Error';
                return;
            }

            $rootScope.editedMedia.id_Event = $rootScope.eventId;
            $rootScope.editedMedia.MediaLink = path;
            eventService.saveEntity($rootScope.eventId, $rootScope.editedMedia, 'media', function (id) {
                $scope.errorYes = id <= 0;
                $scope.message = id <= 0 ? 'Error save' : 'Save complete';
                $scope.showMessage = true;
                if (id > 0 && mediaAssociations.length > 0) {
                    eventService.saveMediaLinks(id, mediaAssociations);
                }
                $rootScope.getMedias();
                if (!$scope.errorYes)
                    $scope.Promise = $timeout(function () {
                        return app.closeView('eventMediaCreate');
                    }, timeoutMsgShow);

            });
        }

        $scope.saveMedia = function () {
            console.log($scope.file);
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

        //$scope.addAssociation = function(item) {
        //    eventService.saveAssociation(item);
        //}

        $scope.addAssociation = function (item) {
            if ($rootScope.editedMedia.Id)
                eventService.saveMediaLink($rootScope.editedMedia.Id, item.Id, item.types, function (data) {
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
        .controller('EventsMediaCreateController', EventsMediaCreateController);

    EventsMediaCreateController.$inject = ['$rootScope', '$scope', 'personService', 'eventService', '$filter', '$timeout'];
})();