(function () {
    'use strict';

    function PersonMediaEditController($rootScope, $scope, personService, eventService) {
        var vm = this;
        
        $scope.file = $rootScope.editedMedia.MediaLink;
        console.log($rootScope.editedMedia);
        $scope.association = { type: 'person' }
        if (!$rootScope.events)
            eventService.getEvents();
        function save(path) {
            $rootScope.editedMedia.MediaLink = path;
            var list = [$rootScope.editedMedia];
            personService.saveEntities($rootScope.personId, list, 'media', function (data) {
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

        $scope.addAssociation = function(item) {
            personService.saveAssociation(item);
        }

        // Tags
        personService.getTags(function (data) {
            $scope.tags = [];
            $scope.tags.push.apply($scope.tags, data);
        });

        function getMediaTags() {
            personService.getPersonTags($rootScope.person.Id, function (data) {
                $scope.personTags = [];
                $scope.personTags.push.apply($scope.personTags, data);
            });
        }

        if ($rootScope.person)
            getPersonTags();

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

    PersonMediaEditController.$inject = ['$rootScope', '$scope', 'personService', 'eventService'];
})();