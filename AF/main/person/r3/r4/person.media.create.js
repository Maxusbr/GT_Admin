(function () {
    'use strict';

    function PersonMediaCreateController($rootScope, $scope, personService) {
        var vm = this;

        function save(path) {
            $rootScope.editedMedia.MediaLink = path;
            var list = [$rootScope.editedMedia];
            personService.saveEntities($rootScope.personId, list, 'media', function (data) {
                $rootScope.getMedias();
                app.closeView('personMediaEdit');
            });
        }

        $scope.saveMedia = function () {
            if (!$scope.file) return;
            if ($rootScope.editedMedia.id_MediaType === 2 && typeof $scope.file != 'string')
                personService.uploadImage($scope.file, function (data) {
                    save(`${serviceUrl}${data.path}`);
                });
            else save($scope.file);
        }
    }

    angular
        .module('app')
        .controller('PersonMediaCreateController', PersonMediaCreateController);

    PersonMediaCreateController.$inject = ['$rootScope', '$scope', 'personService'];
})();