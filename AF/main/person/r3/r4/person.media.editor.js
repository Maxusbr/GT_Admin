(function () {
    'use strict';

    function PersonMediaEditController($rootScope, $scope, personService, eventService) {
        var vm = this;
        $scope.file = $rootScope.editedMedia.MediaLink;
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
    }

    angular
        .module('app')
        .controller('PersonMediaEditController', PersonMediaEditController);

    PersonMediaEditController.$inject = ['$rootScope', '$scope', 'personService', 'eventService'];
})();