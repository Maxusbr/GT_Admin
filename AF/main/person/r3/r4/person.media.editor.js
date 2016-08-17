(function () {
    'use strict';

    function PersonMediaEditController($rootScope, $scope, personService) {
        var vm = this;
        $scope.file = $rootScope.editedMedia.MediaLink;
        
        $scope.saveMedia = function () {
            personService.uploadImage($scope.file, function(data) {
                $scope.file = $rootScope.editedMedia.MediaLink = `${serviceUrl}${data.path}`;
                var list = [$rootScope.editedMedia];
                personService.saveEntities($rootScope.personId, list, 'media', function (data) {
                    $rootScope.getMedias();
                    app.closeView('personMediaEdit');
                });
            });
        }
    }

    angular
        .module('app')
        .controller('PersonMediaEditController', PersonMediaEditController);

    PersonMediaEditController.$inject = ['$rootScope', '$scope', 'personService'];
})();