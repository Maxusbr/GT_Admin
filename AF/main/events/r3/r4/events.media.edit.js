(function () {
    'use strict';

    function EventsMediaCreateController($rootScope, $scope, personService, eventService, $filter) {
                var vm = this;
        
        // $scope.file = $rootScope.editedMedia.MediaLink;
        $scope.file = '';
        $scope.association = { type: 'events' }

        if (!$rootScope.events)
            eventService.getEvents();

        function save(path) {
            $rootScope.editedMedia.id_Person = $rootScope.personId;
            $rootScope.editedMedia.MediaLink = path;
            var list = [];
            personService.saveEntity($rootScope.personId, $rootScope.editedMedia, 'media', function (data) {
                $rootScope.getMedias();
                app.closeView('eventMediaCreate');
            });
        }

        $scope.saveMedia = function () {
            
            if ($rootScope.editedMedia.id_MediaType === 2 && typeof $scope.file != 'string')
                personService.uploadImage($scope.file, function(data) {
                    save(`${serviceUrl}${data.path}`);
                });
            else save($scope.file);
        }

        $scope.addAssociation = function(item) {
            eventService.saveAssociation(item);
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
        .controller('EventsMediaCreateController', EventsMediaCreateController);

    EventsMediaCreateController.$inject = ['$rootScope', '$scope', 'personService', 'eventService', '$filter'];
})();