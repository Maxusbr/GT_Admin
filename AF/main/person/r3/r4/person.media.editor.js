(function () {
    'use strict';

    function PersonMediaEditController($rootScope, $scope, personService) {
        var vm = this;
        
        $scope.file = $rootScope.editedMedia.MediaLink;
        
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
    }

    angular
        .module('app')
        .controller('PersonMediaEditController', PersonMediaEditController);

    PersonMediaEditController.$inject = ['$rootScope', '$scope', 'personService'];
})();